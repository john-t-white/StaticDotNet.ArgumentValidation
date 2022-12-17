using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="char"/> arguments.
/// </summary>
public static class CharExtensions {

	/// <summary>
	/// Ensures an argument is not white space, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is white space.</exception>
	public static ref readonly ArgInfo<char> NotWhiteSpace( in this ArgInfo<char> argInfo ) {

		if( !char.IsWhiteSpace( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_CANNOT_BE_WHITE_SPACE;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is a digit, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not a digit.</exception>
	public static ref readonly ArgInfo<char> Digit( in this ArgInfo<char> argInfo ) {

		if( char.IsDigit( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_DIGIT;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is a letter, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not a letter.</exception>
	public static ref readonly ArgInfo<char> Letter( in this ArgInfo<char> argInfo ) {

		if( char.IsLetter( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_LETTER;
		throw new ArgumentException( message, argInfo.Name );
	}
}
