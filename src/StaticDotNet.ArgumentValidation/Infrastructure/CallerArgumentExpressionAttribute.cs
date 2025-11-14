#if( NETSTANDARD2_0 || NETSTANDARD2_1 )

#pragma warning disable IDE0130 // Polyfill so don't want namespace to match folder
namespace System.Runtime.CompilerServices;
#pragma warning restore IDE0130

[ExcludeFromCodeCoverage] // Excluded as this is a polyfill
[AttributeUsage( AttributeTargets.Parameter, AllowMultiple = false, Inherited = false )]
internal sealed class CallerArgumentExpressionAttribute( string? parameterName ) : Attribute {
    public string? ParameterName { get; } = parameterName;
}

#endif