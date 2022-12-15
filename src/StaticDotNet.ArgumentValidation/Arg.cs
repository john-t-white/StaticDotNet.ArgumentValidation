namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Starting class for access to all argument validation.
/// </summary>
public static class Arg {

	/// <summary>
	/// Ensures the argument is not null, otherwise an <see cref="ArgumentNullException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>A <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	[return: NotNull]
	public static ArgInfo<T> IsNotNull<T>( [NotNull] T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : notnull
		=> value is not null
			? new( value, name, message )
			: throw ArgumentNullExceptionFactory.Create( name, message );

	/// <summary>
	/// Ensures the argument is not null, otherwise an <see cref="ArgumentNullException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>A <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	public static ArgInfo<T> IsNotNull<T>( [NotNull] T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct
		=> value is not null
			? new( value.Value, name, message )
			: throw ArgumentNullExceptionFactory.Create( name, message );

	/// <summary>
	/// Ensures the string argument is not null or white space, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>A <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is white space.</exception>
	public static ArgInfo<string> IsNotNullOrWhiteSpace( [NotNull] string? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null ) {
		if( value is not null ) {

			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.NotWhiteSpace();

			return argInfo;
		}

		throw ArgumentNullExceptionFactory.Create( name, message );
	}

	/// <summary>
	/// Used for validating arguments where the caller has already verified the argument is not null.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>A <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is unexpectedly null and shouldn't be.</exception>
	public static ArgInfo<T> Is<T>( T value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : notnull
		=> value is not null ? new( value, name, message ) : throw new ArgumentNullException( name, Constants.VALUE_UNEXPECTED_NULL );

	/// <summary>
	/// Ensures the argument is null, otherwise an <see cref="ArgumentNullException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Null</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not null.</exception>
	public static T? IsNull<T>( T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value is null
			? default
			: throw new ArgumentException( message ?? Constants.VALUE_MUST_BE_NULL, name );
}