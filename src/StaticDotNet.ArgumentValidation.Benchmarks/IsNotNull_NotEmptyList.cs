using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser( false )]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
public class IsNotNull_NotEmptyList {

	public IList<int> argumentValue = new List<int>() { 1, 2, 3 };

	[Benchmark( Baseline = true )]
	public IList<int> Baseline() => argumentValue.Count > 0 ? argumentValue : throw new ArgumentException();

	[Benchmark]
	public IList<int> ArgumentValidation() => Arg.IsNotNull( argumentValue ).NotEmpty().Value;

	[Benchmark]
	public IList<int> Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).NotNull().NotEmpty().Value;

	[Benchmark]
	public IList<int> Ardalis_GuardClauses() => ( IList<int> )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( argumentValue, nameof( argumentValue ) );

	[Benchmark]
	public IList<int> CommunityToolkit_Diagnostics() {
		CommunityToolkit.Diagnostics.Guard.IsNotNull ( argumentValue );
		CommunityToolkit.Diagnostics.Guard.IsNotEmpty( argumentValue );

		return argumentValue;
	}

	[Benchmark]
	public IList<int> Ensure_That() {
		Ensure.That( argumentValue ).IsNotNull();
		Ensure.That( argumentValue ).HasItems();

		return argumentValue;
	}
}