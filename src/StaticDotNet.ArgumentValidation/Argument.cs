namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Starting class for access to all argument validation through <see cref="Is"/>.
/// </summary>
public sealed class Argument {

	private Argument() {
	}

	/// <summary>
	/// Returns <see cref="Argument"/> with access to all validation methods.
	/// </summary>
	public static readonly Argument Is = new();
}