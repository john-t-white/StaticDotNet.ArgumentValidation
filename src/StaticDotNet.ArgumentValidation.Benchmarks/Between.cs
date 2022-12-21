using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
public class Between {

	public int argumentValue = 2;
	public int minValue = 1;
	public int maxValue = 3;

	[Benchmark( Baseline = true )]
	public int Baseline() => ( argumentValue >= minValue && argumentValue <= maxValue ) ? argumentValue : throw new ArgumentOutOfRangeException( nameof( argumentValue ) );

	[Benchmark]
	public int ArgumentValidation() => Arg.Is( argumentValue ).Between( minValue, maxValue ).Value;

	[Benchmark]
	public int Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).InRange( minValue, maxValue );

	[Benchmark]
	public int Ardalis_GuardClauses() => Ardalis.GuardClauses.Guard.Against.OutOfRange( argumentValue, nameof( argumentValue ), minValue, maxValue );

	[Benchmark]
	public int CommunityToolkit_Diagnostics() {
		CommunityToolkit.Diagnostics.Guard.IsBetweenOrEqualTo( argumentValue, minValue, maxValue );

		return argumentValue;
	}

	[Benchmark]
	public int Ensure_That() {
		Ensure.That( argumentValue ).IsInRange( minValue, maxValue );

		return argumentValue;
	}
}