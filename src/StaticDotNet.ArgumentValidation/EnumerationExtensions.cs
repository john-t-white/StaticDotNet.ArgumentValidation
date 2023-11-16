using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating enumeration arguments.
/// </summary>
public static class EnumerationExtensions {

	/// <summary>
	/// Ensures an argument is a defined enumeration value for <typeparamref name="T"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The type of enumeration.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not defined for <typeparamref name="T"/>.</exception>
	public static ref readonly ArgInfo<T> Defined<T>( in this ArgInfo<T> argInfo )
		where T : struct, Enum {

#if NET6_0_OR_GREATER
		if( Enum.IsDefined( argInfo.Value ) ) {
			return ref argInfo;
		}
#else
		if( Enum.IsDefined( typeof( T ), argInfo.Value ) ) {
			return ref argInfo;
		}
#endif
		string message = argInfo.Message ?? ExceptionMessages.VALUE_NOT_DEFINED;
		throw new ArgumentException( message, argInfo.Name );
	}
}
