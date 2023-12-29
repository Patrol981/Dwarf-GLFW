using System.Runtime.InteropServices;

namespace Dwarf.GLFW.Core;

public sealed class Callbacks {
  // getters
  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public unsafe delegate void glfwCursorPosCallback(GLFWwindow* window, double xpos, double ypos);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public unsafe delegate void glfwErrorCallback(int code, sbyte* message);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public unsafe delegate void glfwFramebufferCallback(GLFWwindow* window, int width, int height);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public unsafe delegate void glfwKeyCallback(GLFWwindow* window, int key, int scancode, int action, int mods);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public unsafe delegate void glfwJoystickCallback(int jid, int j_event);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public unsafe delegate void glfwScrollCallback(GLFWwindow* window, double xoffset, double yoffset);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public unsafe delegate void glfwMouseButtonCallback(GLFWwindow* window, int button, int action, int mods);

  // setters

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate glfwCursorPosCallback glfwSetCursorPosCallback_t(GLFWwindow* window, glfwCursorPosCallback callback);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate glfwErrorCallback glfwSetErrorCallback_t(glfwErrorCallback callback);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate glfwFramebufferCallback glfwSetFramebufferSizeCallback_t(GLFWwindow* window, glfwFramebufferCallback callback);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate glfwKeyCallback glfwSetKeyCallback_t(GLFWwindow* window, glfwKeyCallback callback);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate glfwJoystickCallback glfwSetJoystickCallback_t(glfwJoystickCallback callback);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate glfwScrollCallback glfwSetScrollCallback_t(GLFWwindow* window, glfwScrollCallback callback);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate glfwMouseButtonCallback glfwSetMouseButtonCallback_t(GLFWwindow* window, glfwMouseButtonCallback callback);

  //

  internal static glfwSetErrorCallback_t s_glfwSetErrorCallback;
  internal static glfwSetFramebufferSizeCallback_t s_glfwSetFramebufferSizeCallback;
  internal static glfwSetCursorPosCallback_t s_glfwSetCursorPosCallback;
  internal static glfwSetKeyCallback_t s_glfwSetKeyCallback;
  internal static glfwSetScrollCallback_t s_glfwSetScrollCallback;
  internal static glfwSetMouseButtonCallback_t s_glfwSetMouseButtonCallback;
  internal static glfwSetJoystickCallback_t s_glfwSetJoystickCallback;
}