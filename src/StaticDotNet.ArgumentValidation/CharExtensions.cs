using System;
using System.Collections.Generic;
using System.Globalization;
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

		string message = argInfo.Message ?? ExceptionMessages.VALUE_CANNOT_BE_WHITE_SPACE;
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

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_DIGIT, argInfo.Value.ToString() );
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

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_LETTER, argInfo.Value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is a letter or digit, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not a letter or digit.</exception>
	public static ref readonly ArgInfo<char> LetterOrDigit( in this ArgInfo<char> argInfo ) {

		if( char.IsLetterOrDigit( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_LETTER_OR_DIGIT, argInfo.Value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is a letter, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not a letter.</exception>
	public static ref readonly ArgInfo<char> Number( in this ArgInfo<char> argInfo ) {

		if( char.IsNumber( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_NUMBER, argInfo.Value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is lower case, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not lower case.</exception>
	public static ref readonly ArgInfo<char> Lower( in this ArgInfo<char> argInfo ) {

		if( char.IsLower( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_LOWER, argInfo.Value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is a upper case, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not upper case.</exception>
	public static ref readonly ArgInfo<char> Upper( in this ArgInfo<char> argInfo ) {

		if( char.IsUpper( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_UPPER, argInfo.Value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

#if NET7_0_OR_GREATER

	/// <summary>
	/// Ensures an argument is an ASCII digit, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not an ASCII digit.</exception>
	public static ref readonly ArgInfo<char> AsciiDigit( in this ArgInfo<char> argInfo ) {

		if( char.IsAsciiDigit( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_ASCII_DIGIT, argInfo.Value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is an ASCII letter, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not an ASCII letter.</exception>
	public static ref readonly ArgInfo<char> AsciiLetter( in this ArgInfo<char> argInfo ) {

		if( char.IsAsciiLetter( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_ASCII_LETTER, argInfo.Value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is an ASCII letter or digit, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not an ASCII letter or digit.</exception>
	public static ref readonly ArgInfo<char> AsciiLetterOrDigit( in this ArgInfo<char> argInfo ) {

		if( char.IsAsciiLetterOrDigit( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_ASCII_LETTER_OR_DIGIT, argInfo.Value.ToString() );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif
}
