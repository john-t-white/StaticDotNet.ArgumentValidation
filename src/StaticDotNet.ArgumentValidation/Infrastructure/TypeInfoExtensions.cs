#if( NETSTANDARD2_0 || NETSTANDARD2_1 )

namespace System.Reflection;

internal static class TypeInfoExtensions {

	public static bool IsAssignableTo( this TypeInfo typeInfo, Type type )
		=> type.IsAssignableFrom( typeInfo );
}

#endif
