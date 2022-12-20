using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="DateTime"/> arguments.
/// </summary>
public static class DateTimeExtensions {

	/// <summary>
	/// Ensures an argument is <see cref="DateTimeKind.Utc"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> kind is not <see cref="DateTimeKind.Utc"/>.</exception>
	public static ref readonly ArgInfo<DateTime> Utc( in this ArgInfo<DateTime> argInfo ) {

		if( argInfo.Value.Kind == DateTimeKind.Utc ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_HAVE_DATETIMEKIND_UTC;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is <see cref="DateTimeKind.Local"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> kind is not <see cref="DateTimeKind.Local"/>.</exception>
	public static ref readonly ArgInfo<DateTime> Local( in this ArgInfo<DateTime> argInfo ) {

		if( argInfo.Value.Kind == DateTimeKind.Local ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_HAVE_DATETIMEKIND_LOCAL;
		throw new ArgumentException( message, argInfo.Name );
	}
}
