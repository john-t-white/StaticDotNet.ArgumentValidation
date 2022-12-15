using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
[SimpleJob( RuntimeMoniker.NetCoreApp31 )]
[SimpleJob( RuntimeMoniker.Net481 )]
public class IsNotNullOrWhiteSpace {

	public string? argumentValue = "Value";

	[Benchmark( Baseline = true )]
	public string Baseline() {

		if( string.IsNullOrWhiteSpace( argumentValue ) ) {
			throw new ArgumentException();
		}

		return argumentValue;
	}

	[Benchmark]
	public string ArgumentValidation() => Arg.IsNotNullOrWhiteSpace( argumentValue ).Value;

	[Benchmark]
	public string ArgumentValidation2() => Arg.IsNotNull( argumentValue ).NotWhiteSpace().Value;

	[Benchmark]
	public string Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).NotNull().NotWhiteSpace();

	[Benchmark]
	public string Ardalis_GuardClauses() => Ardalis.GuardClauses.Guard.Against.NullOrWhiteSpace( argumentValue, nameof( argumentValue ) );

	[Benchmark]
	public string Ensure_That() {
		Ensure.That( argumentValue ).IsNotNullOrWhiteSpace();

		return argumentValue;
	}
}