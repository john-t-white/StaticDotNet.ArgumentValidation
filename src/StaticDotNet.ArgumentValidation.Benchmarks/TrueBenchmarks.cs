using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class TrueBenchmarks {

	public bool value = true;

	[Benchmark( Baseline = true )]
	public bool Baseline() => this.value ? true : throw new ArgumentException( "Value must be true.", nameof( this.value ) );

	[Benchmark]
	public bool Argument_Is() => Arg.Is.True( this.value );

	[Benchmark]
	public bool Dawn_Guard() => Dawn.Guard.Argument( this.value ).True();
}