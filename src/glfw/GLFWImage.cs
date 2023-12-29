using System.Diagnostics;

namespace Dwarf.GLFW.Core;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public unsafe partial struct GLFWImage : IEquatable<GLFWImage> {
  public int Width { get; set; }
  public int Height { get; set; }
  public char* Pixels { get; set; }
  public GLFWImage(nint handle) { Handle = handle; }
  public nint Handle { get; }
  public bool IsNull => Handle == 0;
  public static GLFWImage Null => new(0);
  public static bool operator ==(GLFWImage left, GLFWImage right) => left.Handle == right.Handle;
  public static bool operator !=(GLFWImage left, GLFWImage right) => left.Handle != right.Handle;
  public static bool operator ==(GLFWImage left, nint right) => left.Handle == right;
  public static bool operator !=(GLFWImage left, nint right) => left.Handle != right;
  public bool Equals(GLFWImage other) => Handle == other.Handle;
  /// <inheritdoc/>
  public override bool Equals(object? obj) => obj is GLFWImage handle && Equals(handle);
  /// <inheritdoc/>
  public override int GetHashCode() => Handle.GetHashCode();
  private string DebuggerDisplay => string.Format("GLFWImage [0x{0}]", Handle.ToString("X"));
}