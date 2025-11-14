#if( NETSTANDARD2_0 || NETSTANDARD2_1 )

#pragma warning disable IDE0130 // Polyfill so don't want namespace to match folder
namespace System.Reflection;
#pragma warning restore IDE0130 //

internal static class TypeInfoExtensions {

    public static bool IsAssignableTo( this TypeInfo typeInfo, Type type )
        => type.IsAssignableFrom( typeInfo );
}

#endif
