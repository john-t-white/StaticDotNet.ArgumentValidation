using EnsureThat;
using System.Reflection;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
[SimpleJob( RuntimeMoniker.NetCoreApp31 )]
public class IsNotNull_AssignableTo_TypeInfo {

	public TypeInfo? argumentValue = typeof( int[] ).GetTypeInfo();
	public TypeInfo value = typeof( IList<int> ).GetTypeInfo();

	[Benchmark( Baseline = true )]
	public Type Baseline() {

#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull( argumentValue );
#else
		if( argumentValue == null ) {
			throw new ArgumentNullException( nameof( argumentValue ) );
		}
#endif

		return value.IsAssignableFrom( argumentValue ) ? value : throw new ArgumentException( nameof( value ) );
	}

	[Benchmark]
	public Type ArgumentValidation() => Arg.IsNotNull( argumentValue ).AssignableTo( value ).Value;

	[Benchmark]
	public Type Ensure_That() {
		Ensure.That( argumentValue ).IsNotNull();
		Ensure.ThatType( argumentValue ).IsAssignableToType( value );

#pragma warning disable CS8603 // Possible null reference return.
		return argumentValue;
#pragma warning restore CS8603 // Possible null reference return.
	}
}