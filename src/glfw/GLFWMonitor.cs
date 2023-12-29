using System.Diagnostics;

namespace Dwarf.GLFW.Core;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly partial struct GLFWmonitor : IEquatable<GLFWmonitor> {
  public GLFWmonitor(nint handle) { Handle = handle; }
  public nint Handle { get; }
  public bool IsNull => Handle == 0;
  public static GLFWmonitor Null => new(0);
  public static implicit operator GLFWmonitor(nint handle) => new(handle);
  public static bool operator ==(GLFWmonitor left, GLFWmonitor right) => left.Handle == right.Handle;
  public static bool operator !=(GLFWmonitor left, GLFWmonitor right) => left.Handle != right.Handle;
  public static bool operator ==(GLFWmonitor left, nint right) => left.Handle == right;
  public static bool operator !=(GLFWmonitor left, nint right) => left.Handle != right;
  public bool Equals(GLFWmonitor other) => Handle == other.Handle;
  /// <inheritdoc/>
  public override bool Equals(object? obj) => obj is GLFWmonitor handle && Equals(handle);
  /// <inheritdoc/>
  public override int GetHashCode() => Handle.GetHashCode();
  private string DebuggerDisplay => string.Format("GLFWmonitor [0x{0}]", Handle.ToString("X"));
}