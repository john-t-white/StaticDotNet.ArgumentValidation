using System.Globalization;
using System.Linq;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="string"/> arguments.
/// </summary>
public static class StringExtensions {

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

		throw new ArgumentException( argInfo.Message ?? Constants.VALUE_CANNOT_BE_WHITE_SPACE, argInfo.Name );
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

		if( comparisonType is null ? argInfo.Value.Equals( value ) : argInfo.Value.Equals( value, comparisonType.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_EQUAL_TO, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

#if !NETSTANDARD2_0

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

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_START_WITH, value.ToString() );
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

		if( comparisonType == null ? argInfo.Value.StartsWith( value ) : argInfo.Value.StartsWith( value, comparisonType.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_START_WITH, value?.ToString() ?? Constants.NULL );
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

		if( argInfo.Value.StartsWith( value, ignoreCase, culture ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_START_WITH, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

#if !NETSTANDARD2_0

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

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_END_WITH, value.ToString() );
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

		if( comparisonType == null ? argInfo.Value.EndsWith( value ) : argInfo.Value.EndsWith( value, comparisonType.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_END_WITH, value?.ToString() ?? Constants.NULL );
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

		if( argInfo.Value.EndsWith( value, ignoreCase, culture ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_END_WITH, value?.ToString() ?? Constants.NULL );
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

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_CONTAIN, value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

#if !NETSTANDARD2_0

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

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_CONTAIN, value.ToString() );
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

		if( argInfo.Value.Contains( value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_CONTAIN, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

#if !NETSTANDARD2_0

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not contain <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<string> Contains( in this ArgInfo<string> argInfo, string value, StringComparison comparisonType ) {

		if( argInfo.Value.Contains( value, comparisonType ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_CONTAIN, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif

	/// <summary>
	/// Ensures an argument represents a <see cref="byte"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>A new <see cref="byte"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="byte"/>.</exception>
	public static ArgInfo<byte> ToByte( in this ArgInfo<string> argInfo ) {

		if( byte.TryParse( argInfo.Value, out byte result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_BYTE;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="short"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>A new <see cref="short"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="short"/>.</exception>
	public static ArgInfo<short> ToInt16( in this ArgInfo<string> argInfo ) {

		if( short.TryParse( argInfo.Value, out short result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_INT16;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="int"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>A new <see cref="int"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="int"/>.</exception>
	public static ArgInfo<int> ToInt32( in this ArgInfo<string> argInfo ) {

		if( int.TryParse( argInfo.Value, out int result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_INT32;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="long"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>A new <see cref="long"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="long"/>.</exception>
	public static ArgInfo<long> ToInt64( in this ArgInfo<string> argInfo ) {

		if( long.TryParse( argInfo.Value, out long result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_INT64;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="long"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>A new <see cref="bool"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="long"/>.</exception>
	public static ArgInfo<bool> ToBool( in this ArgInfo<string> argInfo ) {

		if( bool.TryParse( argInfo.Value, out bool result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_BOOL;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="DateTime"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="DateTime"/>.</exception>
	public static ArgInfo<DateTime> ToDateTime( in this ArgInfo<string> argInfo, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTime.TryParse( argInfo.Value, provider, styles, out DateTime result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_DATETIME;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="DateTime"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="format">The date time format.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="DateTime"/>.</exception>
	public static ArgInfo<DateTime> ToDateTimeExact( in this ArgInfo<string> argInfo, string? format, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {
		
		if( DateTime.TryParseExact( argInfo.Value, format, provider, styles, out DateTime result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_DATETIME;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="DateTime"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="formats">The date time formats.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="DateTime"/>.</exception>
	public static ArgInfo<DateTime> ToDateTimeExact( in this ArgInfo<string> argInfo, string?[]? formats, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTime.TryParseExact( argInfo.Value, formats, provider, styles, out DateTime result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_DATETIME;
		throw new ArgumentException( message, argInfo.Name );
	}

#if NET6_0_OR_GREATER

	/// <summary>
	/// Ensures an argument represents a <see cref="DateOnly"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="DateOnly"/>.</exception>
	public static ArgInfo<DateOnly> ToDateOnly( in this ArgInfo<string> argInfo, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateOnly.TryParse( argInfo.Value, provider, styles, out DateOnly result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_DATE;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="DateOnly"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="format">The date time format.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="DateOnly"/>.</exception>
	public static ArgInfo<DateOnly> ToDateOnlyExact( in this ArgInfo<string> argInfo, string? format, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateOnly.TryParseExact( argInfo.Value, format, provider, styles, out DateOnly result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_DATE;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="DateOnly"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="formats">The date time formats.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="DateOnly"/>.</exception>
	public static ArgInfo<DateOnly> ToDateOnlyExact( in this ArgInfo<string> argInfo, string?[]? formats, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateOnly.TryParseExact( argInfo.Value, formats, provider, styles, out DateOnly result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_DATE;
		throw new ArgumentException( message, argInfo.Name );
	}

#endif

	/// <summary>
	/// Ensures an argument represents a <see cref="Type"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>A new <see cref="Type"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="Type"/>.</exception>
	[RequiresUnreferencedCode( "The type might be removed." )]
	public static ArgInfo<Type> ToType( in this ArgInfo<string> argInfo ) {

		Exception? thrownException = null;
		if( argInfo.Value is not null ) {
			Type? type;
#pragma warning disable CA1031 // Intentionally not catching specific exceptions as it is included as an inner exception.
			try {
				type = Type.GetType( argInfo.Value, true );

				// Nullabiliy ignored as per the Type.GetType documentation, throwOnError true will always throw an exception if the type isn't found.
				return new( type!, argInfo.Name, argInfo.Message );
			} catch( Exception exception ) {
				thrownException = exception;
			}
#pragma warning restore CA1031
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_TYPE;

		if( thrownException is not null ) {

			message += $" {Constants.SEE_INNER_EXCEPTION_FOR_DETAILS}";
		}

		throw new ArgumentException( message, argInfo.Name, thrownException );
	}
}
