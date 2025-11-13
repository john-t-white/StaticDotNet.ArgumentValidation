#if( NETSTANDARD2_0 || NETSTANDARD2_1 )

namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage( AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Class, Inherited = false )]
internal sealed class RequiresUnreferencedCodeAttribute
	: Attribute {

	public RequiresUnreferencedCodeAttribute( string message ) {
		Message = message;
	}

	public string Message { get; }

	public string? Url { get; set; }
}

#endif
