/**

  This wrapper was inspired by GLFW implementation in Vortice.Vulkan
  https://github.com/amerkoleci/Vortice.Vulkan/blob/main/src/samples/Vortice.Vulkan.SampleFramework/GLFW.cs

**/

using System.Runtime.InteropServices;

using Dwarf.GLFW.Core;

using Vortice.Vulkan;

using static Dwarf.GLFW.Core.Callbacks;
using static Dwarf.GLFW.Core.FunctionPointers;
using static Dwarf.GLFW.Core.Gamepad;

namespace Dwarf.GLFW;

#pragma warning disable CS8500
public sealed class GLFW {
  public const int GLFW_TRUE = 1;
  public const int GLFW_FALSE = 0;

  private static readonly IntPtr s_library;
  private static unsafe delegate* unmanaged[Cdecl]<int> s_glfwInit;

  #region mappings

  private unsafe static readonly glfwWindowShouldClose_t s_glfwWindowShouldClose;
  private unsafe static readonly delegate* unmanaged[Cdecl]<VkInstance, GLFWwindow*, void*, VkSurfaceKHR*, int> s_glfwCreateWindowSurface;

  #endregion

  public unsafe static bool glfwInit() => s_glfwInit() == GLFW_TRUE;
  public static void glfwTerminate() => s_glfwTerminate();
  public unsafe static void glfwGetVersion(int* major, int* minor, int* revision) => s_glfwGetVersion(major, minor, revision);


  public unsafe static glfwErrorCallback glfwSetErrorCallback(glfwErrorCallback callback) => s_glfwSetErrorCallback(callback);
  public unsafe static glfwFramebufferCallback glfwSetFramebufferSizeCallback(GLFWwindow* window, glfwFramebufferCallback callback) => s_glfwSetFramebufferSizeCallback(window, callback);
  public unsafe static glfwCursorPosCallback glfwSetCursorPosCallback(GLFWwindow* window, glfwCursorPosCallback callback) => s_glfwSetCursorPosCallback(window, callback);
  public unsafe static glfwKeyCallback glfwSetKeyCallback(GLFWwindow* window, glfwKeyCallback callback) => s_glfwSetKeyCallback(window, callback);
  public unsafe static glfwJoystickCallback glfwSetJoystickCallback(glfwJoystickCallback callback) => s_glfwSetJoystickCallback(callback);
  public unsafe static glfwScrollCallback glfwSetScrollCallback(GLFWwindow* window, glfwScrollCallback callback) => s_glfwSetScrollCallback(window, callback);
  public unsafe static glfwMouseButtonCallback glfwSetMouseButtonCallback(GLFWwindow* window, glfwMouseButtonCallback callback) => s_glfwSetMouseButtonCallback(window, callback);

  public unsafe static void glfwInitHint(InitHintBool hint, bool value) => s_glfwInitHint((int)hint, value ? GLFW_TRUE : GLFW_FALSE);
  public unsafe static void glfwMaximizeWindow(GLFWwindow* window) => s_glfwMaximizeWindow(window);
  public unsafe static void glfwWindowHint(int hint, int value) => s_glfwWindowHint(hint, value);
  public unsafe static void glfwWindowHint(WindowHintBool hint, bool value) => s_glfwWindowHint((int)hint, value ? GLFW_TRUE : GLFW_FALSE);
  public unsafe static void glfwSetInputMode(GLFWwindow* window, int mode, int value) => s_glfwSetInputMode(window, mode, value);
  public unsafe static void glfwSetWindowIcon(GLFWwindow* window, int count, GLFWImage* images) => s_glfwSetWindowIcon(window, count, images);

  public unsafe static void glfwSetWindowTitle(GLFWwindow* window, string title) {
    var ptr = Marshal.StringToHGlobalAnsi(title);

    try {
      s_glfwSetWindowTitle(window, (byte*)ptr);
    } finally {
      Marshal.FreeHGlobal(ptr);
    }
  }

  public unsafe static GLFWwindow* glfwCreateWindow(int width, int height, string title, GLFWmonitor* monitor, GLFWwindow* share) {
    var ptr = Marshal.StringToHGlobalAnsi(title);

    try {
      return s_glfwCreateWindow(width, height, (byte*)ptr, monitor, share);
    } finally {
      Marshal.FreeHGlobal(ptr);
    }
  }

  public unsafe static void* glfwCreateCursor(GLFWImage* image, int xhot, int yhot) => s_glfwCreateCursor(image, xhot, yhot);
  public unsafe static void glfwSetCursor(GLFWwindow* window, void* cursor) => s_glfwSetCursor(window, cursor);
  public unsafe static void glfwDestroyCursor(void* cursor) => s_glfwDestroyCursor(cursor);
  public static double glfwGetTime() => s_glfwGetTime();

  public unsafe static bool glfwWindowShouldClose(GLFWwindow* window) => s_glfwWindowShouldClose(window) == GLFW_TRUE;

