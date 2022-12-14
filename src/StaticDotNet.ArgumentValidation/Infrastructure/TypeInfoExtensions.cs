#if NETSTANDARD2_0_OR_GREATER

namespace System.Reflection;

internal static class TypeInfoExtensions {

	public static bool IsAssignableTo( this TypeInfo typeInfo, Type type )
		=> type.IsAssignableFrom( typeInfo );
}

#endif
