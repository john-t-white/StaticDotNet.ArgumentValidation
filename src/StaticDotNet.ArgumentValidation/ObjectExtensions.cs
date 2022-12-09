using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="IComparable"/> arguments.
/// </summary>
public static class ObjectExtensions {

	/// <summary>
	/// Ensures an argument is equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="comparer">The comparer. Null will use <see cref="EqualityComparer{T}.Default"/></param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not equal <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T> EqualTo<T>( in this ArgInfo<T> argInfo, [DisallowNull] T comparisonValue, IEqualityComparer<T>? comparer = null ) {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( comparisonValue is not null && ( comparer ?? EqualityComparer<T>.Default ).Equals( argInfo.Value, comparisonValue ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_EQUAL_TO, comparisonValue?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is equal to <paramref name="comparisonValue"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="comparisonValue">The value to compare against.</param>
	/// <param name="comparer">The comparer. Null will use <see cref="EqualityComparer{T}.Default"/></param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not equal <paramref name="comparisonValue"/>.</exception>
	public static ref readonly ArgInfo<T?> EqualTo<T>( in this ArgInfo<T?> argInfo, T comparisonValue, IEqualityComparer<T>? comparer = null )
		where T : struct {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		if( ( comparer ?? EqualityComparer<T>.Default ).Equals( argInfo.Value.Value, comparisonValue ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_EQUAL_TO, comparisonValue.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}
}