  public unsafe static void glfwGetWindowSize(GLFWwindow* window, out int width, out int height) => s_glfwGetWindowSize(window, out width, out height);
  public unsafe static void glfwShowWindow(GLFWwindow* window) => glfwShowWindow(window);
  public unsafe static void glfwDestroyWindow(GLFWwindow* window) => glfwDestroyWindow(window);
  public unsafe static void* glfwGetWindowUserPointer(GLFWwindow* window) => s_glfwGetWindowUserPointer(window);
  public unsafe static void glfwSetWindowUserPointer(GLFWwindow* window, void* pointer) => s_glfwSetWindowUserPointer(window, pointer);
  public unsafe static int glfwGetKey(GLFWwindow* window, int key) => s_glfwGetKey(window, key);
  public unsafe static int glfwGetMouseButton(GLFWwindow* window, int button) => s_glfwGetMouseButton(window, button);
  public unsafe static void glfwGetFramebufferSize(GLFWwindow* window, out int width, out int height) => s_glfwGetFramebufferSize(window, out width, out height);


  public unsafe static int glfwUpdateGamepadMappings(char* data) => s_glfwUpdateGamepadMappings(data);
  public unsafe static char* glfwGetGamepadName(int jid) => s_glfwGetGamepadName(jid);
  public unsafe static int glfwJoystickIsGamepad(int jid) => s_glfwJoystickIsGamepad(jid);
  public unsafe static int glfwGetGamepadState(int jid, GLFWgamepadstate* state) => s_glfwGetGamepadState(jid, state);
  public unsafe static int glfwJoystickPresent(int jid) => s_glfwJoystickPresent(jid);
  public unsafe static float* glfwGetJoystickAxes(int jid, int* count) => s_glfwGetJoystickAxes(jid, count);
  public unsafe static char* glfwGetJoystickButtons(int jid, int* count) => s_glfwGetJoystickButtons(jid, count);

  public unsafe static nint glfwGetWin32Window(GLFWwindow* window) => s_glfwGetWin32Window(window);
  public unsafe static GLFWmonitor* glfwGetPrimaryMonitor() => s_glfwGetPrimaryMonitor();
  public unsafe static GLFWvidmode* glfwGetVideoMode(GLFWmonitor* monitor) => s_glfwGetVideoMode(monitor);
  public unsafe static void glfwSetWindowPos(GLFWwindow* window, int xpos, int ypos) => s_glfwSetWindowPos(window, xpos, ypos);

  public static void glfwPollEvents() => s_glfwPollEvents();
  public static void glfwWaitEvents() => s_glfwWaitEvents();

  public static nint glfwGetRequiredInstanceExtensions(out int count) => s_glfwGetRequiredInstanceExtensions(out count);

  public static string[] glfwGetRequiredInstanceExtensions() {
    nint ptr = s_glfwGetRequiredInstanceExtensions(out int count);

    string[] array = new string[count];
    if (count > 0 && ptr != 0) {
      var offset = 0;
      for (int i = 0; i < count; i++, offset += IntPtr.Size) {
        IntPtr p = Marshal.ReadIntPtr(ptr, offset);
        array[i] = Marshal.PtrToStringAnsi(p)!;
      }
    }

    return array;
  }

  public unsafe static VkResult glfwCreateWindowSurface(VkInstance instance, GLFWwindow* window, void* allocator, VkSurfaceKHR* pSurface) {
    return (VkResult)s_glfwCreateWindowSurface(instance, window, allocator, pSurface);
  }

