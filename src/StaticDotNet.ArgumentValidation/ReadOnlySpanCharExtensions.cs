#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER

using StaticDotNet.ArgumentValidation.Infrastructure;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="char"/> <see cref="ReadOnlySpan{T}"/> arguments.
/// </summary>
public static class ReadOnlySpanCharExtensions {

	/// <summary>
	/// Ensures an argument is not white space, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is white space.</exception>
	public static ref readonly ReadOnlySpanArgInfo<char> NotWhiteSpace( in this ReadOnlySpanArgInfo<char> argInfo ) {

		for( int i = 0; i < argInfo.Value.Length; i++ ) {
			if( !char.IsWhiteSpace( argInfo.Value[ i ] ) ) {
				return ref argInfo;
			}
		}

		string message = argInfo.Message ?? ExceptionMessages.VALUE_CANNOT_BE_WHITE_SPACE;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is equal to <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not equal <paramref name="value"/>.</exception>
	public static ref readonly ReadOnlySpanArgInfo<char> EqualTo( in this ReadOnlySpanArgInfo<char> argInfo, ReadOnlySpan<char> value, StringComparison comparisonType ) {

		if( argInfo.Value.Equals( value, comparisonType ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_EQUAL_TO, Stringify.Value( argInfo.Value ), Stringify.Value( value ) );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument starts with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should start with.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	public static ref readonly ReadOnlySpanArgInfo<char> StartsWith( in this ReadOnlySpanArgInfo<char> argInfo, ReadOnlySpan<char> value, StringComparison comparisonType ) {

		if( argInfo.Value.StartsWith( value, comparisonType ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_START_WITH, value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument ends with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should start with.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not end with <paramref name="value"/>.</exception>
	public static ref readonly ReadOnlySpanArgInfo<char> EndsWith( in this ReadOnlySpanArgInfo<char> argInfo, ReadOnlySpan<char> value, StringComparison comparisonType ) {

		if( argInfo.Value.EndsWith( value, comparisonType ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.STRING_MUST_END_WITH, argInfo.Value.ToString(), Stringify.Value( value ) );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not end with <paramref name="value"/>.</exception>
	public static ref readonly ReadOnlySpanArgInfo<char> Contains( in this ReadOnlySpanArgInfo<char> argInfo, ReadOnlySpan<char> value, StringComparison comparisonType ) {

		if( argInfo.Value.Contains( value, comparisonType ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.STRING_MUST_CONTAIN, argInfo.Value.ToString(), Stringify.Value( value ) );
		throw new ArgumentException( message, argInfo.Name );
	}
}

#endif
