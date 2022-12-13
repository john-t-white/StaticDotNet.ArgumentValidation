using System.Globalization;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="string"/> arguments.
/// </summary>
/// <remarks>
/// Since <see cref="string"/> can't be used as a generic constraint <see cref="IEquatable{String}"/>, <see cref="IComparable{String}"/>
/// and <see cref="IEnumerable{Char}"/> are used instead. Generic constraints are specifically used to ensure nullability is passed on.
/// </remarks>
public static class StringExtensions {

	/// <summary>
	/// Ensures an argument is not white space, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is white space.</exception>
	public static ref readonly ArgInfo<T> NotWhiteSpace<T>( in this ArgInfo<T> argInfo )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null ) {
			return ref argInfo;
		}

		for( int i = 0; i < argInfo.ValueAsString.Length; i++ ) {
			if( !char.IsWhiteSpace( argInfo.ValueAsString[ i ] ) ) {
				return ref argInfo;
			}
		}

		throw new ArgumentException( argInfo.Message ?? Constants.VALUE_CANNOT_BE_WHITE_SPACE, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is equal to <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to compare against.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not equal <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<T> EqualTo<T>( in this ArgInfo<T> argInfo, string value, StringComparison comparisonType )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || GetStringComparer( comparisonType ).Equals( argInfo.ValueAsString, value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_EQUAL_TO, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument starts with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should start with.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<T> StartsWith<T>( in this ArgInfo<T> argInfo, string value, StringComparison comparisonType )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || argInfo.ValueAsString.StartsWith( value, comparisonType ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_START_WITH, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument ends with <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value to it should end with.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not start with <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<T> EndsWith<T>( in this ArgInfo<T> argInfo, string value, StringComparison comparisonType )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || argInfo.ValueAsString.EndsWith( value, comparisonType ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_END_WITH, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not contain <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<T> Contains<T>( in this ArgInfo<T> argInfo, string value )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || argInfo.ValueAsString.Contains(value ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_CONTAIN, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument contains <paramref name="value"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="value">The value it should contain.</param>
	/// <param name="comparisonType">The type of comparison.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not contain <paramref name="value"/>.</exception>
	public static ref readonly ArgInfo<T> Contains<T>( in this ArgInfo<T> argInfo, string value, StringComparison comparisonType )
		where T : IEquatable<string>?, IComparable<string>?, IEnumerable<char>? {

		if( argInfo.ValueAsString is null || argInfo.ValueAsString.Contains( value, comparisonType ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_CONTAIN, value?.ToString() ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

	/// <summary>
	/// Ensures an argument is not null and represents a <see cref="Type"/>, otherwise an <see cref="ArgumentNullException"/> or <see cref="ArgumentException"/> is thrown. Due to how nullability annotations work, use
	/// <see cref="StringExtensions.ToTypeMaybeNull(in ArgInfo{string})"/> if the argument could be null as there is no way to annotate whether the result could be null or not.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <see cref="Type"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="argInfo.Value"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="Type"/>.</exception>
	[RequiresUnreferencedCode( "The type might be removed." )]
	public static ArgInfo<Type> ToType( in this ArgInfo<string> argInfo ) {

		Exception? thrownException = null;
		if( argInfo.ValueAsString is not null ) {
			Type? type;
			try {
				type = Type.GetType( argInfo.ValueAsString, true );

				// Nullabiliy ignored as per the Type.GetType documentation, throwOnError true will always throw an exception if the type isn't found.
				return new( type!, argInfo.Name, argInfo.Message );
			} catch( Exception exception ) {
				thrownException = exception;
			}
		}

		string message = argInfo.Message ?? Constants.VALUE_MUST_BE_NOT_NULL_VALID_TYPE;

		if( thrownException is not null ) {

			message += $" {Constants.SEE_INNER_EXCEPTION_FOR_DETAILS}";
		}

		throw ( argInfo.Value is null ) ? ArgumentNullExceptionFactory.Create( argInfo.Name, message ) : new ArgumentException( message, argInfo.Name, thrownException );
	}

	/// <summary>
	/// Ensures an argument represents a <see cref="Type"/>, otherwise an <see cref="ArgumentException"/> is thrown. Due to how nullability annotations work, use
	/// <see cref="StringExtensions.ToType(in ArgInfo{string})"/> if the argument is not null as there is no way to annotate whether the result could be null or not.
	/// </summary>
	/// <param name="argInfo">The argument info.</param>
	/// <returns>The <see cref="Type"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> does not represent a <see cref="Type"/>.</exception>
	[RequiresUnreferencedCode( "The type might be removed." )]
	public static ArgInfo<Type?> ToTypeMaybeNull( in this ArgInfo<string?> argInfo ) {

		if( argInfo.ValueAsString is null ) {
			return new( null, argInfo.Name, argInfo.Message );
		}

		Type? type;
		try {
			type = Type.GetType( argInfo.ValueAsString, true );
			return new( type, argInfo.Name, argInfo.Message );
		} catch( Exception exception ) {

			string message = $"{argInfo.Message ?? Constants.VALUE_MUST_BE_VALID_TYPE} {Constants.SEE_INNER_EXCEPTION_FOR_DETAILS}";
			throw new ArgumentException( message, argInfo.Name, exception );
		}
	}

	#region Internal Methods

#if NETSTANDARD2_0

	private static StringComparer GetStringComparer( StringComparison comparisonType )
		=> comparisonType switch {
			StringComparison.CurrentCulture => StringComparer.CurrentCulture,

			StringComparison.CurrentCultureIgnoreCase => StringComparer.CurrentCultureIgnoreCase,

			StringComparison.InvariantCulture => StringComparer.InvariantCulture,

			StringComparison.InvariantCultureIgnoreCase => StringComparer.InvariantCultureIgnoreCase,

			StringComparison.Ordinal => StringComparer.Ordinal,

			StringComparison.OrdinalIgnoreCase => StringComparer.OrdinalIgnoreCase,

			_ => throw new InvalidOperationException( "Comparison type not supported." )
		};

#else

	private static StringComparer GetStringComparer( StringComparison comparisonType ) => StringComparer.FromComparison( comparisonType );

#endif

	#endregion
}
