using System.Diagnostics;

namespace Dwarf.GLFW.Core;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public unsafe readonly partial struct GLFWgamepadstate : IEquatable<GLFWgamepadstate> {
  public char[] Buttons { get; } = null!;
  public float[] Axes { get; } = null!;
  public GLFWgamepadstate(nint handle) { Handle = handle; }
  public nint Handle { get; }
  public bool IsNull => Handle == 0;
  public static GLFWgamepadstate Null => new(0);
  public static bool operator ==(GLFWgamepadstate left, GLFWgamepadstate right) => left.Handle == right.Handle;
  public static bool operator !=(GLFWgamepadstate left, GLFWgamepadstate right) => left.Handle != right.Handle;
  public static bool operator ==(GLFWgamepadstate left, nint right) => left.Handle == right;
  public static bool operator !=(GLFWgamepadstate left, nint right) => left.Handle != right;
  public bool Equals(GLFWgamepadstate other) => Handle == other.Handle;
  /// <inheritdoc/>
  public override bool Equals(object? obj) => obj is GLFWgamepadstate handle && Equals(handle);
  /// <inheritdoc/>
  public override int GetHashCode() => Handle.GetHashCode();
  private string DebuggerDisplay => string.Format("GLFWgamepadstate [0x{0}]", Handle.ToString("X"));
}