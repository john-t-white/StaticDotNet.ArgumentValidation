using System.Collections;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="IEnumerable"/> arguments.
/// </summary>
/// <remarks>
/// In order to keep as much performance as possible, the methods try to cast the value to specific types in order to access certain properties without having to use the enumerator.  If the enumerator
/// is used, it only iterates the smallest amount to keep performance.  Using the enumerator may also allocate memory.
/// </remarks>
public static class EnumerableExtensions {

	/// <summary>
	/// Ensures an argument is empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is empty.</exception>
	public static ref readonly ArgInfo<T> NotEmpty<T>( in this ArgInfo<T> argInfo )
		where T : IEnumerable? {

		if( argInfo.Value is null || GetLength( argInfo.Value, 1 ) > 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_CANNOT_BE_EMPTY;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument has a length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The maximum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> does not equal <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<T> Length<T>( in this ArgInfo<T> argInfo, int length )
		where T : IEnumerable? {

		if( argInfo.Value is null || GetLength( argInfo.Value, length + 1 ) == length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_HAVE_LENGTH_EQUAL_TO, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a mininum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The miniumum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is less than <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<T> MinLength<T>( in this ArgInfo<T> argInfo, int length )
		where T : IEnumerable? {

		if( argInfo.Value is null || GetLength( argInfo.Value, length ) >= length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_CANNOT_HAVE_LENGTH_LESS_THAN, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a maximum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The maximum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> greater than <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<T> MaxLength<T>( in this ArgInfo<T> argInfo, int length )
		where T : IEnumerable? {

		if( argInfo.Value is null || GetLength( argInfo.Value, length + 1 ) <= length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_CANNOT_HAVE_LENGTH_GREATER_THAN, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a length between <paramref name="minLength"/> and <paramref name="maxLength"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minLength">The miniumum length.</param>
	/// <param name="maxLength">The maximum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is not between <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
	public static ref readonly ArgInfo<T> LengthBetween<T>( in this ArgInfo<T> argInfo, int minLength, int maxLength )
		where T : IEnumerable? {

		if( argInfo.Value is null ) {
			return ref argInfo;
		}

		int enumerableLength = GetLength( argInfo.Value, maxLength + 1 );

		if( enumerableLength >= minLength && enumerableLength <= maxLength ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_HAVE_LENGTH_BETWEEN, minLength, maxLength );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	#region Internal Methods

	/// <remarks>
	/// DisallowNullAttribute is needed because it is failing due to the constraint must also be IEnumerable? in order for the methods to call it
	/// and <paramref name="value"/> should never be null when this is called.
	/// </remarks>
	internal static int GetLength<T>( [DisallowNull] T value, int maxEnumeratorIterations )
		where T : IEnumerable? {

		int? enumerableLength = value switch {
			string stringValue => stringValue.Length,
			Array arrayValue => arrayValue.Length,
			IList listValue => listValue.Count,
			IDictionary dictionaryValue => dictionaryValue.Count,
			ICollection collectionValue => collectionValue.Count,
			IReadOnlyCollection<dynamic> readonlyCollectionValue => readonlyCollectionValue.Count,
			_ => null
		};

		if( enumerableLength is null ) {

			enumerableLength = 0;
			IEnumerator enumerator = value.GetEnumerator();
			while( enumerator.MoveNext() ) {
				enumerableLength += 1;
				if( enumerableLength == maxEnumeratorIterations ) {
					break;
				}
			}

			( enumerator as IDisposable )?.Dispose();
		}

		return enumerableLength.Value;
	}

	#endregion
}
