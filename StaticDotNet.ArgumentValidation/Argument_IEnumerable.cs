using System.Collections;
using System.Xml.Linq;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Validation methods for <see cref="string"/>.
/// </summary>
public static class Argument_IEnumerable {

	/// <summary>
	/// Validates <paramref name="value"/> is not null or empty, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="argument">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
	public static T NotNullOrEmpty<T>( this Argument argument, [NotNull] T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : IEnumerable {

		_ = argument.NotNull( value, name, message );

		return ValidateIfEmpty( value, name, message );
	}

	/// <summary>
	/// Validates <paramref name="value"/> is null or empty, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <param name="_">The <see cref="Argument"/>.</param>
	/// <param name="value">The value of the argument.</param>
	/// <param name="name">With C# 10, defaults to the expression of <paramref name="value"/>; otherwise specify the argument name.</param>
	/// <param name="message">The exception message.  Null for for default message.</param>
	/// <returns>Returns <paramref name="value"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
	[return: NotNullIfNotNull( nameof( value ) )]
	public static T? NotEmpty<T>( this Argument _, T? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		where T : IEnumerable
		=> value == null
			? value
			: ValidateIfEmpty( value, name, message );

	private static T ValidateIfEmpty<T>( T value, string? name, string? message = null )
		where T : IEnumerable
			=> value switch {

				Array arrayValue => arrayValue.Length == 0
					? throw new ArgumentException( message ?? Constants.VALUE_CANNOT_BE_EMPTY, name )
					: value,

				IList listValue => listValue.Count == 0
					? throw new ArgumentException( message ?? Constants.VALUE_CANNOT_BE_EMPTY, name )
					: value,

				ICollection collectionValue => collectionValue.Count == 0
					? throw new ArgumentException( message ?? Constants.VALUE_CANNOT_BE_EMPTY, name )
					: value,

				_ => !value.GetEnumerator().MoveNext()
					? throw new ArgumentException( message ?? Constants.VALUE_CANNOT_BE_EMPTY, name )
					: value
			};
}
