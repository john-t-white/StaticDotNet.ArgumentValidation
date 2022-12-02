﻿#if !NET5_0_OR_GREATER

namespace System.Runtime.CompilerServices;

[AttributeUsage( AttributeTargets.Parameter, AllowMultiple = false, Inherited = false )]
internal sealed class CallerArgumentExpressionAttribute : Attribute {

	public CallerArgumentExpressionAttribute( string? parameterName ) {
		this.ParameterName = parameterName;
	}

	public string? ParameterName { get; }
}

#endif