﻿using System.Globalization;
using System.Runtime.InteropServices;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// General argument information used when validating.
/// </summary>
/// <typeparam name="T">The type of <see cref="Value"/>.</typeparam>
/// <remarks>
/// Instantiates an instance of <see cref="ArgInfo{T}"/>.
/// </remarks>
/// <param name="value">The value of the argument.</param>
/// <param name="name">The name of the argument.</param>
/// <param name="message">The exception message.  Null for for default message.</param>
[StructLayout( LayoutKind.Auto )]
public readonly ref struct ArgInfo<T>( T value, string? name, string? message )
	where T : notnull {

	/// <summary>
	/// Returns the value of the argument.
	/// </summary>
	public readonly T Value { get; } = value;

	/// <summary>
	/// Returns the name of the argument.
	/// </summary>
	public readonly string? Name { get; } = name;

	/// <summary>
	/// Returns the exception message. If this is null, the default exception message should be used.
	/// </summary>
	public readonly string? Message { get; } = message;

	/// <summary>
	/// Casts an argument to the type <typeparamref name="TType"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TType">The type to cast to.</typeparam>
	/// <returns>A new <typeparamref name="TType"/> <see cref="ArgInfo{TType}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <see cref="Value"/> is not able to be cast to <typeparamref name="TType"/>.</exception>
	public ArgInfo<TType> As<TType>()
		where TType : notnull {

		if( Value is TType asValue) {
			return new( asValue, Name, Message );
		}
#if NET8_0_OR_GREATER
		string message = Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.VALUE_MUST_BE_ASSIGNABLE_TO, typeof( T ).FullName, typeof( TType ).FullName ?? Constants.NULL );
#else
		string message = Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_ASSIGNABLE_TO, typeof(T).FullName, typeof(TType).FullName ?? Constants.NULL );
#endif

		throw new ArgumentException( message, Name );
	}
}
