using System.Globalization;
using System.Reflection;

namespace StaticDotNet.ArgumentValidation;

/// <summary>
/// Extension methods for validating <see cref="Type"/> arguments.
/// </summary>
/// <remarks>
/// Since <see cref="string"/> can't be used as a generic constraint <see cref="IEquatable{String}"/>, <see cref="IComparable{String}"/>
/// and <see cref="IEnumerable{Char}"/> are used instead. Generic constraints are specifically used to ensure nullability is passed on.
/// </remarks>
public static class TypeExtensions {

	/// <summary>
	/// Ensures an argument is assignable to <paramref name="type"/>, otherwise an <see cref="ArgumentException"/> is thrown.
	/// </summary>
	/// <typeparam name="T">The argument type.</typeparam>
	/// <param name="argInfo">The argument info.</param>
	/// <param name="type">The type it should be assignable to.</param>
	/// <returns>The <see cref="ArgInfo{T}"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when <paramref name="argInfo.Value"/> is not assignable to <paramref name="type"/>.</exception>

#if NETSTANDARD2_1

	public static ref readonly ArgInfo<T> AssignableTo<T>( in this ArgInfo<T> argInfo, [DisallowNull] T type )
		where T : Type {

		if( type is not null && type.GetTypeInfo().IsAssignableFrom( argInfo.Value.GetTypeInfo() ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_ASSIGNABLE_TO, type?.FullName ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

#else

	public static ref readonly ArgInfo<T> AssignableTo<T>( in this ArgInfo<T> argInfo, [DisallowNull] T type )
		where T : Type {

		if( type is not null && argInfo.Value.GetTypeInfo().IsAssignableTo( type.GetTypeInfo() ) ) {
			return ref argInfo;
		}

		string message = argInfo.Message ?? string.Format( CultureInfo.InvariantCulture, Constants.VALUE_MUST_BE_ASSIGNABLE_TO, type?.FullName ?? Constants.NULL );
		throw new ArgumentException( message, argInfo.Name );
	}

#endif

}
