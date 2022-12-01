using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_Class {

	public object? value = new();

	[Benchmark( Baseline = true )]
	public object Baseline() => this.value ?? throw new ArgumentNullException( nameof( this.value ) );

	[Benchmark]
	public object Arg_IsNotNull() => Arg.IsNotNull( this.value ).Value;

	[Benchmark]
	public object Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull();

	[Benchmark]
	public object Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.Null( this.value );

	[Benchmark]
	public object Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNull();

		return this.value;
	}
}