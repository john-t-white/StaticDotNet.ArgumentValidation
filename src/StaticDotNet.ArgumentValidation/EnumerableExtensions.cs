using System.Collections;
using System.Globalization;
using System.Numerics;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="IEnumerable"/> arguments.
/// </summary>
/// <remarks>
/// In order to keep as much performance as possible, the methods try to cast the value to specific types in order to access certain properties without having to use the Enumerator.
/// </remarks>
public static class EnumerableExtensions {

    /// <summary>
    /// Ensures an argument is empty, otherwise an <see cref="ArgumentException"/> is thrown.
    /// </summary>
    /// <typeparam name="T">The type of argument value.</typeparam>
    /// <param name="argInfo">The argument info.</param>
    /// <returns>The <see cref="ArgInfo{T}"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is empty.</exception>
    public static ref readonly ArgInfo<T> NotEmpty<T>( in this ArgInfo<T> argInfo )
        where T : IEnumerable? {

        if( argInfo.Value is null ) {
            return ref argInfo;
        }

        bool? isNotEmpty = argInfo.Value switch {
            string stringValue => stringValue.Length > 0,
            Array arrayValue => arrayValue.Length > 0,
            IList listValue => listValue.Count > 0,
            IDictionary dictionaryValue => dictionaryValue.Count > 0,
            ICollection collectionValue => collectionValue.Count > 0,
            IReadOnlyCollection<dynamic> readonlyCollectionValue => readonlyCollectionValue.Count > 0,
            ISet<dynamic> setValue => setValue.Count > 0,
            _ => null
        };

        if( isNotEmpty == true ) {
            return ref argInfo;
        }

        IEnumerator enumerator = argInfo.Value.GetEnumerator();
        if( enumerator.MoveNext() ) {
            ( enumerator as IDisposable )?.Dispose();
            return ref argInfo;
        }

        string message = argInfo.Message ?? Constants.VALUE_CANNOT_BE_EMPTY;
        throw new ArgumentException( message, argInfo.Name );
    }

    /// <summary>
	/// Ensures an argument has a length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The maximum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> does not equal <paramref name="length"/>.</exception>
    public static ref readonly ArgInfo<T> Length<T>( in this ArgInfo<T> argInfo, int length )
        where T : IEnumerable? {

        if( argInfo.Value is null ) {
            return ref argInfo;
        }

        int? valueLength = argInfo.Value switch {
            string stringValue => stringValue.Length,
            Array arrayValue => arrayValue.Length,
            IList listValue => listValue.Count,
            IDictionary dictionaryValue => dictionaryValue.Count,
            ICollection collectionValue => collectionValue.Count,
            IReadOnlyCollection<dynamic> readonlyCollectionValue => readonlyCollectionValue.Count,
            ISet<dynamic> setValue => setValue.Count,
            _ => null
        };

        if( valueLength is null ) {
            valueLength = 0;
            IEnumerator enumerator = argInfo.Value.GetEnumerator();
            while( enumerator.MoveNext() ) {
                valueLength += 1;
                if( valueLength > length ) {
                    break;
                }
            }

            ( enumerator as IDisposable )?.Dispose();
        }

        if( valueLength == length ) {
            return ref argInfo;
        }

        string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_HAVE_LENGTH_EQUAL_TO, length );
        throw new ArgumentOutOfRangeException( argInfo.Name, message );
    }

    /// <summary>
	/// Ensures an argument has a mininum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The miniumum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is less than <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<T> MinLength<T>( in this ArgInfo<T> argInfo, int length )
        where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

        if( argInfo.Value is null ) {
            return ref argInfo;
        }

        int? valueLength = argInfo.Value switch {
            string stringValue => stringValue.Length,
            Array arrayValue => arrayValue.Length,
            IList listValue => listValue.Count,
            IDictionary dictionaryValue => dictionaryValue.Count,
            ICollection collectionValue => collectionValue.Count,
            IReadOnlyCollection<dynamic> readonlyCollectionValue => readonlyCollectionValue.Count,
            ISet<dynamic> setValue => setValue.Count,
            _ => null
        };

        if( valueLength is null ) {
            valueLength = 0;
            IEnumerator enumerator = argInfo.Value.GetEnumerator();
            while( enumerator.MoveNext() ) {
                valueLength += 1;
                if( valueLength > length ) {
                    break;
                }
            }

            ( enumerator as IDisposable )?.Dispose();
        }

        if( valueLength >= length ) {
            return ref argInfo;
        }

        string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_CANNOT_HAVE_LENGTH_LESS_THAN, length );
        throw new ArgumentOutOfRangeException( argInfo.Name, message );
    }

    /// <summary>
	/// Ensures an argument has a maximum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="length">The maximum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> greater than <paramref name="length"/>.</exception>
	public static ref readonly ArgInfo<T> MaxLength<T>( in this ArgInfo<T> argInfo, int length )
        where T : IEnumerable? {

        if( argInfo.Value is null ) {
            return ref argInfo;
        }

        int? valueLength = argInfo.Value switch {
            string stringValue => stringValue.Length,
            Array arrayValue => arrayValue.Length,
            IList listValue => listValue.Count,
            IDictionary dictionaryValue => dictionaryValue.Count,
            ICollection collectionValue => collectionValue.Count,
            IReadOnlyCollection<dynamic> readonlyCollectionValue => readonlyCollectionValue.Count,
            ISet<dynamic> setValue => setValue.Count,
            _ => null
        };

        if( valueLength is null ) {
            valueLength = 0;
            IEnumerator enumerator = argInfo.Value.GetEnumerator();
            while( enumerator.MoveNext() ) {
                valueLength += 1;
                if( valueLength > length ) {
                    break;
                }
            }

            ( enumerator as IDisposable )?.Dispose();
        }

        if( valueLength <= length ) {
            return ref argInfo;
        }

        string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_CANNOT_HAVE_LENGTH_GREATER_THAN, length );
        throw new ArgumentOutOfRangeException( argInfo.Name, message );
    }

    /// <summary>
	/// Ensures an argument has a length between <paramref name="minLength"/> and <paramref name="maxLength"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of argument value.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="minLength">The miniumum length.</param>
	/// <param name="maxLength">The maximum length.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is not between <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
	public static ref readonly ArgInfo<T> LengthBetween<T>( in this ArgInfo<T> argInfo, int minLength, int maxLength )
        where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

        if( argInfo.Value is null ) {
            return ref argInfo;
        }

        int? valueLength = argInfo.Value switch {
            string stringValue => stringValue.Length,
            Array arrayValue => arrayValue.Length,
            IList listValue => listValue.Count,
            IDictionary dictionaryValue => dictionaryValue.Count,
            ICollection collectionValue => collectionValue.Count,
            IReadOnlyCollection<dynamic> readonlyCollectionValue => readonlyCollectionValue.Count,
            ISet<dynamic> setValue => setValue.Count,
            _ => null
        };

        if( valueLength is null ) {
            valueLength = 0;
            IEnumerator enumerator = argInfo.Value.GetEnumerator();
            while( enumerator.MoveNext() ) {
                valueLength += 1;
                if( valueLength > maxLength ) {
                    break;
                }
            }

            ( enumerator as IDisposable )?.Dispose();
        }

        if( valueLength >= minLength && valueLength <= maxLength ) {
            return ref argInfo;
        }

        string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_HAVE_LENGTH_BETWEEN, minLength, maxLength );
        throw new ArgumentOutOfRangeException( argInfo.Name, message );
    }
}
