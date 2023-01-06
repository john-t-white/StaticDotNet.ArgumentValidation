using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="Stream"/> arguments.
/// </summary>
public static class StreamExtensions {

	/// <summary>
	/// Ensures a stream argument is readable, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not readable.</exception>
	public static ref readonly ArgInfo<TArg> Readable<TArg>( in this ArgInfo<TArg> argInfo )
		where TArg: Stream {

		if( argInfo.Value.CanRead ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? ExceptionMessages.VALUE_MUST_BE_READABLE;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures a stream argument is writable, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not writable.</exception>
	public static ref readonly ArgInfo<TArg> Writable<TArg>( in this ArgInfo<TArg> argInfo )
		where TArg : Stream {

		if( argInfo.Value.CanWrite ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? ExceptionMessages.VALUE_MUST_BE_WRITABLE;
		throw new ArgumentException( message, argInfo.Name );
	}
}
