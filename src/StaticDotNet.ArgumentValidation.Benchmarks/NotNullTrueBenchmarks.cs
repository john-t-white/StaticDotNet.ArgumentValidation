using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullTrueBenchmarks {

	public bool? value = true;

	[Benchmark( Baseline = true )]
	public bool Baseline() => this.value == null ? throw new ArgumentNullException( nameof( this.value ) ) : this.value.Value ? true : throw new ArgumentException( "Value must be true.", nameof( this.value ) );

	//[Benchmark]
	//public bool Arg_Is() => Arg.Is.NotNullTrue( this.value );

	[Benchmark]
	public bool Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().True();

	[Benchmark]
	public bool Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNull();
		EnsureThat.Ensure.That( this.value!.Value, nameof( this.value ) ).IsTrue();

		return this.value!.Value;
	}
}