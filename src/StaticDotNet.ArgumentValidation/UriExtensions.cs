using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="Uri"/> arguments.
/// </summary>
public static class UriExtensions {

	/// <summary>
	/// Ensures an argument is an absolute <see cref="Uri"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument Type.</typeparam>
	/// <param name="argInfo">The argument information.</param>
	/// <param name="scheme">The expected scheme if not null.</param>
	/// <returns>The <paramref name="argInfo"/></returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not an absolute <see cref="Uri"/>.</exception>
	public static ref readonly ArgInfo<T> Absolute<T>( in this ArgInfo<T> argInfo, string? scheme = null )
		where T : Uri {

		if( argInfo.Value.IsAbsoluteUri && ( scheme is null || StringComparer.OrdinalIgnoreCase.Equals( scheme, argInfo.Value.Scheme ) ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? ( scheme is not null
												? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_ABSOLUTE_WITH_SCHEME, scheme )
												: Constants.VALUE_MUST_BE_ABSOLUTE );

		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is a relative <see cref="Uri"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument Type.</typeparam>
	/// <param name="argInfo">The argument information.</param>
	/// <returns>The <paramref name="argInfo"/></returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not a relative <see cref="Uri"/>.</exception>
	public static ref readonly ArgInfo<T> Relative<T>( in this ArgInfo<T> argInfo )
		where T : Uri {

		if( !argInfo.Value.IsAbsoluteUri ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_RELATIVE;
		throw new ArgumentException( message, argInfo.Name );
	}
}
