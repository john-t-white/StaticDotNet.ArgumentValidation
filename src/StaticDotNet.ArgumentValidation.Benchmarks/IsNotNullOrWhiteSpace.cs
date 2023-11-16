using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
public class IsNotNullOrWhiteSpace {

	public string? argumentValue = "Value";

	[Benchmark( Baseline = true )]
	public string Baseline() => string.IsNullOrWhiteSpace( argumentValue ) ? throw new ArgumentException() : argumentValue;

	[Benchmark]
	public string ArgumentValidation() => Arg.IsNotNullOrWhiteSpace( argumentValue ).Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public string Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).NotNull().NotWhiteSpace();
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
	public string Ardalis_GuardClauses() => Ardalis.GuardClauses.Guard.Against.NullOrWhiteSpace( argumentValue, nameof( argumentValue ) );

	[Benchmark]
	public object CommunityToolkit_Diagnostics() {
		CommunityToolkit.Diagnostics.Guard.IsNotNullOrWhiteSpace( argumentValue );

		return argumentValue;
	}

	[Benchmark]
	public string Ensure_That() {
		Ensure.That( argumentValue ).IsNotNullOrWhiteSpace();

#pragma warning disable CS8603 // Possible null reference return.
		return argumentValue;
#pragma warning restore CS8603 // Possible null reference return.
	}
}