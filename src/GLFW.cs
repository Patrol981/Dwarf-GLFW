/**

  This wrapper was inspired by GLFW implementation in Vortice.Vulkan
  https://github.com/amerkoleci/Vortice.Vulkan/blob/main/src/samples/Vortice.Vulkan.SampleFramework/GLFW.cs

**/

using System.Runtime.InteropServices;

using Dwarf.GLFW.Core;
using Dwarf.GLFW.OpenGL;

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
  private static readonly unsafe delegate* unmanaged[Cdecl]<int> s_glfwInit;

  #region mappings

  private static readonly unsafe glfwWindowShouldClose_t s_glfwWindowShouldClose;
  private static readonly unsafe delegate* unmanaged[Cdecl]<VkInstance, GLFWwindow*, void*, VkSurfaceKHR*, int> s_glfwCreateWindowSurface;

  #endregion

  public static unsafe bool glfwInit() => s_glfwInit() == GLFW_TRUE;
  public static void glfwTerminate() => s_glfwTerminate();
  public static unsafe void glfwGetVersion(int* major, int* minor, int* revision) => s_glfwGetVersion(major, minor, revision);


  public static unsafe glfwErrorCallback glfwSetErrorCallback(glfwErrorCallback callback) => s_glfwSetErrorCallback(callback);
  public static unsafe glfwFramebufferCallback glfwSetFramebufferSizeCallback(GLFWwindow* window, glfwFramebufferCallback callback) => s_glfwSetFramebufferSizeCallback(window, callback);
  public static unsafe glfwCursorPosCallback glfwSetCursorPosCallback(GLFWwindow* window, glfwCursorPosCallback callback) => s_glfwSetCursorPosCallback(window, callback);
  public static unsafe glfwKeyCallback glfwSetKeyCallback(GLFWwindow* window, glfwKeyCallback callback) => s_glfwSetKeyCallback(window, callback);
  public static unsafe glfwJoystickCallback glfwSetJoystickCallback(glfwJoystickCallback callback) => s_glfwSetJoystickCallback(callback);
  public static unsafe glfwScrollCallback glfwSetScrollCallback(GLFWwindow* window, glfwScrollCallback callback) => s_glfwSetScrollCallback(window, callback);
  public static unsafe glfwMouseButtonCallback glfwSetMouseButtonCallback(GLFWwindow* window, glfwMouseButtonCallback callback) => s_glfwSetMouseButtonCallback(window, callback);
  public static unsafe void glfwSetWindowIconifyCallback(GLFWwindow* window, glfwWindowIconifyCallback callback) => s_glfwSetWindowIconifyCallback(window, callback);

  public static unsafe void glfwInitHint(InitHintBool hint, bool value) => s_glfwInitHint((int)hint, value ? GLFW_TRUE : GLFW_FALSE);
  public static unsafe void glfwMaximizeWindow(GLFWwindow* window) => s_glfwMaximizeWindow(window);
  public static unsafe void glfwWindowHint(int hint, int value) => s_glfwWindowHint(hint, value);
  public static unsafe void glfwWindowHint(WindowHintBool hint, bool value) => s_glfwWindowHint((int)hint, value ? GLFW_TRUE : GLFW_FALSE);
  public static unsafe void glfwSetInputMode(GLFWwindow* window, int mode, int value) => s_glfwSetInputMode(window, mode, value);
  public static unsafe void glfwSetWindowIcon(GLFWwindow* window, int count, GLFWImage* images) => s_glfwSetWindowIcon(window, count, images);

  public static unsafe void glfwSetWindowTitle(GLFWwindow* window, string title) {
    var ptr = Marshal.StringToHGlobalAnsi(title);

    try {
      s_glfwSetWindowTitle(window, (byte*)ptr);
    } finally {
      Marshal.FreeHGlobal(ptr);
    }
  }

  public static unsafe GLFWwindow* glfwCreateWindow(int width, int height, string title, GLFWmonitor* monitor, GLFWwindow* share) {
    var ptr = Marshal.StringToHGlobalAnsi(title);

    try {
      return s_glfwCreateWindow(width, height, (byte*)ptr, monitor, share);
    } finally {
      Marshal.FreeHGlobal(ptr);
    }
  }

  public static unsafe void* glfwCreateCursor(GLFWImage* image, int xhot, int yhot) => s_glfwCreateCursor(image, xhot, yhot);
  public static unsafe void glfwSetCursor(GLFWwindow* window, void* cursor) => s_glfwSetCursor(window, cursor);
  public static unsafe void glfwDestroyCursor(void* cursor) => s_glfwDestroyCursor(cursor);
  public static double glfwGetTime() => s_glfwGetTime();

  public static unsafe bool glfwWindowShouldClose(GLFWwindow* window) => s_glfwWindowShouldClose(window) == GLFW_TRUE;

  public static unsafe void glfwGetWindowSize(GLFWwindow* window, out int width, out int height) => s_glfwGetWindowSize(window, out width, out height);
  public static unsafe void glfwShowWindow(GLFWwindow* window) => glfwShowWindow(window);
  public static unsafe void glfwDestroyWindow(GLFWwindow* window) => glfwDestroyWindow(window);
  public static unsafe void* glfwGetWindowUserPointer(GLFWwindow* window) => s_glfwGetWindowUserPointer(window);
  public static unsafe void glfwSetWindowUserPointer(GLFWwindow* window, void* pointer) => s_glfwSetWindowUserPointer(window, pointer);
  public static unsafe int glfwGetKey(GLFWwindow* window, int key) => s_glfwGetKey(window, key);
  public static unsafe int glfwGetMouseButton(GLFWwindow* window, int button) => s_glfwGetMouseButton(window, button);
  public static unsafe void glfwGetFramebufferSize(GLFWwindow* window, out int width, out int height) => s_glfwGetFramebufferSize(window, out width, out height);


  public static unsafe int glfwUpdateGamepadMappings(char* data) => s_glfwUpdateGamepadMappings(data);
  public static unsafe char* glfwGetGamepadName(int jid) => s_glfwGetGamepadName(jid);
  public static unsafe int glfwJoystickIsGamepad(int jid) => s_glfwJoystickIsGamepad(jid);
  public static unsafe int glfwGetGamepadState(int jid, GLFWgamepadstate* state) => s_glfwGetGamepadState(jid, state);
  public static unsafe int glfwJoystickPresent(int jid) => s_glfwJoystickPresent(jid);
  public static unsafe float* glfwGetJoystickAxes(int jid, int* count) => s_glfwGetJoystickAxes(jid, count);
  public static unsafe char* glfwGetJoystickButtons(int jid, int* count) => s_glfwGetJoystickButtons(jid, count);

  public static unsafe nint glfwGetWin32Window(GLFWwindow* window) => s_glfwGetWin32Window(window);
  public static unsafe GLFWmonitor* glfwGetPrimaryMonitor() => s_glfwGetPrimaryMonitor();
  public static unsafe GLFWvidmode* glfwGetVideoMode(GLFWmonitor* monitor) => s_glfwGetVideoMode(monitor);
  public static unsafe void glfwSetWindowPos(GLFWwindow* window, int xpos, int ypos) => s_glfwSetWindowPos(window, xpos, ypos);

  public static void glfwPollEvents() => s_glfwPollEvents();
  public static unsafe void glfwSwapBuffers(GLFWwindow* window) => s_glfwSwapBuffers(window);
  public static unsafe void glfwMakeContextCurrent(GLFWwindow* window) => s_glfwMakeContextCurrent(window);
  public static void glfwWaitEvents() => s_glfwWaitEvents();

  public static nint glfwGetRequiredInstanceExtensions(out int count) => s_glfwGetRequiredInstanceExtensions(out count);

  public static unsafe VkUtf8String[] glfwGetRequiredInstanceExtensions() {
    nint ptr = s_glfwGetRequiredInstanceExtensions(out int count);

    VkUtf8String[] array = new VkUtf8String[count];
    if (count > 0 && ptr != 0) {
      var offset = 0;
      for (int i = 0; i < count; i++, offset += IntPtr.Size) {
        IntPtr p = Marshal.ReadIntPtr(ptr, offset);
        array[i] = new VkUtf8String((byte*)p);
      }
    }

    return array;
  }

  public static unsafe VkResult glfwCreateWindowSurface(VkInstance instance, GLFWwindow* window, void* allocator, VkSurfaceKHR* pSurface) {
    return (VkResult)s_glfwCreateWindowSurface(instance, window, allocator, pSurface);
  }

  // GL
  public static unsafe GLFWglproc glfwGetProcAddress(byte* procname) => s_glfwGetProcAddress(procname);

  static unsafe GLFW() {
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

    s_glfwSetWindowIconifyCallback = LoadFunction<glfwSetWindowIconifyCallback_t>(nameof(glfwSetWindowIconifyCallback));
    s_glfwWindowHint = LoadFunction<glfwInitHint_t>(nameof(glfwWindowHint));
    s_glfwCreateWindow = LoadFunction<glfwCreateWindow_t>(nameof(glfwCreateWindow));
    s_glfwGetPrimaryMonitor = LoadFunction<glfwGetPrimaryMonitor_t>(nameof(glfwGetPrimaryMonitor));
    s_glfwWindowShouldClose = LoadFunction<glfwWindowShouldClose_t>(nameof(glfwWindowShouldClose));
    s_glfwGetWindowSize = LoadFunction<glfwGetWindowSize_t>(nameof(glfwGetWindowSize));
    s_glfwShowWindow = LoadFunction<glfwShowWindow_t>(nameof(glfwShowWindow));
    s_glfwGetFramebufferSize = LoadFunction<glfwGetFramebufferSize_t>(nameof(glfwGetFramebufferSize));

    s_glfwGetWin32Window = LoadFunction<glfwGetWin32Window_t>(nameof(glfwGetWin32Window));

    s_glfwPollEvents = LoadFunction<glfwPollEvents_t>(nameof(glfwPollEvents));
    s_glfwSwapBuffers = LoadFunction<glfwSwapBuffers_t>(nameof(glfwSwapBuffers));
    s_glfwMakeContextCurrent = LoadFunction<glfwMakeContextCurrent_t>(nameof(glfwMakeContextCurrent));
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

    // GL
    s_glfwGetProcAddress = LoadFunction<glfwGetProcAddress_t>(nameof(glfwGetProcAddress));
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