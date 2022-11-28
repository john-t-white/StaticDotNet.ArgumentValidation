using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullTrueBenchmarks {

	public bool? value = true;

	[Benchmark( Baseline = true )]
	public bool Baseline() => this.value == null ? throw new ArgumentNullException( nameof( this.value ) ) : this.value.Value ? true : throw new ArgumentException( "Value must be true.", nameof( this.value ) );

	[Benchmark]
	public bool Argument_Is() => Arg.Is.NotNullTrue( this.value );

	[Benchmark]
	public bool Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().True();
}