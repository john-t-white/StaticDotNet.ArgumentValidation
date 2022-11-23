﻿using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Validation methods for equality.
/// </summary>
public static class EqualityExtensions {

	/// <summary>
	/// Validates <paramref name="value"/> is not null and equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not equal to <paramref name="comparisonValue"/>.</exception>
	[return: NotNull]
	public static T NotNullEqualTo<T>( this Argument argument, [NotNull] T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : class
		=> argument.EqualTo( argument.NotNull( value, name, message ), comparisonValue, EqualityComparer<T>.Default, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is not null and equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to use.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not equal to <paramref name="comparisonValue"/>.</exception>
	[return: NotNull]
	public static T NotNullEqualTo<T>( this Argument argument, [NotNull] T? value, T comparisonValue, IEqualityComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : class
		=> argument.EqualTo( argument.NotNull( value, name, message ), comparisonValue, comparer, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is not null and equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not equal to <paramref name="comparisonValue"/>.</exception>
	public static T NotNullEqualTo<T>( this Argument argument, [NotNull] T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct
		=> argument.EqualTo( argument.NotNull( value, name, message ), comparisonValue, EqualityComparer<T>.Default, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is not null and equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to use.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not equal to <paramref name="comparisonValue"/>.</exception>
	public static T NotNullEqualTo<T>( this Argument argument, [NotNull] T? value, T comparisonValue, IEqualityComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : struct
		=> argument.EqualTo( argument.NotNull( value, name, message ), comparisonValue, comparer, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not equal to <paramref name="comparisonValue"/>.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? EqualTo<T>( this Argument argument, T? value, T comparisonValue, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.EqualTo(value, comparisonValue, EqualityComparer<T>.Default, name, message );

	/// <summary>
	/// Validates <paramref name="value"/> is equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to use.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not equal to <paramref name="comparisonValue"/>.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? EqualTo<T>( this Argument _, T? value, T comparisonValue, IEqualityComparer<T> comparer, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value == null
			? default
			: comparisonValue != null && ( comparer ?? EqualityComparer<T>.Default ).Equals( value, comparisonValue )
				? value
				: throw new ArgumentException( message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_EQUAL_TO, comparisonValue?.ToString() ?? Constants.NULL ), name );
}