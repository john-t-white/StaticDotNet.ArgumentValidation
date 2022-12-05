using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="IComparable"/> arguments.
/// </summary>
public static class ComparableExtensions {

	/// <summary>
	/// Ensures an argument is greater than <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not greater than <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T> GreaterThan<T>( in this ArgInfo<T> argInfo, [DisallowNull] T comparisonValue )
		where T : IComparable<T>? {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( comparisonValue is not null && argInfo.Value.CompareTo( comparisonValue ) > 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_GREATER_THAN, comparisonValue?.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is greater than <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not greater than <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T?> GreaterThan<T>( in this ArgInfo<T?> argInfo, T comparisonValue )
		where T : struct, IComparable<T> {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( argInfo.Value.Value.CompareTo( comparisonValue ) > 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_GREATER_THAN, comparisonValue.ToString() );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is greater than or equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not greater than or equal to <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T> GreaterThanOrEqualTo<T>( in this ArgInfo<T> argInfo, [DisallowNull] T comparisonValue )
		where T : IComparable<T>? {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( comparisonValue is not null && argInfo.Value.CompareTo( comparisonValue ) >= 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_GREATER_THAN_OR_EQUAL_TO, comparisonValue?.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is greater than or equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not greater than or equal to <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T?> GreaterThanOrEqualTo<T>( in this ArgInfo<T?> argInfo, T comparisonValue )
		where T : struct, IComparable<T> {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( argInfo.Value.Value.CompareTo( comparisonValue ) >= 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_GREATER_THAN_OR_EQUAL_TO, comparisonValue.ToString() );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is less than <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not less than <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T> LessThan<T>( in this ArgInfo<T> argInfo, [DisallowNull] T comparisonValue )
		where T : IComparable<T>? {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( comparisonValue is not null && argInfo.Value.CompareTo( comparisonValue ) < 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_LESS_THAN, comparisonValue?.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is less than <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not less than <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T?> LessThan<T>( in this ArgInfo<T?> argInfo, T comparisonValue )
		where T : struct, IComparable<T> {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( argInfo.Value.Value.CompareTo( comparisonValue ) < 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_LESS_THAN, comparisonValue.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is less than or equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not less than or equal to <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T> LessThanOrEqualTo<T>( in this ArgInfo<T> argInfo, [DisallowNull] T comparisonValue )
		where T : IComparable<T>? {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( comparisonValue is not null && argInfo.Value.CompareTo( comparisonValue ) <= 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_LESS_THAN_OR_EQUAL_TO, comparisonValue?.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is less than or equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not less than or equal to <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T?> LessThanOrEqualTo<T>( in this ArgInfo<T?> argInfo, T comparisonValue )
		where T : struct, IComparable<T> {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( argInfo.Value.Value.CompareTo( comparisonValue ) <= 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_LESS_THAN_OR_EQUAL_TO, comparisonValue.ToString() );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is between <paramref name="minValue"/> and <paramref name="maxValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minValue">The minimum value.</param>
	/// <param name="maxValue">The minimum value.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not between <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
	public static ref readonly ArgInfo<T> Between<T>( in this ArgInfo<T> argInfo, [DisallowNull] T minValue, [DisallowNull] T maxValue )
		where T : IComparable<T>? {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( minValue is not null && maxValue is not null && argInfo.Value.CompareTo( minValue ) >= 0 && argInfo.Value.CompareTo( maxValue ) <= 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_BETWEEN, minValue?.ToString() ?? Constants.NULL, maxValue?.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is between <paramref name="minValue"/> and <paramref name="maxValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minValue">The minimum value.</param>
	/// <param name="maxValue">The minimum value.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not between <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
	public static ref readonly ArgInfo<T?> Between<T>( in this ArgInfo<T?> argInfo, T minValue, T maxValue )
		where T : struct, IComparable<T> {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		T argValue = argInfo.Value.Value;
		if( argValue.CompareTo( minValue ) >= 0 && argValue.CompareTo( maxValue ) <= 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_BETWEEN, minValue.ToString(), maxValue.ToString() );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}
}
