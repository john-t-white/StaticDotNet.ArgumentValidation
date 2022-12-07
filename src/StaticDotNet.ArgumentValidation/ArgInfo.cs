using System.Collections;
using System.Runtime.InteropServices;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// General argument information used when validating.
/// </summary>
/// <typeparam name="T">The type of <see cref="Value"/>.</typeparam>
[StructLayout( LayoutKind.Auto )]
public readonly ref struct ArgInfo<T> {

    /// <summary>
    /// Instantiates an instance of <see cref="ArgInfo{T}"/>.
    /// </summary>
    /// <param name="value">The value of the argument.</param>
    /// <param name="name">The name of the argument.</param>
    /// <param name="message">The exception message.  Null for for default message.</param>
    public ArgInfo( T value, string? name, string? message ) {

        Value = value;
        Name = name;
        Message = message;
        ValueAsString = value as string;
    }

	/// <summary>
	/// Returns the value of the argument.
	/// </summary>
	public readonly T Value { get; }

	/// <summary>
	/// Provides direct access to the <typeparamref name="T"/> if it is a string to avoid casting/converting, otherwise null.
	/// </summary>
	public readonly string? ValueAsString { get; }

	/// <summary>
	/// Returns the name of the argument.
	/// </summary>
	public readonly string? Name { get; }

	/// <summary>
	/// Returns the exception message. If this is null, the default exception message should b used.
	/// </summary>
	public readonly string? Message { get; }
}
