namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Validation methods for <see cref="bool"/>.
/// </summary>
public static class Argument_Boolean {

	/// <summary>
	/// Validates <paramref name="value"/> is true, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not true.</exception>
	public static bool True( this Argument _, bool value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value != true
			? throw new ArgumentException( message ?? Constants.VALUE_MUST_BE_TRUE, name )
			: true;

	/// <summary>
	/// Validates <paramref name="value"/> is true -OR- ignores if null, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not true.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static bool? True( this Argument _, bool? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value.HasValue && value != true
			? throw new ArgumentException( message ?? Constants.VALUE_MUST_BE_TRUE, name )
			: value;

	/// <summary>
	/// Validates <paramref name="value"/> is not null -AND- true, otherwise an <see cref="ArgumentNullException"/> -OR- <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not true.</exception>
	public static bool NotNullTrue( this Argument argument, [NotNull] bool? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.True( argument.NotNull( value, name, message ), name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is false, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not false.</exception>
	public static bool False( this Argument _, bool value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value != false
			? throw new ArgumentException( message ?? Constants.VALUE_MUST_BE_FALSE, name )
			: false;

	/// <summary>
	/// Validates <paramref name="value"/> is false -OR- ignores if null, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not fakse.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static bool? False( this Argument _, bool? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value.HasValue && value != false
			? throw new ArgumentException( message ?? Constants.VALUE_MUST_BE_FALSE, name )
			: value;

	/// <summary>
	/// Validates <paramref name="value"/> is not null -AND- false, otherwise an <see cref="ArgumentNullException"/> -OR- <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not true.</exception>
	public static bool NotNullFalse( this Argument argument, [NotNull] bool? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.False( argument.NotNull( value, name, message ), name, message );
}