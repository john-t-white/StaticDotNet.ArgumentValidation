using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDotNet.ArgumentValidation.Infrastructure;

/// <summary>
/// Utility class to return a string version of a value for exception messages.
/// </summary>
public static class Stringify {

	/// <summary>
	/// Returns a string version of the value.
	/// </summary>
	/// <typeparam name="T">The type of value.</typeparam>
	/// <param name="value">The value.</param>
	/// <returns>string/char values with quotes, null values as &lt;null&gt;, otherwise the value as a string.</returns>
	public static string Value<T>( T? value ) => value is null
			? Constants.NULL
			: value is string or char
				? $"\"{value}\""
				: value.ToString() ?? string.Empty;

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER

	/// <summary>
	/// Returns a string version of the value.
	/// </summary>
	/// <typeparam name="T">The type of value.</typeparam>
	/// <param name="value">The value.</param>
	/// <returns>string/char values with quotes, otherwise the value as a string.</returns>
	public static string Value<T>( ReadOnlySpan<T> value ) => Value( value.ToString() );

	/// <summary>
	/// Returns a string version of the value.
	/// </summary>
	/// <typeparam name="T">The type of value.</typeparam>
	/// <param name="value">The value.</param>
	/// <returns>string/char values with quotes, otherwise the value as a string.</returns>
	public static string Value<T>( Span<T> value ) => Value( value.ToString() );

#endif

}