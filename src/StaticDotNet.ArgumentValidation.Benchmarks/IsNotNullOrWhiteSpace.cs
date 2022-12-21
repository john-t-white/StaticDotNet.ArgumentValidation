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
	public string Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).NotNull().NotWhiteSpace();

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

		return argumentValue;
	}
}