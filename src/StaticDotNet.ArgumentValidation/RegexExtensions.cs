using System.Globalization;
using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating string arguments using regular expressions.
/// </summary>
/// <remarks>
/// Since <see cref="string"/> can't be used as a generic constraint <see cref="IEquatable{String}"/>, <see cref="IComparable{String}"/>
/// and <see cref="IEnumerable{Char}"/> are used instead. Generic constraints are specifically used to ensure nullability is passed on.
/// </remarks>
public static class RegexExtensions {

	/// <summary>
	/// Ensures an argument matches the regular expression <paramref name="pattern"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="pattern">The regular expression pattern.</param>
	/// <param name="options">The regex options.</param>
	/// <param name="matchTimeout">The timeout.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not match the <paramref name="pattern"/></exception>
	public static ref readonly ArgInfo<string> Matches( in this ArgInfo<string> argInfo, [StringSyntax( StringSyntaxAttribute.Regex )] string pattern, RegexOptions options = RegexOptions.None, TimeSpan? matchTimeout = null ) {

		if( pattern is not null && Regex.IsMatch( argInfo.Value, pattern, options, matchTimeout ?? Regex.InfiniteMatchTimeout ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_MATCH_REGEX, pattern ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument matches the regular expression <paramref name="regex"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="regex">The regular expression pattern.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not match the <paramref name="regex"/></exception>
	public static ref readonly ArgInfo<string> Matches( in this ArgInfo<string> argInfo, Regex regex ) {

		if( regex is not null && regex.IsMatch( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_MATCH_REGEX, regex?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument matches the regular expression <paramref name="pattern"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="pattern">The regular expression pattern.</param>
	/// <param name="match">The match result.</param>
	/// <param name="options">The regex options.</param>
	/// <param name="matchTimeout">The timeout.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not match the <paramref name="pattern"/></exception>
	public static ref readonly ArgInfo<string> Matches( in this ArgInfo<string> argInfo, [StringSyntax( StringSyntaxAttribute.Regex )] string pattern, out Match match, RegexOptions options = RegexOptions.None, TimeSpan? matchTimeout = null ) {

		match = pattern is not null ? Regex.Match( argInfo.Value, pattern, options, matchTimeout ?? Regex.InfiniteMatchTimeout ) : Match.Empty;
		if( match.Success ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_MATCH_REGEX, pattern ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument matches the regular expression <paramref name="regex"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="regex">The regular expression pattern.</param>
	/// <param name="match">The match result.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not match the <paramref name="regex"/></exception>
	public static ref readonly ArgInfo<string> Matches( in this ArgInfo<string> argInfo, Regex regex, out Match match ) {

		match = regex is not null ? regex.Match( argInfo.Value ) : Match.Empty;
		if( match.Success ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_MATCH_REGEX, regex?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}
}
