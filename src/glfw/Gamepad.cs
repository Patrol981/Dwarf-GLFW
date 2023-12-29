using System.Runtime.InteropServices;

namespace Dwarf.GLFW.Core;

#pragma warning disable CS8500
public sealed class Gamepad {
  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate int glfwUpdateGamepadMappings_t(char* data);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate char* glfwGetGamepadName_t(int jid);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int glfwJoystickIsGamepad_t(int jid);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]

  internal unsafe delegate int glfwGetGamepadState_t(int jid, GLFWgamepadstate* state);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate int glfwJoystickPresent_t(int jid);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate float* glfwGetJoystickAxes_t(int jid, int* count);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal unsafe delegate char* glfwGetJoystickButtons_t(int jid, int* count);

  //


  internal static glfwGetGamepadName_t s_glfwGetGamepadName = null!;
  internal static glfwGetGamepadState_t s_glfwGetGamepadState;
  internal static glfwJoystickIsGamepad_t s_glfwJoystickIsGamepad;
  internal static glfwUpdateGamepadMappings_t s_glfwUpdateGamepadMappings;
  internal static glfwJoystickPresent_t s_glfwJoystickPresent;
  internal static glfwGetJoystickAxes_t s_glfwGetJoystickAxes;
  internal static glfwGetJoystickButtons_t s_glfwGetJoystickButtons;
}
#pragma warning restore CS8500