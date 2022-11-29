using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class TrueBenchmarks {

	public bool value = true;

	[Benchmark( Baseline = true )]
	public bool Baseline() => this.value ? true : throw new ArgumentException( "Value must be true.", nameof( this.value ) );

	[Benchmark]
	public bool Arg_Is() => Arg.Is.True( this.value );

	[Benchmark]
	public bool Dawn_Guard() => Dawn.Guard.Argument( this.value ).True();

	[Benchmark]
	public bool Ensure_That() {

		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsTrue();

		return this.value;
	}
}