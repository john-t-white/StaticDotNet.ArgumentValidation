#if NET6_0_OR_GREATER

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

		throw new ArgumentException( argInfo.Message ?? Constants.VALUE_CANNOT_BE_WHITE_SPACE, argInfo.Name );
	}
}

#endif
