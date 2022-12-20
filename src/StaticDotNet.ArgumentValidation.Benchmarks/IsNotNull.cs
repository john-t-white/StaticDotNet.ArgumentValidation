using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser( false )]
[SimpleJob( RuntimeMoniker.Net70 )]
//[SimpleJob( RuntimeMoniker.Net60 )]
//[SimpleJob( RuntimeMoniker.NetCoreApp31 )]
//[SimpleJob( RuntimeMoniker.Net481 )]
public class IsNotNull {

	public object? argumentValue = "Value";

	[Benchmark( Baseline = true )]
	public object Baseline() => argumentValue ?? throw new ArgumentException();

	[Benchmark]
	public object ArgumentValidation() => Arg.IsNotNull( argumentValue ).Value;

	[Benchmark]
	public object Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).NotNull();

	[Benchmark]
	public object Ardalis_GuardClauses() => Ardalis.GuardClauses.Guard.Against.Null( argumentValue, nameof( argumentValue ) );

	[Benchmark]
	public object Ensure_That() {
		Ensure.That( argumentValue ).IsNotNull();

		return argumentValue;
	}
}