using System.Collections;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="IEnumerable"/> arguments.
/// </summary>
/// <remarks>
/// In order to keep as much performance as possible, the methods try to cast the value to specific types in order to access certain properties without
/// having to use the enumerator.  If the enumerator is used, it only iterates the smallest amount to keep performance.  Using the enumerator
/// may also allocate memory.
/// </remarks>
public static class EnumerableExtensions {

	/// <summary>
	/// Ensures an argument is not empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is empty.</exception>
	public static ref readonly ArgInfo<TArg> NotEmpty<TArg>( in this ArgInfo<TArg> argInfo )
		where TArg : IEnumerable {

		if( GetLength( argInfo.Value, 1 ) > 0 ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? ExceptionMessages.VALUE_CANNOT_BE_EMPTY;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument has a length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> does not equal <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<TArg> Length<TArg>( in this ArgInfo<TArg> argInfo, int length )
		where TArg : IEnumerable {

		if( GetLength( argInfo.Value, length + 1 ) == length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_HAVE_LENGTH_EQUAL_TO, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a mininum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The miniumum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is less than <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<TArg> MinLength<TArg>( in this ArgInfo<TArg> argInfo, int length )
		where TArg : IEnumerable {

		if( GetLength( argInfo.Value, length ) >= length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_CANNOT_HAVE_LENGTH_LESS_THAN, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a maximum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The maximum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> greater than <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<TArg> MaxLength<TArg>( in this ArgInfo<TArg> argInfo, int length )
		where TArg : IEnumerable {

		if( GetLength( argInfo.Value, length + 1 ) <= length ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_CANNOT_HAVE_LENGTH_GREATER_THAN, length );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a length inclusively between <paramref name="minLength"/> and <paramref name="maxLength"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minLength">The miniumum length.</param>
	/// <param name="maxLength">The maximum length.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is not between <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
	public static ref readonly ArgInfo<TArg> LengthBetween<TArg>( in this ArgInfo<TArg> argInfo, int minLength, int maxLength )
		where TArg : IEnumerable {

		int enumerableLength = GetLength( argInfo.Value, maxLength + 1 );

		if( enumerableLength >= minLength && enumerableLength <= maxLength ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_HAVE_LENGTH_BETWEEN, minLength, maxLength );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <typeparam name="TItem">The argument item in the enumerable argument.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <param name="comparer">The comparer.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not contain <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<TArg> Contains<TArg, TItem>( in this ArgInfo<TArg> argInfo, TItem value, IEqualityComparer<TItem>? comparer = null )
		where TArg : IEnumerable, IEnumerable<TItem> {

		// Specifically not calling the overload that accepts a comparer if it is null as it still allocates memory and is twice as slow.
		if( comparer is null ? argInfo.Value.Contains( value ) : argInfo.Value.Contains( value, comparer ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_CONTAIN, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	#region Internal Methods

	/// <remarks>
	/// DisallowNullAttribute is needed because the constraint must also be IEnumerable? in order for the methods to call it
	/// and <paramref name="value"/> should never be null when this is called.
	/// </remarks>
	internal static int GetLength<TArg>( [DisallowNull] TArg value, int maxEnumeratorIterations )
		where TArg : IEnumerable {

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
