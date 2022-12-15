using System.Globalization;
using System.Linq;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating and converting string <see cref="string"/> arguments.
/// </summary>
public static class StringConversionExtensions {

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

	/// <summary>
	/// Ensures an argument represents a <see cref="DateTimeOffset"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="DateTimeOffset"/>.</exception>
	public static ArgInfo<DateTimeOffset> ToDateTimeOffset( in this ArgInfo<string> argInfo, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTimeOffset.TryParse( argInfo.Value, provider, styles, out DateTimeOffset result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_DATETIME_OFFSET;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="DateTimeOffset"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="format">The date time format.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="DateTimeOffset"/>.</exception>
	public static ArgInfo<DateTimeOffset> ToDateTimeOffsetExact( in this ArgInfo<string> argInfo, string? format, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTimeOffset.TryParseExact( argInfo.Value, format, provider, styles, out DateTimeOffset result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_DATETIME_OFFSET;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="DateTimeOffset"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="formats">The date time formats.</param>
	/// <param name="provider">The <see cref="IFormatProvider"/> to use.</param>
	/// <param name="styles">The <see cref="DateTimeStyles"/> to use.</param>
	/// <returns>A new <see cref="DateTime"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="DateTimeOffset"/>.</exception>
	public static ArgInfo<DateTimeOffset> ToDateTimeOffsetExact( in this ArgInfo<string> argInfo, string?[]? formats, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None ) {

		if( DateTimeOffset.TryParseExact( argInfo.Value, formats, provider, styles, out DateTimeOffset result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_DATETIME_OFFSET;
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
