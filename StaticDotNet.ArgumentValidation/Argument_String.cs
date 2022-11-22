namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Validation methods for <see cref="string"/>.
/// </summary>
public static class Argument_String {

	private const string VALUE_CANNOT_BE_WHITE_SPACE = "Value cannot be whitespace.";
	private const string VALUE_CANNOT_BE_EMPTY = "Value cannot be empty.";

	/// <summary>
	/// Validates <paramref name="value"/> is not null, empty or white space, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty or white space.</exception>
	public static string NotNullOrWhiteSpace( this Argument argument, [NotNull] string? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> string.IsNullOrWhiteSpace( argument.NotNull( value, name, message ) )
			? throw new ArgumentException( message ?? VALUE_CANNOT_BE_WHITE_SPACE, name )
			: value;

	/// <summary>
	/// Validates <paramref name="value"/> is null, not empty or white space, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty or white space.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static string? NotWhiteSpace( this Argument _, string? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value?.Trim().Length == 0 ? throw new ArgumentException( message ?? VALUE_CANNOT_BE_WHITE_SPACE, name ) : value;

	/// <summary>
	/// Validates <paramref name="value"/> is not null or empty, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
	public static string NotNullOrEmpty( this Argument argument, [NotNull] string? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> string.IsNullOrEmpty( argument.NotNull( value, name, message ) )
			? throw new ArgumentException( message ?? VALUE_CANNOT_BE_EMPTY, name )
			: value;

	/// <summary>
	/// Validates <paramref name="value"/> is null or empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static string? NotEmpty( this Argument _, string? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value?.Length == 0 ? throw new ArgumentException( message ?? VALUE_CANNOT_BE_WHITE_SPACE, name ) : value;
}
