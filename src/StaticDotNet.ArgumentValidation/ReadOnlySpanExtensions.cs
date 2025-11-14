#if !NETSTANDARD2_0

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="ReadOnlySpan{T}"/> arguments.
/// </summary>
public static class ReadOnlySpanExtensions {

    /// <summary>
    /// Ensures an argument is not empty, otherwise an <see cref="ArgumentException"/> is thrown.
    /// </summary>
    /// <typeparam name="T">The span type.</typeparam>
    /// <param name="argInfo">The argument info.</param>
    /// <returns>The <paramref name="argInfo"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is empty.</exception>
    public static ref readonly ReadOnlySpanArgInfo<T> NotEmpty<T>( in this ReadOnlySpanArgInfo<T> argInfo ) {

        if( !argInfo.Value.IsEmpty ) {
            return ref argInfo;
        }

        string message = argInfo.Message ?? ExceptionMessages.VALUE_CANNOT_BE_EMPTY;
        throw new ArgumentException( message, argInfo.Name );
    }

    /// <summary>
    /// Ensures an argument has a length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
    /// </summary>
    /// <typeparam name="T">The span type.</typeparam>
    /// <param name="argInfo">The argument info.</param>
    /// <param name="length">The length.</param>
    /// <returns>The <paramref name="argInfo"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> does not equal <paramref name="length"/>.</exception>
    public static ref readonly ReadOnlySpanArgInfo<T> Length<T>( in this ReadOnlySpanArgInfo<T> argInfo, int length ) {

        if( argInfo.Value.Length == length ) {
            return ref argInfo;
        }

        string message = argInfo.Message ??
            ( typeof( T ) != typeof( char )
                ? ExceptionMessageFormatter.Format( ExceptionMessages.VALUE_LENGTH_MUST_BE_EQUAL_TO, argInfo.Value.Length, length )
                : ExceptionMessageFormatter.Format( ExceptionMessages.STRING_LENGTH_MUST_BE_EQUAL_TO, argInfo.Value.ToString(), argInfo.Value.Length, length ) );

        throw new ArgumentOutOfRangeException( argInfo.Name, message );
    }

    /// <summary>
    /// Ensures an argument has a maximum length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
    /// </summary>
    /// <typeparam name="T">The span type.</typeparam>
    /// <param name="argInfo">The argument info.</param>
    /// <param name="length">The maximum length.</param>
    /// <returns>The <paramref name="argInfo"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> greater than <paramref name="length"/>.</exception>
    public static ref readonly ReadOnlySpanArgInfo<T> MaxLength<T>( in this ReadOnlySpanArgInfo<T> argInfo, int length ) {

        if( argInfo.Value.Length <= length ) {
            return ref argInfo;
        }

        string message = argInfo.Message ??
            ( typeof( T ) != typeof( char )
                ? ExceptionMessageFormatter.Format( ExceptionMessages.VALUE_LENGTH_EXCEEDS_MAX_LENGTH, argInfo.Value.Length, length )
                : ExceptionMessageFormatter.Format( ExceptionMessages.STRING_LENGTH_EXCEEDS_MAX_LENGTH, argInfo.Value.ToString(), argInfo.Value.Length, length ) );

        throw new ArgumentOutOfRangeException( argInfo.Name, message );
    }

    /// <summary>
    /// Ensures an argument has a minium length of <paramref name="length"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
    /// </summary>
    /// <typeparam name="T">The span type.</typeparam>
    /// <param name="argInfo">The argument info.</param>
    /// <param name="length">The minium length.</param>
    /// <returns>The <paramref name="argInfo"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> less than <paramref name="length"/>.</exception>
    public static ref readonly ReadOnlySpanArgInfo<T> MinLength<T>( in this ReadOnlySpanArgInfo<T> argInfo, int length ) {

        if( argInfo.Value.Length >= length ) {
            return ref argInfo;
        }

        string message = argInfo.Message ??
            ( typeof( T ) != typeof( char )
                ? ExceptionMessageFormatter.Format( ExceptionMessages.VALUE_LENGTH_BELOW_MIN_LENGTH, argInfo.Value.Length, length )
                : ExceptionMessageFormatter.Format( ExceptionMessages.STRING_LENGTH_BELOW_MIN_LENGTH, argInfo.Value.ToString(), argInfo.Value.Length, length ) );

        throw new ArgumentOutOfRangeException( argInfo.Name, message );
    }

    /// <summary>
    /// Ensures an argument has a length inclusively between <paramref name="minLength"/> and <paramref name="maxLength"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
    /// </summary>
    /// <typeparam name="T">The span type.</typeparam>
    /// <param name="argInfo">The argument info.</param>
    /// <param name="minLength">The miniumum length.</param>
    /// <param name="maxLength">The maximum length.</param>
    /// <returns>The <paramref name="argInfo"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the length of <paramref name="argInfo.Value"/> is not between <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
    public static ref readonly ReadOnlySpanArgInfo<T> LengthBetween<T>( in this ReadOnlySpanArgInfo<T> argInfo, int minLength, int maxLength ) {

        if( argInfo.Value.Length >= minLength && argInfo.Value.Length <= maxLength ) {
            return ref argInfo;
        }

        string message = argInfo.Message ??
            ( typeof( T ) != typeof( char )
                ? ExceptionMessageFormatter.Format( ExceptionMessages.VALUE_LENGTH_MUST_BE_BETWEEN, argInfo.Value.Length, minLength, maxLength )
                : ExceptionMessageFormatter.Format( ExceptionMessages.STRING_LENGTH_MUST_BE_BETWEEN, argInfo.Value.ToString(), argInfo.Value.Length, minLength, maxLength ) );

        throw new ArgumentOutOfRangeException( argInfo.Name, message );
    }
}

#endif
