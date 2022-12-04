using System.Globalization;
using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating string arguments.
/// </summary>
/// <remarks>
/// Since <see cref="string"/> can't be used as a generic constraint <see cref="IEquatable{String}"/>, <see cref="IComparable{String}"/>
/// and <see cref="IEnumerable{Char}"/> are used instead. Generic constraints are specifically used to ensure nullability is passed on.
/// </remarks>
public static class StringExtensions {

	/// <summary>
	/// Ensures a string argument is not white space, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is white space.</exception>
	public static ref readonly ArgInfo<T> NotWhiteSpace<T>( in this ArgInfo<T> argInfo )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null ) {
			return ref argInfo;
		}

		for( int i = 0; i < argInfo.ValueAsString.Length; i++ ) {
			if( !char.IsWhiteSpace( argInfo.ValueAsString[ i ] ) ) {
				return ref argInfo;
			}
		}

		throw new ArgumentException( argInfo.Message ?? Constants.VALUE_CANNOT_BE_WHITE_SPACE, argInfo.Name );
	}

	/// <summary>
	/// Ensures a string argument is equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not equal <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T> EqualTo<T>( in this ArgInfo<T> argInfo, string comparisonValue, StringComparison comparisonType )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || GetStringComparer( comparisonType ).Equals( argInfo.ValueAsString, comparisonValue ) ) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_EQUAL_TO, comparisonValue?.ToString() ?? Constants.NULL ), argInfo.Name );
	}

	/// <summary>
	/// Ensures a string argument starts with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should start with.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<T> StartsWith<T>( in this ArgInfo<T> argInfo, string value, StringComparison comparisonType )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || argInfo.ValueAsString.StartsWith( value, comparisonType ) ) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_START_WITH, value?.ToString() ?? Constants.NULL ), argInfo.Name );
	}

	/// <summary>
	/// Ensures a string argument ends with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to it should end with.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<T> EndsWith<T>( in this ArgInfo<T> argInfo, string value, StringComparison comparisonType )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || argInfo.ValueAsString.EndsWith( value, comparisonType ) ) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_END_WITH, value?.ToString() ?? Constants.NULL ), argInfo.Name );
	}

#if !NETSTANDARD2_0

	/// <summary>
	/// Ensures a string argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not contain <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<T> Contains<T>( in this ArgInfo<T> argInfo, string value, StringComparison comparisonType )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || argInfo.ValueAsString.Contains( value, comparisonType ) ) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_CONTAIN, value?.ToString() ?? Constants.NULL ), argInfo.Name );
	}

