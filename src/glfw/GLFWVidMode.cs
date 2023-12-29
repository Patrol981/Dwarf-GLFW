using System.Diagnostics;

namespace Dwarf.GLFW.Core;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly partial struct GLFWvidmode : IEquatable<GLFWvidmode> {
  public int Width { get; }
  public int Height { get; }
  public int RedBits { get; }
  public int GreenBits { get; }
  public int BlueBits { get; }
  public int RefreshRate { get; }
  public GLFWvidmode(nint handle) { Handle = handle; }
  public nint Handle { get; }
  public bool IsNull => Handle == 0;
  public static GLFWvidmode Null => new(0);
  public static bool operator ==(GLFWvidmode left, GLFWvidmode right) => left.Handle == right.Handle;
  public static bool operator !=(GLFWvidmode left, GLFWvidmode right) => left.Handle != right.Handle;
  public static bool operator ==(GLFWvidmode left, nint right) => left.Handle == right;
  public static bool operator !=(GLFWvidmode left, nint right) => left.Handle != right;
  public bool Equals(GLFWvidmode other) => Handle == other.Handle;
  /// <inheritdoc/>
  public override bool Equals(object? obj) => obj is GLFWvidmode handle && Equals(handle);
  /// <inheritdoc/>
  public override int GetHashCode() => Handle.GetHashCode();
  private string DebuggerDisplay => string.Format("GLFWvidmode [0x{0}]", Handle.ToString("X"));
}