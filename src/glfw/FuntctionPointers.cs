using System.Runtime.InteropServices;
using Dwarf.GLFW.OpenGL;

namespace Dwarf.GLFW.Core;

public sealed class FunctionPointers {
  // setters
  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwSetWindowUserPointer_t(GLFWwindow* window, void* pointer);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwSetWindowPos_t(GLFWwindow* window, int xpos, int ypos);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwSetInputMode_t(GLFWwindow* window, int mode, int value);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwSetWindowIcon_t(GLFWwindow* window, int count, GLFWImage* images);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwSetWindowTitle_t(GLFWwindow* window, byte* title);

  // getters
  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void* glfwGetWindowUserPointer_t(GLFWwindow* window);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwGetVersion_t(int* major, int* minor, int* revision);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate GLFWmonitor* glfwGetPrimaryMonitor_t();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwGetWindowSize_t(GLFWwindow* window, out int width, out int height);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate nint glfwGetRequiredInstanceExtensions_t(out int count);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate int glfwGetKey_t(GLFWwindow* window, int key);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate int glfwGetMouseButton_t(GLFWwindow* window, int button);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate GLFWvidmode* glfwGetVideoMode_t(GLFWmonitor* monitor);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate nint glfwGetWin32Window_t(GLFWwindow* window);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwGetFramebufferSize_t(GLFWwindow* window, out int width, out int height);

  // other
  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void glfwTerminate_t();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void glfwInitHint_t(int hint, int value);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate GLFWwindow* glfwCreateWindow_t(int width, int height, byte* title, GLFWmonitor* monitor, GLFWwindow* share);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate int glfwWindowShouldClose_t(GLFWwindow* window);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwShowWindow_t(GLFWwindow* window);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void glfwPollEvents_t();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwSwapBuffers_t(GLFWwindow* window);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwMakeContextCurrent_t(GLFWwindow* window);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate void glfwWaitEvents_t();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwMaximizeWindow_t(GLFWwindow* window);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void* glfwCreateCursor_t(GLFWImage* image, int xhot, int yhot);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwSetCursor_t(GLFWwindow* window, void* cursor);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate void glfwDestroyCursor_t(void* cursor);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate double glfwGetTime_t();

  // GL
  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public unsafe delegate GLFWglproc glfwGetProcAddress_t(byte* procname);


  internal static glfwSetWindowPos_t s_glfwSetWindowPos = null!;
  internal static glfwSetWindowUserPointer_t s_glfwSetWindowUserPointer = null!;
  internal static glfwSetInputMode_t s_glfwSetInputMode = null!;
  internal static glfwGetWindowUserPointer_t s_glfwGetWindowUserPointer = null!;
  internal static glfwTerminate_t s_glfwTerminate = null!;
  internal static glfwInitHint_t s_glfwInitHint = null!;
  internal static glfwGetVersion_t s_glfwGetVersion = null!;
  internal static glfwGetKey_t s_glfwGetKey = null!;
  internal static glfwGetMouseButton_t s_glfwGetMouseButton = null!;
  internal static glfwGetFramebufferSize_t s_glfwGetFramebufferSize = null!;
  internal static glfwGetWin32Window_t s_glfwGetWin32Window = null!;
  internal static glfwCreateCursor_t s_glfwCreateCursor = null!;
  internal static glfwSetCursor_t s_glfwSetCursor = null!;
  internal static glfwSetWindowTitle_t s_glfwSetWindowTitle = null!;
  internal static glfwDestroyCursor_t s_glfwDestroyCursor = null!;
  internal static glfwMaximizeWindow_t s_glfwMaximizeWindow = null!;
  internal static glfwInitHint_t s_glfwWindowHint = null!;
  internal static glfwCreateWindow_t s_glfwCreateWindow = null!;
  internal static glfwGetWindowSize_t s_glfwGetWindowSize = null!;
  internal static glfwShowWindow_t s_glfwShowWindow = null!;
  internal static glfwGetPrimaryMonitor_t s_glfwGetPrimaryMonitor = null!;
  internal static glfwGetVideoMode_t s_glfwGetVideoMode = null!;
  internal static glfwSetWindowIcon_t s_glfwSetWindowIcon = null!;
  internal static glfwPollEvents_t s_glfwPollEvents = null!;
  internal static glfwSwapBuffers_t s_glfwSwapBuffers = null!;
  internal static glfwMakeContextCurrent_t s_glfwMakeContextCurrent = null!;
  internal static glfwWaitEvents_t s_glfwWaitEvents = null!;
  internal static glfwGetRequiredInstanceExtensions_t s_glfwGetRequiredInstanceExtensions = null!;
  internal static glfwGetTime_t s_glfwGetTime = null!;

  // GL
  internal static glfwGetProcAddress_t s_glfwGetProcAddress = null!;

}