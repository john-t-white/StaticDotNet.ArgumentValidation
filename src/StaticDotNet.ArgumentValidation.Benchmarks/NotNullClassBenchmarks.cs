using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullClassBenchmarks {

	public object value = new();

	[Benchmark( Baseline = true )]
	public object Baseline() => this.value ?? throw new ArgumentNullException( nameof( this.value ) );

	[Benchmark]
	public object Arg_Is() => Arg.Is.NotNull( this.value );

	[Benchmark]
	public object Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull();

	[Benchmark]
	public object Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.Null( this.value );
}