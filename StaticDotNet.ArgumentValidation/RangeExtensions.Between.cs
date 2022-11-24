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

	///// <summary>
	///// Validates <paramref name="value"/> is not null and between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	///// </summary>
	///// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	///// <param name="argument">The <see cref="Argument"/>.</param>
	///// <param name="value">The value of the argument.</param>
	///// <param name="minValue">The minimum value.</param>
	///// <param name="maxValue">The maximum value.</param>
	///// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	///// <param name="message">The exception message.  Null for for default message.</param>
	///// <returns>Returns <paramref name="value"/>.</returns>
	///// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	///// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
	//[return: NotNull]
	//public static T NotNullBetween<T>( this Argument argument, [NotNull] T? value, T minValue, T maxValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
	//	where T : class
	//	=> argument.Between( argument.NotNull( value, name, message ), minValue, maxValue, Comparer<T>.Default, name, message );

	///// <summary>
	///// Validates <paramref name="value"/> is not null and between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	///// </summary>
	///// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	///// <param name="argument">The <see cref="Argument"/>.</param>
	///// <param name="value">The value of the argument.</param>
	///// <param name="minValue">The minimum value.</param>
	///// <param name="maxValue">The maximum value.</param>
	///// <param name="comparer">The <see cref="IComparer{T}"/> to use.</param>
	///// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	///// <param name="message">The exception message.  Null for for default message.</param>
	///// <returns>Returns <paramref name="value"/>.</returns>
	///// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	///// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
	//[return: NotNull]
	//public static T NotNullBetween<T>( this Argument argument, [NotNull] T? value, T minValue, T maxValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
	//	where T : class
	//	=> argument.Between( argument.NotNull( value, name, message ), minValue, maxValue, comparer, name, message );

	///// <summary>
	///// Validates <paramref name="value"/> is not null and between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	///// </summary>
	///// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	///// <param name="argument">The <see cref="Argument"/>.</param>
	///// <param name="value">The value of the argument.</param>
	///// <param name="minValue">The minimum value.</param>
	///// <param name="maxValue">The maximum value.</param>
	///// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	///// <param name="message">The exception message.  Null for for default message.</param>
	///// <returns>Returns <paramref name="value"/>.</returns>
	///// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	///// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
	//[return: NotNull]
	//public static T NotNullBetween<T>( this Argument argument, [NotNull] T? value, T minValue, T maxValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
	//	where T : struct
	//	=> argument.Between( argument.NotNull( value, name, message ), minValue, maxValue, Comparer<T>.Default, name, message );

	///// <summary>
	///// Validates <paramref name="value"/> is not null and between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	///// </summary>
	///// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	///// <param name="argument">The <see cref="Argument"/>.</param>
	///// <param name="value">The value of the argument.</param>
	///// <param name="minValue">The minimum value.</param>
	///// <param name="maxValue">The maximum value.</param>
	///// <param name="comparer">The <see cref="IComparer{T}"/> to use.</param>
	///// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	///// <param name="message">The exception message.  Null for for default message.</param>
	///// <returns>Returns <paramref name="value"/>.</returns>
	///// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	///// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
	//[return: NotNull]
	//public static T NotNullBetween<T>( this Argument argument, [NotNull] T? value, T minValue, T maxValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
	//	where T : struct
	//	=> argument.Between( argument.NotNull( value, name, message ), minValue, maxValue, comparer, name, message );

	///// <summary>
	///// Validates <paramref name="value"/> is between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	///// </summary>
	///// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	///// <param name="argument">The <see cref="Argument"/>.</param>
	///// <param name="value">The value of the argument.</param>
	///// <param name="minValue">The minimum value.</param>
	///// <param name="maxValue">The maximum value.</param>
	///// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	///// <param name="message">The exception message.  Null for for default message.</param>
	///// <returns>Returns <paramref name="value"/>.</returns>
	///// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
	//[return: NotNullIfNotNull( nameof( value ) )]
	//public static T? Between<T>( this Argument argument, T? value, T minValue, T maxValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
	//	=> argument.Between( value, minValue, maxValue, Comparer<T>.Default, name, message );

	///// <summary>
	///// Validates <paramref name="value"/> is between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	///// </summary>
	///// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	///// <param name="_">The <see cref="Argument"/>.</param>
	///// <param name="value">The value of the argument.</param>
	///// <param name="minValue">The minimum value.</param>
	///// <param name="maxValue">The maximum value.</param>
	///// <param name="comparer">The <see cref="IComparer{T}"/> to use.</param>
	///// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	///// <param name="message">The exception message.  Null for for default message.</param>
	///// <returns>Returns <paramref name="value"/>.</returns>
	///// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not between inclusive <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
	//[return: NotNullIfNotNull( nameof( value ) )]
	//public static T? Between<T>( this Argument _, T? value, T minValue, T maxValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null ) {
		
	//	if( value == null ) {
	//		return default;
	//	}

	//	comparer ??= Comparer<T>.Default;
	//	return minValue != null && maxValue != null && comparer.Compare(value, minValue) >= 0 && comparer.Compare(value, maxValue) <= 0
	//		? value
	//		: throw new ArgumentOutOfRangeException( name, message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_BETWEEN, minValue?.ToString() ?? Constants.NULL, maxValue?.ToString() ?? Constants.NULL ) );
	//}





	public static T NotNullBetween<T>( this Argument argument, [NotNull] T? value, T minValue, T maxValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct, IComparable<T>
		=> argument.Between( argument.NotNull( value, name, message ), minValue, maxValue, name, message );

	[return: NotNull]
	public static T NotNullBetween<T>( this Argument argument, [NotNull] T? value, T minValue, T maxValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : IComparable<T>
		=> argument.Between( argument.NotNull( value, name, message ), minValue, maxValue, name, message );

	[return: NotNull]
	public static T NotNullBetween<T>( this Argument argument, [NotNull] T? value, T minValue, T maxValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.Between( argument.NotNull( value, name, message ), minValue, maxValue, comparer, name, message );

	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? Between<T>( this Argument _, T? value, T minValue, T maxValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct, IComparable<T>
		=> !( value?.CompareTo( minValue ) < 0) && !(value?.CompareTo( maxValue ) > 0 )
			? value
			: throw new ArgumentOutOfRangeException( name, message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_BETWEEN, minValue.ToString(), maxValue.ToString() ) );

	[return: NotNullIfNotNull( nameof( value ) )]
	public static T Between<T>( this Argument _, T value, T minValue, T maxValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : IComparable<T>?
		=> minValue != null && maxValue != null && !( value?.CompareTo( minValue ) < 0 ) && !( value?.CompareTo( maxValue ) > 0 )
			? value
			: throw new ArgumentOutOfRangeException( name, message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_BETWEEN, minValue?.ToString() ?? Constants.NULL, maxValue?.ToString() ?? Constants.NULL ) );

	[return: NotNullIfNotNull( nameof( value ) )]
	public static T Between<T>( this Argument _, T value, T minValue, T maxValue, IComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null ) {

		comparer ??= Comparer<T>.Default;

		return comparer.Compare( value, minValue ) >= 0 && comparer.Compare( value, maxValue ) <= 0
			? value
			: throw new ArgumentOutOfRangeException( name, message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_BETWEEN, minValue?.ToString() ?? Constants.NULL, maxValue?.ToString() ?? Constants.NULL ) );
	}
}
