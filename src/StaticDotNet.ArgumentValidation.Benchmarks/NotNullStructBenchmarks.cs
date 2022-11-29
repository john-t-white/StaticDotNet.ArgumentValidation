using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullStructBenchmarks {

	public int? value = new();

	[Benchmark( Baseline = true )]
	public int Baseline() => this.value ?? throw new ArgumentNullException( nameof( this.value ) );

	[Benchmark]
	public int Arg_Is() => Arg.Is.NotNull( this.value );

	[Benchmark]
	public int Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull();

	[Benchmark]
	public int Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.Null( this.value )!.Value;

	[Benchmark]
	public int Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNull();

		return this.value!.Value;
	}
}