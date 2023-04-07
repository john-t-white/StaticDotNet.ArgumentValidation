using StaticDotNet.ArgumentValidation.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating arrays arguments.
/// </summary>
public static class ArrayExtensions {

	/// <summary>
	/// Ensures an argument is not empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument array type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is empty.</exception>
	public static ref readonly ArgInfo<T[]> NotEmpty<T>( in this ArgInfo<T[]> argInfo ) {

		if( argInfo.Value.Length > 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? ExceptionMessages.VALUE_CANNOT_BE_EMPTY;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument has a length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument array type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> does not equal <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<T[]> Length<T>( in this ArgInfo<T[]> argInfo, int length ) {

		if( argInfo.Value.Length == length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_LENGTH_MUST_BE_EQUAL_TO, argInfo.Value.Length, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a mininum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument array type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The miniumum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is less than <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<T[]> MinLength<T>( in this ArgInfo<T[]> argInfo, int length ) {

		if( argInfo.Value.Length >= length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_LENGTH_BELOW_MIN_LENGTH, argInfo.Value.Length, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a maximum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument array type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The maximum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> greater than <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<T[]> MaxLength<T>( in this ArgInfo<T[]> argInfo, int length ) {

		if( argInfo.Value.Length <= length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_LENGTH_EXCEEDS_MAX_LENGTH, argInfo.Value.Length, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a length inclusively between <paramref name="minLength"/> and <paramref name="maxLength"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument array type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minLength">The miniumum length.</param>
	/// <param name="maxLength">The maximum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is not between <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
	public static ref readonly ArgInfo<T[]> LengthBetween<T>( in this ArgInfo<T[]> argInfo, int minLength, int maxLength ) {

		if( argInfo.Value.Length >= minLength && argInfo.Value.Length <= maxLength ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_LENGTH_MUST_BE_BETWEEN, argInfo.Value.Length, minLength, maxLength );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument array type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <param name="comparer">The comparer.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not contain <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<T[]> Contains<T>( in this ArgInfo<T[]> argInfo, T value, IEqualityComparer<T>? comparer = null ) {

		// Specifically not calling the overload that accepts a comparer if it is null as it still allocates memory and is twice as slow.
		if( comparer is null ? argInfo.Value.Contains( value ) : argInfo.Value.Contains( value, comparer ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_CONTAIN, Stringify.Value( value ) );
		throw new ArgumentException( message, argInfo.Name );
	}
}
