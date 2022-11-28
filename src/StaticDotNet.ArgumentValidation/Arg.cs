namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Starting class for access to all argument validation through <see cref="Is"/>.
/// </summary>
public sealed class Arg {

	private Arg() {
	}

	/// <summary>
	/// Returns <see cref="Arg"/> with access to all validation methods.
	/// </summary>
	public static readonly Arg Is = new();
}