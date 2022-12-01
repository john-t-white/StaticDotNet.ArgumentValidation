using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating string arguments.
/// </summary>
/// <remarks>
/// Since <see cref="string"/> can't be used as a generic constraint <see cref="IEquatable{String}"/>, <see cref="IComparable{String}"/>
/// and <see cref="IEnumerable{Char}"/> are used instead.
/// </remarks>
public static class StringExtensions {

	/// <summary>
	/// Ensures a string argument is not empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <see cref="ArgInfo{T}.Value"/> is empty.</exception>
	public static ref readonly ArgInfo<T> NotEmpty<T>( in this ArgInfo<T> argInfo )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.Value?.ToString()?.Length == 0 ) {
			throw new ArgumentException( argInfo.Message ?? Constants.VALUE_CANNOT_BE_EMPTY, argInfo.Name );
		}

		return ref argInfo;
	}

	/// <summary>
	/// Ensures a string argument is not white space, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <see cref="ArgInfo{T}.Value"/> is white space.</exception>
	public static ref readonly ArgInfo<T> NotWhiteSpace<T>( in this ArgInfo<T> argInfo )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		string value = argInfo.Value.ToString() ?? string.Empty;

		if( value.Length > 0 ) {
			for( int i = 0; i < value.Length; i++ ) {
				if( !char.IsWhiteSpace( value[ i ] ) ) {
					return ref argInfo;
				}
			}
		}

		throw new ArgumentException( argInfo.Message ?? Constants.VALUE_CANNOT_BE_WHITE_SPACE, argInfo.Name );
	}

	/// <summary>
	/// Ensures a string argument has a length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The maximum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <see cref="ArgInfo{T}.Value"/> does not equal <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<T> Length<T>( in this ArgInfo<T> argInfo, int length )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.Value is null || ( argInfo.Value.ToString() ?? string.Empty ).Length == length ) {
			return ref argInfo;
		}

		throw new ArgumentOutOfRangeException( argInfo.Name, argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_HAVE_LENGTH_EQUAL_TO, length ) );
	}

	/// <summary>
	/// Ensures a string argument has a maximum length of <paramref name="maxLength"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="maxLength">The maximum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <see cref="ArgInfo{T}.Value"/> greater than <paramref name="maxLength"/>.</exception>
	public static ref readonly ArgInfo<T> MaxLength<T>( in this ArgInfo<T> argInfo, int maxLength )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.Value is null || ( argInfo.Value.ToString() ?? string.Empty ).Length <= maxLength ) {
			return ref argInfo;
		}

		throw new ArgumentOutOfRangeException( argInfo.Name, argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_CANNOT_HAVE_LENGTH_GREATER_THAN, maxLength ) );
	}

	/// <summary>
	/// Ensures a string argument has a mininum length of <paramref name="minLength"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minLength">The miniumum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <see cref="ArgInfo{T}.Value"/> is less than <paramref name="minLength"/>.</exception>
	public static ref readonly ArgInfo<T> MinLength<T>( in this ArgInfo<T> argInfo, int minLength )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.Value is null || ( argInfo.Value.ToString() ?? string.Empty ).Length >= minLength ) {
			return ref argInfo;
		}

		throw new ArgumentOutOfRangeException( argInfo.Name, argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_CANNOT_HAVE_LENGTH_LESS_THAN, minLength ) );
	}

	/// <summary>
	/// Ensures a string argument has a length between <paramref name="minLength"/> and <paramref name="maxLength"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minLength">The miniumum length.</param>
	/// <param name="maxLength">The maximum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <see cref="ArgInfo{T}.Value"/>
	/// is not between <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
	public static ref readonly ArgInfo<T> LengthBetween<T>( in this ArgInfo<T> argInfo, int minLength, int maxLength )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.Value is null || ( ( argInfo.Value.ToString() ?? string.Empty ).Length >= minLength && ( argInfo.Value.ToString() ?? string.Empty ).Length <= maxLength ) ) {
			return ref argInfo;
		}

		throw new ArgumentOutOfRangeException( argInfo.Name, argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_HAVE_LENGTH_BETWEEN, minLength, maxLength ) );
	}
}
