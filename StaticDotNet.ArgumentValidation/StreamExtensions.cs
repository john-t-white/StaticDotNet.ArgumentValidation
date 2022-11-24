using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Validation methods for <see cref="Stream"/>.
/// </summary>
public static class StreamExtensions {

	/// <summary>
	/// Validates <paramref name="value"/> is not null and readable, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not readable.</exception>
	[return: NotNull]
	public static T NotNullReadable<T>( this Argument argument, [NotNull] T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : Stream
			=> argument.Readable( argument.NotNull( value, name, message ), name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is not readable, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not readable.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? Readable<T>( this Argument _, T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : Stream
			=> value?.CanRead == false
				? throw new ArgumentException( Constants.VALUE_MUST_BE_READABLE, name )
				: value;

	/// <summary>
	/// Validates <paramref name="value"/> is not null and writable, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not writable.</exception>
	[return: NotNull]
	public static T NotNullWriteable<T>( this Argument argument, [NotNull] T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : Stream
			=> argument.Writeable( argument.NotNull( value, name, message ), name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is not writable, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not writable.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? Writeable<T>( this Argument _, T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : Stream
			=> value?.CanWrite == false
				? throw new ArgumentException( Constants.VALUE_MUST_BE_WRITEABLE, name )
				: value;
}

