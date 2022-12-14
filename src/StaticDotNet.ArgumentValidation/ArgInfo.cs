using System.Globalization;
using System.Runtime.InteropServices;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// General argument information used when validating.
/// </summary>
/// <typeparam name="T">The type of <see cref="Value"/>.</typeparam>
[StructLayout( LayoutKind.Auto )]
public readonly ref struct ArgInfo<T>
	where T : notnull {

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
	}

	/// <summary>
	/// Returns the value of the argument.
	/// </summary>
	public readonly T Value { get; }

	/// <summary>
	/// Returns the name of the argument.
	/// </summary>
	public readonly string? Name { get; }

	/// <summary>
	/// Returns the exception message. If this is null, the default exception message should b used.
	/// </summary>
	public readonly string? Message { get; }

	/// <summary>
	/// Casts an argument to the type <typeparamref name="TType"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="TType">The type to cast to.</typeparam>
	/// <returns>An <see cref="ArgInfo{TType}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <see cref="Value"/> is not able to be cast to <typeparamref name="TType"/>.</exception>
	public ArgInfo<TType> As<TType>()
		where TType : notnull {

		if( Value is TType asValue) {
			return new( asValue, Name, Message );
		}

		string message = Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_ASSIGNABLE_TO, typeof(TType).FullName ?? Constants.NULL );
		throw new ArgumentException( message, Name );
	}
}
