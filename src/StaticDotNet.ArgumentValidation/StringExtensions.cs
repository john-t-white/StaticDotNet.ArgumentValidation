using System.Globalization;
using System.Linq;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="string"/> arguments.
/// </summary>
public static class StringExtensions {

	/// <summary>
	/// Ensures an argument is not empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is empty.</exception>
	public static ref readonly ArgInfo<string> NotEmpty( in this ArgInfo<string> argInfo ) {

		if( argInfo.Value.Length > 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? ExceptionMessages.VALUE_CANNOT_BE_EMPTY;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument has a length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> does not equal <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<string> Length( in this ArgInfo<string> argInfo, int length ) {

		if( argInfo.Value.Length == length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_HAVE_LENGTH_EQUAL_TO, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a mininum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The miniumum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is less than <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<string> MinLength( in this ArgInfo<string> argInfo, int length ) {

		if( argInfo.Value.Length >= length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_CANNOT_HAVE_LENGTH_LESS_THAN, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a maximum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The maximum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> greater than <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<string> MaxLength( in this ArgInfo<string> argInfo, int length ) {

		if( argInfo.Value.Length <= length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_CANNOT_HAVE_LENGTH_GREATER_THAN, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a length inclusively between <paramref name="minLength"/> and <paramref name="maxLength"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minLength">The miniumum length.</param>
	/// <param name="maxLength">The maximum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is not between <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
	public static ref readonly ArgInfo<string> LengthBetween( in this ArgInfo<string> argInfo, int minLength, int maxLength ) {

		if( argInfo.Value.Length >= minLength && argInfo.Value.Length <= maxLength ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_HAVE_LENGTH_BETWEEN, minLength, maxLength );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is not white space, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is white space.</exception>
	public static ref readonly ArgInfo<string> NotWhiteSpace( in this ArgInfo<string> argInfo ) {

		for( int i = 0; i < argInfo.Value.Length; i++ ) {
			if( !char.IsWhiteSpace( argInfo.Value[ i ] ) ) {
				return ref argInfo;
			}
		}

		throw new ArgumentException( argInfo.Message ?? ExceptionMessages.VALUE_CANNOT_BE_WHITE_SPACE, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is equal to <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not equal <paramref name="value"/>.</exception>
	[SuppressMessage( "Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Does not assume default comparisonType if not specified." )]
	[SuppressMessage( "Globalization", "CA1309:Use ordinal string comparison", Justification = "Does not assume default comparisonType if not specified." )]
	public static ref readonly ArgInfo<string> EqualTo( in this ArgInfo<string> argInfo, string value, StringComparison? comparisonType = null ) {

		if( value is not null && ( comparisonType is null ? argInfo.Value.Equals( value ) : argInfo.Value.Equals( value, comparisonType.Value ) ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_EQUAL_TO, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER

	/// <summary>
	/// Ensures an argument starts with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should start with.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<string> StartsWith( in this ArgInfo<string> argInfo, char value ) {

		if( argInfo.Value.StartsWith( value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_START_WITH, value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif

	/// <summary>
	/// Ensures an argument starts with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should start with.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	[SuppressMessage( "Globalization", "CA1310:Specify StringComparison for correctness", Justification = "Does not assume default comparisonType if not specified." )]
	public static ref readonly ArgInfo<string> StartsWith( in this ArgInfo<string> argInfo, string value, StringComparison? comparisonType = null ) {

		if( value is not null && ( comparisonType == null ? argInfo.Value.StartsWith( value ) : argInfo.Value.StartsWith( value, comparisonType.Value ) ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_START_WITH, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument starts with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should start with.</param>
	/// <param name="ignoreCase">true to ignore case.</param>
	/// <param name="culture">The culture to use.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<string> StartsWith( in this ArgInfo<string> argInfo, string value, bool ignoreCase, CultureInfo? culture = null ) {

		if( value is not null && argInfo.Value.StartsWith( value, ignoreCase, culture ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_START_WITH, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER

	/// <summary>
	/// Ensures an argument ends with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to it should end with.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<string> EndsWith( in this ArgInfo<string> argInfo, char value ) {

		if( argInfo.Value.EndsWith( value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_END_WITH, value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif

	/// <summary>
	/// Ensures an argument ends with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to it should end with.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	[SuppressMessage( "Globalization", "CA1310:Specify StringComparison for correctness", Justification = "Does not assume default comparisonType if not specified." )]
	public static ref readonly ArgInfo<string> EndsWith( in this ArgInfo<string> argInfo, string value, StringComparison? comparisonType = null ) {

		if( value is not null && ( comparisonType == null ? argInfo.Value.EndsWith( value ) : argInfo.Value.EndsWith( value, comparisonType.Value ) ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_END_WITH, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument ends with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to it should end with.</param>
	/// <param name="ignoreCase">true to ignore case.</param>
	/// <param name="culture">The culture to use.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<string> EndsWith( in this ArgInfo<string> argInfo, string value, bool ignoreCase, CultureInfo? culture = null ) {

		if( value is not null && argInfo.Value.EndsWith( value, ignoreCase, culture ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_END_WITH, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not contain <paramref name="value"/>.</exception>
	[SuppressMessage( "Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Does not assume default comparisonType if not specified." )]
	public static ref readonly ArgInfo<string> Contains( in this ArgInfo<string> argInfo, char value ) {

		if( argInfo.Value.Contains( value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_CONTAIN, value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not contain <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<string> Contains( in this ArgInfo<string> argInfo, char value, StringComparison comparisonType ) {

		if( argInfo.Value.Contains( value, comparisonType ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_CONTAIN, value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not contain <paramref name="value"/>.</exception>
	[SuppressMessage( "Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Does not assume default comparisonType if not specified." )]
	public static ref readonly ArgInfo<string> Contains( in this ArgInfo<string> argInfo, string value ) {

		if( value is not null && argInfo.Value.Contains( value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_CONTAIN, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not contain <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<string> Contains( in this ArgInfo<string> argInfo, string value, StringComparison comparisonType ) {

		if( value is not null && argInfo.Value.Contains( value, comparisonType ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_CONTAIN, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif

}
