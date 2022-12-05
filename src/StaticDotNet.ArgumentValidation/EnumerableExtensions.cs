using System.Collections;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="IEnumerable"/> arguments.
/// </summary>
public static class EnumerableExtensions {

	/// <summary>
	/// Ensures an enumerable argument is empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is empty.</exception>
	public static ref readonly ArgInfo<T> NotEmpty<T>( in this ArgInfo<T> argInfo )
		where T : IEnumerable? {

		switch( argInfo.Value ) {

			case null:
				return ref argInfo;

			case string value:
				if( value.Length > 0 ) {
					return ref argInfo;
				}

				break;

			case Array value:
				if( value.Length > 0 ) {
					return ref argInfo;
				}

				break;

			case IList value:
				if( value.Count > 0 ) {
					return ref argInfo;
				}

				break;

			case IDictionary value:
				if( value.Count > 0 ) {
					return ref argInfo;
				}

				break;

			case ICollection value:
				if( value.Count > 0 ) {
					return ref argInfo;
				}

				break;

			default:
				IEnumerator enumerator = argInfo.Value.GetEnumerator();
				if( enumerator.MoveNext() ) {

					( enumerator as IDisposable )?.Dispose();
					return ref argInfo;
				}

				break;
		}

		string message = argInfo.Message ?? Constants.VALUE_CANNOT_BE_EMPTY;
		throw new ArgumentException( message, argInfo.Name );
	}
}
