using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Validation methods for <see cref="object"/>.
/// </summary>
public static class EqualityExtensions {

	[return: NotNull]
	public static T NotNullEqualTo<T>( this Argument argument, [NotNull] T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : class
		=> argument.EqualTo( argument.NotNull( value, name, message ), comparisonValue, EqualityComparer<T>.Default, name, message );

	[return: NotNull]
	public static T NotNullEqualTo<T>( this Argument argument, [NotNull] T? value, T comparisonValue, IEqualityComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : class
		=> argument.EqualTo( argument.NotNull( value, name, message ), comparisonValue, comparer, name, message );

	public static T NotNullEqualTo<T>( this Argument argument, [NotNull] T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct
		=> argument.EqualTo( argument.NotNull( value, name, message ), comparisonValue, EqualityComparer<T>.Default, name, message );

	public static T NotNullEqualTo<T>( this Argument argument, [NotNull] T? value, T comparisonValue, IEqualityComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct
		=> argument.EqualTo( argument.NotNull( value, name, message ), comparisonValue, comparer, name, message );

	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? EqualTo<T>( this Argument argument, T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.EqualTo(value, comparisonValue, EqualityComparer<T>.Default, name, message );

	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? EqualTo<T>( this Argument _, T? value, T comparisonValue, IEqualityComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value == null
			? default
			: comparisonValue != null && ( comparer ?? EqualityComparer<T>.Default ).Equals( value, comparisonValue )
				? value
				: throw new ArgumentOutOfRangeException( name, message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_EQUAL_TO, comparisonValue?.ToString() ?? Constants.NULL ) );
}