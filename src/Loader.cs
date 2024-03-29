using System.Reflection;
using System.Runtime.InteropServices;

namespace Dwarf.GLFW;

public sealed class Loader {
  public static IntPtr LoadLibrary(string libraryName) {
    string libraryPath = GetNativeAssemblyPath(libraryName);

    IntPtr handle = LoadPlatformLibrary(libraryPath);
    return handle == IntPtr.Zero ? throw new DllNotFoundException($"failed to load {libraryName}.") : handle;
  }
  public static T LoadFunction<T>(IntPtr library, string name) {
    IntPtr functionPtr = NativeLibrary.GetExport(library, name);
    return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
  }
  public static string GetNativeAssemblyPath(string libraryName) {
    string os = TargetPlatform;
    Architecture arch = TargetArchitecture;

    string assemblyLocation = Assembly.GetExecutingAssembly() != null ?
      Assembly.GetExecutingAssembly().Location :
      typeof(Loader).Assembly.Location;

    if (string.IsNullOrEmpty(assemblyLocation)) {
      assemblyLocation = AppContext.BaseDirectory;
    }

    assemblyLocation = Path.GetDirectoryName(assemblyLocation)!;

    string[] paths = [
      Path.Combine(assemblyLocation, libraryName),
      Path.Combine(assemblyLocation, "runtimes", os, "native", libraryName),
      Path.Combine(assemblyLocation, "runtimes", $"{os}-{arch}", "native", libraryName),
      Path.Combine(assemblyLocation, "native", $"{os}-{arch}", libraryName),
    ];

    foreach (string path in paths) {
      if (File.Exists(path)) {
        return path;
      }
    }

    return libraryName;
  }

  public static IntPtr GetFunctionPointer(IntPtr libraryPtr, string functionName) {
    return NativeLibrary.GetExport(libraryPtr, functionName);
  }
  private static IntPtr LoadPlatformLibrary(string name) {
    return NativeLibrary.Load(name);
  }

  private static string TargetPlatform {
    get {
      return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        ? "win"
        : RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
        ? "linux"
        : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
        ? "osx"
        : throw new PlatformNotSupportedException("target platform is unsupported.");
    }
  }

  private static Architecture TargetArchitecture => RuntimeInformation.ProcessArchitecture switch {
    Architecture.X64 => Architecture.X64,
    Architecture.X86 => Architecture.X86,
    Architecture.Arm => Architecture.Arm,
    Architecture.Arm64 => Architecture.Arm64,
    _ => throw new PlatformNotSupportedException("platform architecture is unsupported."),
  };
}