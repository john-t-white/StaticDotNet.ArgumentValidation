using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Validation methods for checking null.
/// </summary>
public static class NullExtensions {

	/// <summary>
	///  Validates <paramref name="value"/> is not null, otherwise an <see cref="ArgumentNullException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <returns>Non null <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	[return: NotNull]
	public static T NotNull<T>( this Argument _, [NotNull] T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : class {

		if( value != null ) {
			return value;
		}

		ArgumentNullException exception = message == null
			? new ArgumentNullException( name )
			: new ArgumentNullException( name, message );

		throw exception;
	}

	/// <summary>
	///  Validates <paramref name="value"/> is not null, otherwise an <see cref="ArgumentNullException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <returns>Non null <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	public static T NotNull<T>( this Argument _, [NotNull] T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct {

		if( value != null ) {
			return value.Value;
		}

		ArgumentNullException exception = message == null
			? new ArgumentNullException( name )
			: new ArgumentNullException( name, message );

		throw exception;
	}

	/// <summary>
	///  Validates <paramref name="value"/> is not null, otherwise an <see cref="ArgumentNullException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <returns>null</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not null.</exception>
	[return: MaybeNull]
	public static T? Null<T>( this Argument _, T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value != null ? throw new ArgumentException( message ?? Constants.VALUE_MUST_BE_NULL, name ) : value;
}