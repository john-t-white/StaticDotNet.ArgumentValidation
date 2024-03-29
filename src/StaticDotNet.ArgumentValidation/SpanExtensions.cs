﻿#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER

using StaticDotNet.ArgumentValidation.Infrastructure;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="ReadOnlySpan{T}"/> arguments.
/// </summary>
public static class SpanExtensions {

	/// <summary>
	/// Ensures an argument is not empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The span type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is empty.</exception>
	public static ref readonly SpanArgInfo<T> NotEmpty<T>( in this SpanArgInfo<T> argInfo ) {

		if( !argInfo.Value.IsEmpty ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? ExceptionMessages.VALUE_CANNOT_BE_EMPTY;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument has a length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The span type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> does not equal <paramref name="length"/>.</exception>
	public static ref readonly SpanArgInfo<T> Length<T>( in this SpanArgInfo<T> argInfo, int length ) {

		if( argInfo.Value.Length == length ) {
			return ref argInfo;
		}

		string? message = argInfo.Message;

#if NET8_0_OR_GREATER
		message ??= typeof( T ) != typeof( char )
				? string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.VALUE_LENGTH_MUST_BE_EQUAL_TO, argInfo.Value.Length, length )
				: string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.STRING_LENGTH_MUST_BE_EQUAL_TO, argInfo.Value.ToString(), argInfo.Value.Length, length );
#else
		message ??= typeof( T ) != typeof( char )
				? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_LENGTH_MUST_BE_EQUAL_TO, argInfo.Value.Length, length )
				: string.Format( CultureInfo.InvariantCulture, ExceptionMessages.STRING_LENGTH_MUST_BE_EQUAL_TO, argInfo.Value.ToString(), argInfo.Value.Length, length );
#endif

		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a maximum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The span type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The maximum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> greater than <paramref name="length"/>.</exception>
	public static ref readonly SpanArgInfo<T> MaxLength<T>( in this SpanArgInfo<T> argInfo, int length ) {

		if( argInfo.Value.Length <= length ) {
			return ref argInfo;
		}

		string? message = argInfo.Message;

#if NET8_0_OR_GREATER
		message ??= typeof( T ) != typeof( char )
				? string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.VALUE_LENGTH_EXCEEDS_MAX_LENGTH, argInfo.Value.Length, length )
				: string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.STRING_LENGTH_EXCEEDS_MAX_LENGTH, argInfo.Value.ToString(), argInfo.Value.Length, length );
#else
		message ??= typeof( T ) != typeof( char )
				? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_LENGTH_EXCEEDS_MAX_LENGTH, argInfo.Value.Length, length )
				: string.Format( CultureInfo.InvariantCulture, ExceptionMessages.STRING_LENGTH_EXCEEDS_MAX_LENGTH, argInfo.Value.ToString(), argInfo.Value.Length, length );
#endif

		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a minium length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The span type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The minium length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> less than <paramref name="length"/>.</exception>
	public static ref readonly SpanArgInfo<T> MinLength<T>( in this SpanArgInfo<T> argInfo, int length ) {

		if( argInfo.Value.Length >= length ) {
			return ref argInfo;
		}

		string? message = argInfo.Message;

#if NET8_0_OR_GREATER
		message ??= typeof( T ) != typeof( char )
				? string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.VALUE_LENGTH_BELOW_MIN_LENGTH, argInfo.Value.Length, length )
				: string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.STRING_LENGTH_BELOW_MIN_LENGTH, argInfo.Value.ToString(), argInfo.Value.Length, length );
#else
		message ??= typeof(T) != typeof(char)
				? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_LENGTH_BELOW_MIN_LENGTH, argInfo.Value.Length, length )
				: string.Format( CultureInfo.InvariantCulture, ExceptionMessages.STRING_LENGTH_BELOW_MIN_LENGTH, argInfo.Value.ToString(), argInfo.Value.Length, length );
#endif

		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a length inclusively between <paramref name="minLength"/> and <paramref name="maxLength"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The span type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minLength">The miniumum length.</param>
	/// <param name="maxLength">The maximum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is not between <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
	public static ref readonly SpanArgInfo<T> LengthBetween<T>( in this SpanArgInfo<T> argInfo, int minLength, int maxLength ) {

		if( argInfo.Value.Length >= minLength && argInfo.Value.Length <= maxLength ) {
			return ref argInfo;
		}

		string? message = argInfo.Message;

#if NET8_0_OR_GREATER
		message ??= typeof( T ) != typeof( char )
				? string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.VALUE_LENGTH_MUST_BE_BETWEEN, argInfo.Value.Length, minLength, maxLength )
				: string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.STRING_LENGTH_MUST_BE_BETWEEN, argInfo.Value.ToString(), argInfo.Value.Length, minLength, maxLength );
#else
		message ??= typeof( T ) != typeof( char )
				? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_LENGTH_MUST_BE_BETWEEN, argInfo.Value.Length, minLength, maxLength )
				: string.Format( CultureInfo.InvariantCulture, ExceptionMessages.STRING_LENGTH_MUST_BE_BETWEEN, argInfo.Value.ToString(), argInfo.Value.Length, minLength, maxLength );
#endif

		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument starts with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The span type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should start with.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	public static ref readonly SpanArgInfo<T> StartsWith<T>( in this SpanArgInfo<T> argInfo, ReadOnlySpan<T> value )
		where T : IEquatable<T> {

		if( argInfo.Value.StartsWith( value ) ) {
			return ref argInfo;
		}

#if NET8_0_OR_GREATER
		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.VALUE_MUST_START_WITH, string.Join( ", ", value.ToArray() ) );
#else
		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_START_WITH, string.Join( ", ", value.ToArray() ) );
#endif


		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument ends with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The span type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should start with.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not end with <paramref name="value"/>.</exception>
	public static ref readonly SpanArgInfo<T> EndsWith<T>( in this SpanArgInfo<T> argInfo, ReadOnlySpan<T> value )
		where T : IEquatable<T> {

		if( argInfo.Value.EndsWith( value ) ) {
			return ref argInfo;
		}

#if NET8_0_OR_GREATER
		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.VALUE_MUST_END_WITH, string.Join( ", ", value.ToArray() ) );
#else
		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_END_WITH, string.Join( ", ", value.ToArray() ) );
#endif

		throw new ArgumentException( message, argInfo.Name );
	}

#if NET6_0_OR_GREATER

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The span type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not end with <paramref name="value"/>.</exception>
	public static ref readonly SpanArgInfo<T> Contains<T>( in this SpanArgInfo<T> argInfo, T value )
		where T : IEquatable<T> {

		if( value is not null && argInfo.Value.Contains( value ) ) {
			return ref argInfo;
		}

		string? message = argInfo.Message;

#if NET8_0_OR_GREATER
		message ??= value is string or char
				? string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.STRING_MUST_CONTAIN, Stringify.Value( argInfo.Value ), Stringify.Value( value ) )
				: string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.VALUE_MUST_CONTAIN, Stringify.Value( value ) );
#else
		message ??= value is string or char
				? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.STRING_MUST_CONTAIN, Stringify.Value( argInfo.Value ), Stringify.Value( value ) )
				: string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_CONTAIN, Stringify.Value( value ) );
#endif

		throw new ArgumentException( message, argInfo.Name );
	}

#endif
}

#endif
