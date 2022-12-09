using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_NotEmpty_List {

	public List<int> value = new List<int>() { 1 };

	[Benchmark( Baseline = true )]
	public IList<int> Baseline()
		=> value is null
			? throw new ArgumentNullException( nameof( value ) )
			: value.Count == 0
				? throw new ArgumentException( "Message", nameof( value ) )
				: value;

	[Benchmark]
	public List<int> Arg_Is() => Arg.IsNotNull( value ).NotEmpty().Value;

	[Benchmark]
	public List<int> Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().NotEmpty();

	[Benchmark]
	public List<int> Ardalis_Guard() => ( List<int> )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( value );

	[Benchmark]
	public IList<int> Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNull();
		EnsureThat.Ensure.That( value, nameof( value ) ).HasItems();

		return value;
	}
}