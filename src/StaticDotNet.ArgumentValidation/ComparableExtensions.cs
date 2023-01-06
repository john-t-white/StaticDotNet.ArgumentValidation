using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="IComparable"/> arguments.
/// </summary>
public static class ComparableExtensions {

	/// <summary>
	/// Ensures an argument is greater than <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not greater than <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<TArg> GreaterThan<TArg>( in this ArgInfo<TArg> argInfo, [DisallowNull] TArg value )
		where TArg : IComparable<TArg> {

		if( value is not null && argInfo.Value.CompareTo( value ) > 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_GREATER_THAN, value?.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is greater than or equal to <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not greater than or equal to <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<TArg> GreaterThanOrEqualTo<TArg>( in this ArgInfo<TArg> argInfo, [DisallowNull] TArg value )
		where TArg : IComparable<TArg> {

		if( value is not null && argInfo.Value.CompareTo( value ) >= 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_GREATER_THAN_OR_EQUAL_TO, value?.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is less than <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not less than <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<TArg> LessThan<TArg>( in this ArgInfo<TArg> argInfo, [DisallowNull] TArg value )
		where TArg : IComparable<TArg> {

		if( value is not null && argInfo.Value.CompareTo( value ) < 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_LESS_THAN, value?.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is less than or equal to <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not less than or equal to <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<TArg> LessThanOrEqualTo<TArg>( in this ArgInfo<TArg> argInfo, [DisallowNull] TArg value )
		where TArg : IComparable<TArg> {

		if( value is not null && argInfo.Value.CompareTo( value ) <= 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_LESS_THAN_OR_EQUAL_TO, value?.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument is inclusively between <paramref name="minValue"/> and <paramref name="maxValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minValue">The minimum value.</param>
	/// <param name="maxValue">The minimum value.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="argInfo.Value"/> is not between <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
	public static ref readonly ArgInfo<TArg> Between<TArg>( in this ArgInfo<TArg> argInfo, [DisallowNull] TArg minValue, [DisallowNull] TArg maxValue )
		where TArg : IComparable<TArg> {

		if( minValue is not null && maxValue is not null && argInfo.Value.CompareTo( minValue ) >= 0 && argInfo.Value.CompareTo( maxValue ) <= 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_BETWEEN, minValue?.ToString() ?? Constants.NULL, maxValue?.ToString() ?? Constants.NULL );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}
}
