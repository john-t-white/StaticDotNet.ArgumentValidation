using System.Globalization;
using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Validation methods for regular expressions.
/// </summary>
public static partial class RegexExtensions {

	/// <summary>
	/// Validates <paramref name="value"/> is not null, empty, wite space and matches <paramref name="pattern"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="pattern">The regular expression pattern.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not empty, white space or does not match <paramref name="pattern"/>.</exception>
	public static string NotNullOrWhiteSpaceMatch( this Argument argument, [NotNull] string? value, [StringSyntax( StringSyntaxAttribute.Regex )] string pattern, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.Match( argument.NotNullOrWhiteSpace( value, name, message ), pattern, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> matches <paramref name="pattern"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="pattern">The regular expression pattern.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> does not match <paramref name="pattern"/>.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static string? Match( this Argument _, string? value, [StringSyntax( StringSyntaxAttribute.Regex )] string pattern, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value == null
			? null
			: pattern != null && Regex.IsMatch( value, pattern )
				? value
				: throw new ArgumentException( message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_NOT_BE_NULL_AND_MATCH, pattern ?? Constants.NULL ), name );

	/// <summary>
	/// Validates <paramref name="value"/> is not null, empty, white space and matches <paramref name="pattern"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="pattern">The regular expression pattern.</param>
	/// <param name="match">The <see cref="System.Text.RegularExpressions.Match"/>.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty, white space or does not match <paramref name="pattern"/>.</exception>
	public static string NotNullOrWhiteSpaceMatch( this Argument argument, [NotNull] string? value, [StringSyntax( StringSyntaxAttribute.Regex )] string pattern, out Match match, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.Match( argument.NotNullOrWhiteSpace( value, name, message ), pattern, out match, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> matches <paramref name="pattern"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="pattern">The regular expression pattern.</param>
	/// <param name="match">The <see cref="System.Text.RegularExpressions.Match"/>.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> does not match <paramref name="pattern"/>.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static string? Match( this Argument _, string? value, [StringSyntax( StringSyntaxAttribute.Regex )] string pattern, out Match match, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null ) {

		if( value == null ) {
			match = System.Text.RegularExpressions.Match.Empty;
			return null;
		}

		match = pattern != null
			? Regex.Match( value, pattern )
			: System.Text.RegularExpressions.Match.Empty;

		return match.Success
			? value
			: throw new ArgumentException( message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_NOT_BE_NULL_AND_MATCH, pattern ?? Constants.NULL ), name );
	}

	/// <summary>
	/// Validates <paramref name="value"/> is not null, empty, wite space and matches <paramref name="regex"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="regex">The regular expression.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not empty, white space or does not match <paramref name="regex"/>.</exception>
	public static string NotNullOrWhiteSpaceMatch( this Argument argument, [NotNull] string? value, Regex regex, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.Match( argument.NotNullOrWhiteSpace( value, name, message ), regex, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> matches <paramref name="regex"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="regex">The regular expression.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> does not match <paramref name="regex"/>.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static string? Match( this Argument _, string? value, Regex regex, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value == null
			? null
			: regex?.IsMatch( value ) == true
				? value
				: throw new ArgumentException( message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_NOT_BE_NULL_AND_MATCH, regex?.ToString() ?? Constants.NULL ), name );

	/// <summary>
	/// Validates <paramref name="value"/> is not null, empty, white space and matches <paramref name="regex"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="regex">The regular expression.</param>
	/// <param name="match">The <see cref="System.Text.RegularExpressions.Match"/>.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty, white space or does not match <paramref name="regex"/>.</exception>
	public static string NotNullOrWhiteSpaceMatch( this Argument argument, [NotNull] string? value, Regex regex, out Match match, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.Match( argument.NotNullOrWhiteSpace( value, name, message ), regex, out match, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> matches <paramref name="regex"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="regex">The regular expression pattern.</param>
	/// <param name="match">The <see cref="System.Text.RegularExpressions.Match"/>.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> does not match <paramref name="regex"/>.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static string? Match( this Argument _, string? value, Regex regex, out Match match, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null ) {

		if( value == null ) {
			match = System.Text.RegularExpressions.Match.Empty;
			return null;
		}

		match = regex?.Match( value ) ?? System.Text.RegularExpressions.Match.Empty;

		return match.Success
			? value
			: throw new ArgumentException( message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_NOT_BE_NULL_AND_MATCH, regex?.ToString() ?? Constants.NULL ), name );
	}
}
