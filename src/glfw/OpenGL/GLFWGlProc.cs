using System.Diagnostics;

namespace Dwarf.GLFW.OpenGL;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly partial struct GLFWglproc : IEquatable<GLFWglproc> {
  public GLFWglproc(nint handle) { Handle = handle; }
  public nint Handle { get; }
  public bool IsNull => Handle == 0;
  public static GLFWglproc Null => new(0);
  public static implicit operator GLFWglproc(nint handle) => new(handle);
  public static bool operator ==(GLFWglproc left, GLFWglproc right) => left.Handle == right.Handle;
  public static bool operator !=(GLFWglproc left, GLFWglproc right) => left.Handle != right.Handle;
  public static bool operator ==(GLFWglproc left, nint right) => left.Handle == right;
  public static bool operator !=(GLFWglproc left, nint right) => left.Handle != right;
  public bool Equals(GLFWglproc other) => Handle == other.Handle;
  /// <inheritdoc/>
  public override bool Equals(object? obj) => obj is GLFWglproc handle && Equals(handle);
  /// <inheritdoc/>
  public override int GetHashCode() => Handle.GetHashCode();
  private string DebuggerDisplay => string.Format("GLFWglproc [0x{0}]", Handle.ToString("X"));
}