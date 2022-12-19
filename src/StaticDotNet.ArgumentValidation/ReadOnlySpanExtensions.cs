#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="ReadOnlySpan{T}"/> arguments.
/// </summary>
public static class ReadOnlySpanExtensions {

	/// <summary>
	/// Ensures an argument is not white space, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is white space.</exception>
	public static ref readonly ReadOnlySpanArgInfo<char> NotWhiteSpace( in this ReadOnlySpanArgInfo<char> argInfo ) {

		for( int i = 0; i < argInfo.Value.Length; i++ ) {
			if( !char.IsWhiteSpace( argInfo.Value[ i ] ) ) {
				return ref argInfo;
			}
		}

		string message = argInfo.Message ?? Constants.VALUE_CANNOT_BE_WHITE_SPACE;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is not empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is empty.</exception>
	public static ref readonly ReadOnlySpanArgInfo<T> NotEmpty<T>( in this ReadOnlySpanArgInfo<T> argInfo ) {

		if( !argInfo.Value.IsEmpty ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_CANNOT_BE_EMPTY;
		throw new ArgumentException( message, argInfo.Name );
	}

#if NET7_0_OR_GREATER

	/// <summary>
	/// Ensures an argument is parsable to a <typeparamref name="T"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	///  <param name="provider">The <see cref="IFormatProvider"/>.</param>
	/// <returns>A new <typeparamref name="T"/> <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not parsable to a <typeparamref name="T"/>.</exception>
	public static ArgInfo<T> Parse<T>( in this ReadOnlySpanArgInfo<char> argInfo, IFormatProvider? provider = null )
		where T : ISpanParsable<T> {

		if( T.TryParse( argInfo.Value, provider, out T? result ) ) {
			return new( result, argInfo.Name, argInfo.Message );
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_PARSABLE_TO, typeof( T ).FullName );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif
}

#endif
