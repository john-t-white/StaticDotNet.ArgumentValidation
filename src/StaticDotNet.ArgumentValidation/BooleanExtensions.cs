using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="bool"/> arguments.
/// </summary>
public static class BooleanExtensions {

	/// <summary>
	/// Ensures an argument is true, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not true.</exception>
	public static ref readonly ArgInfo<bool> True( in this ArgInfo<bool> argInfo ) {

		if( argInfo.Value ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_TRUE;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is false, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not false.</exception>
	public static ref readonly ArgInfo<bool> False( in this ArgInfo<bool> argInfo ) {

		if( !argInfo.Value ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_FALSE;
		throw new ArgumentException( message, argInfo.Name );
	}
}