  unsafe static GLFW() {
    s_library = LoadGLFWLibrary();

    s_glfwInit = (delegate* unmanaged[Cdecl]<int>)GetFunctionPointer(nameof(glfwInit));
    s_glfwSetWindowUserPointer = LoadFunction<glfwSetWindowUserPointer_t>(nameof(glfwSetWindowUserPointer));
    s_glfwGetWindowUserPointer = LoadFunction<glfwGetWindowUserPointer_t>(nameof(glfwGetWindowUserPointer));
    s_glfwTerminate = LoadFunction<glfwTerminate_t>(nameof(glfwTerminate));
    s_glfwInitHint = LoadFunction<glfwInitHint_t>(nameof(glfwInitHint));
    s_glfwGetVersion = LoadFunction<glfwGetVersion_t>(nameof(glfwGetVersion));
    s_glfwSetErrorCallback = LoadFunction<glfwSetErrorCallback_t>(nameof(glfwSetErrorCallback));
    s_glfwSetFramebufferSizeCallback = LoadFunction<glfwSetFramebufferSizeCallback_t>(nameof(glfwSetFramebufferSizeCallback));
    s_glfwSetCursorPosCallback = LoadFunction<glfwSetCursorPosCallback_t>(nameof(glfwSetCursorPosCallback));
    s_glfwSetScrollCallback = LoadFunction<glfwSetScrollCallback_t>(nameof(glfwSetScrollCallback));
    s_glfwSetMouseButtonCallback = LoadFunction<glfwSetMouseButtonCallback_t>(nameof(glfwSetMouseButtonCallback));
    s_glfwSetKeyCallback = LoadFunction<glfwSetKeyCallback_t>(nameof(glfwSetKeyCallback));
    s_glfwGetKey = LoadFunction<glfwGetKey_t>(nameof(glfwGetKey));
    s_glfwGetMouseButton = LoadFunction<glfwGetMouseButton_t>(nameof(glfwGetMouseButton));

    s_glfwWindowHint = LoadFunction<glfwInitHint_t>(nameof(glfwWindowHint));
    s_glfwCreateWindow = LoadFunction<glfwCreateWindow_t>(nameof(glfwCreateWindow));
    s_glfwGetPrimaryMonitor = LoadFunction<glfwGetPrimaryMonitor_t>(nameof(glfwGetPrimaryMonitor));
    s_glfwWindowShouldClose = LoadFunction<glfwWindowShouldClose_t>(nameof(glfwWindowShouldClose));
    s_glfwGetWindowSize = LoadFunction<glfwGetWindowSize_t>(nameof(glfwGetWindowSize));
    s_glfwShowWindow = LoadFunction<glfwShowWindow_t>(nameof(glfwShowWindow));
    s_glfwGetFramebufferSize = LoadFunction<glfwGetFramebufferSize_t>(nameof(glfwGetFramebufferSize));

    s_glfwGetWin32Window = LoadFunction<glfwGetWin32Window_t>(nameof(glfwGetWin32Window));

    s_glfwPollEvents = LoadFunction<glfwPollEvents_t>(nameof(glfwPollEvents));
    s_glfwWaitEvents = LoadFunction<glfwWaitEvents_t>(nameof(glfwWaitEvents));

    s_glfwSetWindowIcon = LoadFunction<glfwSetWindowIcon_t>(nameof(glfwSetWindowIcon));
    s_glfwSetWindowTitle = LoadFunction<glfwSetWindowTitle_t>(nameof(glfwSetWindowTitle));
    s_glfwSetWindowPos = LoadFunction<glfwSetWindowPos_t>(nameof(glfwSetWindowPos));
    s_glfwGetVideoMode = LoadFunction<glfwGetVideoMode_t>(nameof(glfwGetVideoMode));
    s_glfwSetInputMode = LoadFunction<glfwSetInputMode_t>(nameof(glfwSetInputMode));
    s_glfwMaximizeWindow = LoadFunction<glfwMaximizeWindow_t>(nameof(glfwMaximizeWindow));
    s_glfwCreateCursor = LoadFunction<glfwCreateCursor_t>(nameof(glfwCreateCursor));
    s_glfwSetCursor = LoadFunction<glfwSetCursor_t>(nameof(glfwSetCursor));
    s_glfwDestroyCursor = LoadFunction<glfwDestroyCursor_t>(nameof(glfwDestroyCursor));
    s_glfwGetTime = LoadFunction<glfwGetTime_t>(nameof(glfwGetTime));

    s_glfwGetGamepadName = LoadFunction<glfwGetGamepadName_t>(nameof(glfwGetGamepadName));
    s_glfwGetGamepadState = LoadFunction<glfwGetGamepadState_t>(nameof(glfwGetGamepadState));
    s_glfwJoystickIsGamepad = LoadFunction<glfwJoystickIsGamepad_t>(nameof(glfwJoystickIsGamepad));
    s_glfwUpdateGamepadMappings = LoadFunction<glfwUpdateGamepadMappings_t>(nameof(glfwUpdateGamepadMappings));
    s_glfwSetJoystickCallback = LoadFunction<glfwSetJoystickCallback_t>(nameof(glfwSetJoystickCallback));
    s_glfwJoystickPresent = LoadFunction<glfwJoystickPresent_t>(nameof(glfwJoystickPresent));
    s_glfwGetJoystickAxes = LoadFunction<glfwGetJoystickAxes_t>(nameof(glfwGetJoystickAxes));
    s_glfwGetJoystickButtons = LoadFunction<glfwGetJoystickButtons_t>(nameof(glfwGetJoystickButtons));

    // Vulkan
    s_glfwGetRequiredInstanceExtensions = LoadFunction<glfwGetRequiredInstanceExtensions_t>(nameof(glfwGetRequiredInstanceExtensions));
    s_glfwCreateWindowSurface = (delegate* unmanaged[Cdecl]<VkInstance, GLFWwindow*, void*, VkSurfaceKHR*, int>)GetFunctionPointer(nameof(glfwCreateWindowSurface));
  }

  private static IntPtr LoadGLFWLibrary() {
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
      return Loader.LoadLibrary("glfw3.dll");
    } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
      return Loader.LoadLibrary("libglfw.so.3.3");
    } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
      return Loader.LoadLibrary("libglfw.3.dylib");
    }

    throw new PlatformNotSupportedException("GLFW platform not supported");
  }

  public static T LoadFunction<T>(string name) => Loader.LoadFunction<T>(s_library, name);
  private static IntPtr GetFunctionPointer(string name) => Loader.GetFunctionPointer(s_library, name);
}

#pragma warning restore CS8500