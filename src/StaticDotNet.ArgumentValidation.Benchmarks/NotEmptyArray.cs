using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser( false )]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
public class IsNotEmptyArray {

	public int[] argumentValue = new[] { 1, 2, 3 } ;

	[Benchmark( Baseline = true )]
	public int[] Baseline() => argumentValue.Length > 0 ? argumentValue : throw new ArgumentException();

	[Benchmark]
	public int[] ArgumentValidation() => Arg.Is( argumentValue ).NotEmpty().Value;

	[Benchmark]
	public int[] Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).NotEmpty();

	[Benchmark]
	public int[] Ardalis_GuardClauses() => ( int[] )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( argumentValue, nameof( argumentValue ) );

	[Benchmark]
	public int[] CommunityToolkit_Diagnostics() {
		CommunityToolkit.Diagnostics.Guard.IsNotEmpty( argumentValue );

		return argumentValue;
	}

	[Benchmark]
	public int[] Ensure_That() {
		Ensure.That( argumentValue ).HasItems();

		return argumentValue;
	}
}