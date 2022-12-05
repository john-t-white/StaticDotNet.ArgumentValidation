using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_Struct {

	public int? value = new();

	[Benchmark( Baseline = true )]
	public int Baseline() => value ?? throw new ArgumentNullException( nameof( value ) );

	[Benchmark]
	public int Arg_IsNotNull() => Arg.IsNotNull( value ).Value;

	[Benchmark]
	public int Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull();

	[Benchmark]
#pragma warning disable CS8629 // Nullable value type may be null.
	public int Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.Null( value ).Value;
#pragma warning restore CS8629 // Nullable value type may be null.

	[Benchmark]
	public int Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNull();

#pragma warning disable CS8629 // Nullable value type may be null.
		return value.Value;
#pragma warning restore CS8629 // Nullable value type may be null.
	}
}