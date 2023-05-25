using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

#if NET7_0_OR_GREATER

/// <summary>
/// Extension methods for validating <see cref="decimal"/> arguments.
/// </summary>
public static class DecimalExtensions {

	/// <summary>
	/// Ensures an argument has a scale equal to <paramref name="scale"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="scale">The expected scale.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the scale of <paramref name="argInfo.Value"/> does not equal to <paramref name="scale"/>..</exception>
	public static ref readonly ArgInfo<decimal> ScaleEqualTo( in this ArgInfo<decimal> argInfo, byte scale ) {

		if( argInfo.Value.Scale == scale ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_HAVE_SCALE_EQUAL_TO, argInfo.Value.ToString( CultureInfo.InvariantCulture ), scale.ToString( CultureInfo.InvariantCulture ) );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}

	/// <summary>
	/// Ensures an argument has a scale less than or equal to <paramref name="scale"/>, otherwise an <see cref="ArgumentOutOfRangeException"/> is thrown.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="scale">The expected scale.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when the scale of <paramref name="argInfo.Value"/> is not less than or equal to <paramref name="scale"/>..</exception>
	public static ref readonly ArgInfo<decimal> ScaleLessThanOrEqualTo( in this ArgInfo<decimal> argInfo, byte scale ) {

		if( argInfo.Value.Scale <= scale ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_HAVE_SCALE_LESS_THAN_OR_EQUAL_TO, argInfo.Value.ToString( CultureInfo.InvariantCulture ), scale.ToString( CultureInfo.InvariantCulture ) );
		throw new ArgumentOutOfRangeException( argInfo.Name, message );
	}
}

#endif
