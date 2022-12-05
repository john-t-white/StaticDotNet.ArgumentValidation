using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_NotEmpty_List {

	public IList<int> value = new List<int>() { 1 };

	[Benchmark( Baseline = true )]
	public IList<int> Baseline()
		=> value is null
			? throw new ArgumentNullException( nameof( value ) )
			: value.Count == 0
				? throw new ArgumentException( "Message", nameof( value ) )
				: value;

	[Benchmark]
	public IList<int> Arg_Is() => Arg.IsNotNull( value ).NotEmpty().Value;

	[Benchmark]
	public IList<int> Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().NotEmpty().Value;

	[Benchmark]
	public IList<int> Ardalis_Guard() => ( IList<int> )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( value );

	[Benchmark]
	public IList<int> Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNull();
		EnsureThat.Ensure.That( value, nameof( value ) ).HasItems();

		return value;
	}
}