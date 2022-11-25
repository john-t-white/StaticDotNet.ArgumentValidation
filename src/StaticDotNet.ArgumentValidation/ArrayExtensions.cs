namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Validation methods for <see cref="Array"/>.
/// </summary>
public static class ArrayExtensions {

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
	public static T[] NotNullOrEmpty<T>( this Argument argument, [NotNull] T[]? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.NotNull( value, name, message ).Length == 0
			? throw new ArgumentException( message ?? Constants.VALUE_CANNOT_BE_EMPTY, name )
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
	public static T[]? NotEmpty<T>( this Argument _, T[]? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value?.Length == 0
			? throw new ArgumentException( message ?? Constants.VALUE_CANNOT_BE_EMPTY, name )
			: value;

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
	public static Array NotNullOrEmpty( this Argument argument, [NotNull] Array? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.NotNull( value, name, message ).Length == 0
			? throw new ArgumentException( message ?? Constants.VALUE_CANNOT_BE_EMPTY, name )
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
	public static Array? NotEmpty( this Argument _, Array? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value?.Length == 0
			? throw new ArgumentException( message ?? Constants.VALUE_CANNOT_BE_EMPTY, name )
			: value;
}
