using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="char"/> arguments.
/// </summary>
public static class CharExtensions {

	public static ref readonly ArgInfo<char> NotWhiteSpace( in this ArgInfo<char> argInfo ) {

		if( !char.IsWhiteSpace( argInfo.Value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_CANNOT_BE_WHITE_SPACE;
		throw new ArgumentException( message, argInfo.Name );
	}
}
