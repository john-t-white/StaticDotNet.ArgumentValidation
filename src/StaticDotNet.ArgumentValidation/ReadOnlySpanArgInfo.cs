#if NET6_0_OR_GREATER

using System.Globalization;
using System.Runtime.InteropServices;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// General argument information used when validating.
/// </summary>
/// <typeparam name="T">The type of <see cref="Value"/>.</typeparam>
[StructLayout( LayoutKind.Auto )]
public readonly ref struct ReadOnlySpanArgInfo<T>
	where T : notnull {

	/// <summary>
	/// Instantiates an instance of <see cref="ArgInfo{T}"/>.
	/// </summary>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">The name of the argument.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	public ReadOnlySpanArgInfo( ReadOnlySpan<T> value, string? name, string? message ) {

		Value = value;
		Name = name;
		Message = message;
	}

	/// <summary>
	/// Returns the value of the argument.
	/// </summary>
	public readonly ReadOnlySpan<T> Value { get; }

	/// <summary>
	/// Returns the name of the argument.
	/// </summary>
	public readonly string? Name { get; }

	/// <summary>
	/// Returns the exception message. If this is null, the default exception message should be used.
	/// </summary>
	public readonly string? Message { get; }
}

#endif
