#if( NETSTANDARD2_0 || NETSTANDARD2_1 )

#pragma warning disable IDE0130 // Polyfill so don't want namespace to match folder
namespace System.Diagnostics.CodeAnalysis;
#pragma warning restore IDE0130

[AttributeUsage( AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Class, Inherited = false )]
internal sealed class RequiresUnreferencedCodeAttribute( string message )
        : Attribute {
    public string Message { get; } = message;

    public string? Url { get; set; }
}

#endif
