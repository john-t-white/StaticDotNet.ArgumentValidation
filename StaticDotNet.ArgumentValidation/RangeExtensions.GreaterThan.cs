using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation;

public static partial class RangeExtensions {

	[return: NotNull]
	public static T NotNullGreaterThan<T>( this Argument argument, [NotNull] T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : class
		=> argument.GreaterThan( argument.NotNull( value, name, message ), comparisonValue, Comparer<T>.Default, name, message );

	[return: NotNull]
	public static T NotNullGreaterThan<T>( this Argument argument, [NotNull] T? value, T comparisonValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : class
		=> argument.GreaterThan( argument.NotNull( value, name, message ), comparisonValue, comparer, name, message );

	[return: NotNull]
	public static T NotNullGreaterThan<T>( this Argument argument, [NotNull] T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct
		=> argument.GreaterThan( argument.NotNull( value, name, message ), comparisonValue, Comparer<T>.Default, name, message );

	[return: NotNull]
	public static T NotNullGreaterThan<T>( this Argument argument, [NotNull] T? value, T comparisonValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct
		=> argument.GreaterThan( argument.NotNull( value, name, message ), comparisonValue, comparer, name, message );

	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? GreaterThan<T>( this Argument argument, T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.GreaterThan( value, comparisonValue, Comparer<T>.Default, name, message );

	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? GreaterThan<T>( this Argument _, T? value, T comparisonValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value == null
			? default
			: comparisonValue != null && ( comparer ?? Comparer<T>.Default ).Compare( value, comparisonValue ) > 0
				? value
				: throw new ArgumentOutOfRangeException( name, message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_GREATER_THAN, comparisonValue?.ToString() ?? Constants.NULL ) );
}
