using StaticDotNet.ArgumentValidation.Infrastructure;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="IComparable"/> arguments.
/// </summary>
public static class ObjectExtensions {

	/// <summary>
	/// Ensures an argument is equal to <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <param name="comparer">The comparer.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not equal <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<TArg> EqualTo<TArg>( in this ArgInfo<TArg> argInfo, TArg value, IEqualityComparer<TArg>? comparer = null )
		where TArg : notnull {

		if( ( comparer ?? EqualityComparer<TArg>.Default ).Equals( argInfo.Value, value ) ) {
			return ref argInfo;
		}

#if NET8_0_OR_GREATER
		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessagesCompositeFormats.VALUE_MUST_BE_EQUAL_TO, Stringify.Value( argInfo.Value ), Stringify.Value( value ) );
#else
		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, ExceptionMessages.VALUE_MUST_BE_EQUAL_TO, Stringify.Value( argInfo.Value ), Stringify.Value( value ) );
#endif

		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is the same as <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not the same as <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<TArg> Same<TArg>( in this ArgInfo<TArg> argInfo, TArg value )
		where TArg : notnull {

		if( ReferenceEquals( argInfo.Value, value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? ExceptionMessages.VALUE_MUST_BE_SAME;
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is not the same as <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TArg">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <returns>The <paramref name="argInfo"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is the same as <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<TArg> NotSame<TArg>( in this ArgInfo<TArg> argInfo, TArg value )
		where TArg : notnull {

		if( !ReferenceEquals( argInfo.Value, value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? ExceptionMessages.VALUE_MUST_NOT_BE_SAME;
		throw new ArgumentException( message, argInfo.Name );
	}
}
