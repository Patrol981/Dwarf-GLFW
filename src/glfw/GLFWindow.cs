using System.Diagnostics;

namespace Dwarf.GLFW.Core;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly partial struct GLFWwindow : IEquatable<GLFWwindow> {
  public GLFWwindow(nint handle) { Handle = handle; }
  public nint Handle { get; }
  public bool IsNull => Handle == 0;
  public static GLFWwindow Null => new(0);
  public static implicit operator GLFWwindow(nint handle) => new(handle);
  public static bool operator ==(GLFWwindow left, GLFWwindow right) => left.Handle == right.Handle;
  public static bool operator !=(GLFWwindow left, GLFWwindow right) => left.Handle != right.Handle;
  public static bool operator ==(GLFWwindow left, nint right) => left.Handle == right;
  public static bool operator !=(GLFWwindow left, nint right) => left.Handle != right;
  public bool Equals(GLFWwindow other) => Handle == other.Handle;
  /// <inheritdoc/>
  public override bool Equals(object? obj) => obj is GLFWwindow handle && Equals(handle);
  /// <inheritdoc/>
  public override int GetHashCode() => Handle.GetHashCode();
  private string DebuggerDisplay => string.Format("GLFWwindow [0x{0}]", Handle.ToString("X"));
}