using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
[SimpleJob( RuntimeMoniker.NetCoreApp31 )]
[SimpleJob( RuntimeMoniker.Net481 )]
public class IsNotNull_AssignableTo {

	public Type? argumentValue = typeof( int[] );

	[Benchmark( Baseline = true )]
	public Type Baseline() {

#if NET6_0_OR_GREATER
		ArgumentNullException.ThrowIfNull( argumentValue );
#else
		if( argumentValue == null ) {
			throw new ArgumentNullException( nameof( argumentValue ) );
		}
#endif

		return typeof( IList<int> ).IsAssignableFrom( argumentValue ) ? typeof( IList<int> ) : throw new ArgumentException( nameof( argumentValue ) );
	}

	[Benchmark]
	public Type ArgumentValidation() => Arg.IsNotNull( argumentValue ).AssignableTo<IList<int>>().Value;

	[Benchmark]
	public Type Ensure_That() {
		Ensure.That( argumentValue ).IsNotNull();
		Ensure.ThatType( argumentValue ).IsAssignableToType( typeof( IList<int> ) );

#pragma warning disable CS8603 // Possible null reference return.
		return argumentValue;
#pragma warning restore CS8603 // Possible null reference return.
	}
}