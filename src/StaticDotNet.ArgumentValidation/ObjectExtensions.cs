using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="IComparable"/> arguments.
/// </summary>
public static class ObjectExtensions {

	/// <summary>
	/// Ensures an argument is equal to <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <param name="comparer">The comparer.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not equal <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<T> EqualTo<T>( in this ArgInfo<T> argInfo, T value, IEqualityComparer<T>? comparer = null )
		where T : notnull {

		if( ( comparer ?? EqualityComparer<T>.Default ).Equals( argInfo.Value, value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_EQUAL_TO, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}
}
