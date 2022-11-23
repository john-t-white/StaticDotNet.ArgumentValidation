using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Validation methods for checking value ranges.
/// </summary>
public static partial class RangeExtensions {

	/// <summary>
	/// Validates <paramref name="value"/> is not null and less than <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not less than <paramref name="comparisonValue"/>.</exception>
	[return: NotNull]
	public static T NotNullLessThan<T>( this Argument argument, [NotNull] T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : class
		=> argument.LessThan( argument.NotNull( value, name, message ), comparisonValue, Comparer<T>.Default, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is not null and less than <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="comparer">The <see cref="IComparer{T}"/> to use.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not less than <paramref name="comparisonValue"/>.</exception>
	[return: NotNull]
	public static T NotNullLessThan<T>( this Argument argument, [NotNull] T? value, T comparisonValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : class
		=> argument.LessThan( argument.NotNull( value, name, message ), comparisonValue, comparer, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is not null and less than <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not less than <paramref name="comparisonValue"/>.</exception>
	[return: NotNull]
	public static T NotNullLessThan<T>( this Argument argument, [NotNull] T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct
		=> argument.LessThan( argument.NotNull( value, name, message ), comparisonValue, Comparer<T>.Default, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is not null and less than <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="comparer">The <see cref="IComparer{T}"/> to use.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not less than <paramref name="comparisonValue"/>.</exception>
	[return: NotNull]
	public static T NotNullLessThan<T>( this Argument argument, [NotNull] T? value, T comparisonValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct
		=> argument.LessThan( argument.NotNull( value, name, message ), comparisonValue, comparer, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is less than <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not less than <paramref name="comparisonValue"/>.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? LessThan<T>( this Argument argument, T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.LessThan( value, comparisonValue, Comparer<T>.Default, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is less than <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="comparer">The <see cref="IComparer{T}"/> to use.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not less than <paramref name="comparisonValue"/>.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? LessThan<T>( this Argument _, T? value, T comparisonValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value == null
			? default
			: comparisonValue != null && ( comparer ?? Comparer<T>.Default ).Compare( value, comparisonValue ) < 0
				? value
				: throw new ArgumentOutOfRangeException( name, message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_LESS_THAN, comparisonValue?.ToString() ?? Constants.NULL ) );
}