#endif

	/// <summary>
	/// Ensures a string argument has a length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The maximum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> does not equal <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<T> Length<T>( in this ArgInfo<T> argInfo, int length )
	where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || ( argInfo.ValueAsString.ToString() ).Length == length ) {
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
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> greater than <paramref name="maxLength"/>.</exception>
	public static ref readonly ArgInfo<T> MaxLength<T>( in this ArgInfo<T> argInfo, int maxLength )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || ( argInfo.ValueAsString ).Length <= maxLength ) {
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
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is less than <paramref name="minLength"/>.</exception>
	public static ref readonly ArgInfo<T> MinLength<T>( in this ArgInfo<T> argInfo, int minLength )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || ( argInfo.ValueAsString ).Length >= minLength ) {
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
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is not between <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
	public static ref readonly ArgInfo<T> LengthBetween<T>( in this ArgInfo<T> argInfo, int minLength, int maxLength )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || ( ( argInfo.ValueAsString ).Length >= minLength && ( argInfo.ValueAsString ).Length <= maxLength ) ) {
			return ref argInfo;
		}

		throw new ArgumentOutOfRangeException( argInfo.Name, argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_HAVE_LENGTH_BETWEEN, minLength, maxLength ) );
	}

	/// <summary>
	/// Ensures a string argument matches the regular expression <paramref name="pattern"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="pattern">The regular expression pattern.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not match the <paramref name="pattern"/></exception>
	public static ref readonly ArgInfo<T> Matches<T>( in this ArgInfo<T> argInfo, [StringSyntax( StringSyntaxAttribute.Regex ) ] string pattern )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || ( pattern is not null && Regex.IsMatch( argInfo.ValueAsString, pattern ) ) ) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_MATCH_REGEX, pattern ?? Constants.NULL ), argInfo.Name );
	}

	/// <summary>
	/// Ensures a string argument matches the regular expression <paramref name="pattern"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="pattern">The regular expression pattern.</param>
	/// <param name="options">The regex options.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not match the <paramref name="pattern"/></exception>
	public static ref readonly ArgInfo<T> Matches<T>( in this ArgInfo<T> argInfo, [StringSyntax( StringSyntaxAttribute.Regex )] string pattern, RegexOptions options )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || ( pattern is not null && Regex.IsMatch( argInfo.ValueAsString, pattern, options ) ) ) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_MATCH_REGEX, pattern ?? Constants.NULL ), argInfo.Name );
	}

	/// <summary>
	/// Ensures a string argument matches the regular expression <paramref name="regex"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="regex">The regular expression pattern.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not match the <paramref name="regex"/></exception>
	public static ref readonly ArgInfo<T> Matches<T>( in this ArgInfo<T> argInfo, Regex regex )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || ( regex is not null && regex.IsMatch( argInfo.ValueAsString ) ) ) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_MATCH_REGEX, regex?.ToString() ?? Constants.NULL ), argInfo.Name );
	}

	/// <summary>
	/// Ensures a string argument matches the regular expression <paramref name="pattern"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="pattern">The regular expression pattern.</param>
	/// <param name="match">The match result.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not match the <paramref name="pattern"/></exception>
	public static ref readonly ArgInfo<T> Matches<T>( in this ArgInfo<T> argInfo, [StringSyntax( StringSyntaxAttribute.Regex )] string pattern, out Match match )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null ) {
			match = Match.Empty;
			return ref argInfo;
		}

		match = pattern is not null ? Regex.Match( argInfo.ValueAsString, pattern ) : Match.Empty;
		if( match.Success) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_MATCH_REGEX, pattern ?? Constants.NULL ), argInfo.Name );
	}

	/// <summary>
	/// Ensures a string argument matches the regular expression <paramref name="pattern"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="pattern">The regular expression pattern.</param>
	/// <param name="options">The regex options.</param>
	/// <param name="match">The match result.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not match the <paramref name="pattern"/></exception>
	public static ref readonly ArgInfo<T> Matches<T>( in this ArgInfo<T> argInfo, [StringSyntax( StringSyntaxAttribute.Regex )] string pattern, RegexOptions options, out Match match )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null ) {
			match = Match.Empty;
			return ref argInfo;
		}

		match = pattern is not null ? Regex.Match( argInfo.ValueAsString, pattern, options ) : Match.Empty;
		if( match.Success ) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_MATCH_REGEX, pattern ?? Constants.NULL ), argInfo.Name );
	}

	/// <summary>
	/// Ensures a string argument matches the regular expression <paramref name="regex"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="regex">The regular expression pattern.</param>
	/// <param name="match">The match result.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not match the <paramref name="regex"/></exception>
	public static ref readonly ArgInfo<T> Matches<T>( in this ArgInfo<T> argInfo, Regex regex, out Match match )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null ) {
			match = Match.Empty;
			return ref argInfo;
		}

		match = regex is not null ? regex.Match( argInfo.ValueAsString ) : Match.Empty;
		if( match.Success ) {
			return ref argInfo;
		}

		throw new ArgumentException( argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_MATCH_REGEX, regex?.ToString() ?? Constants.NULL ), argInfo.Name );
	}

	#region Internal Methods

#if NETSTANDARD2_0

	private static StringComparer GetStringComparer( StringComparison comparisonType )
		=> comparisonType switch {
			StringComparison.CurrentCulture => StringComparer.CurrentCulture,

			StringComparison.CurrentCultureIgnoreCase => StringComparer.CurrentCultureIgnoreCase,

			StringComparison.InvariantCulture => StringComparer.InvariantCulture,

			StringComparison.InvariantCultureIgnoreCase => StringComparer.InvariantCultureIgnoreCase,

			StringComparison.Ordinal => StringComparer.Ordinal,

			StringComparison.OrdinalIgnoreCase => StringComparer.OrdinalIgnoreCase,

			_ => throw new InvalidOperationException( "Comparison type not supported." )
		};

#else

	private static StringComparer GetStringComparer( StringComparison comparisonType ) => StringComparer.FromComparison( comparisonType );

#endif

	#endregion
}
