using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullOrEmptyIListBenchmarks {

	public IList<string> value = new List<string>() { "Value" };

	[Benchmark( Baseline = true )]
	public IList<string> Baseline()
		=> value is null
			? throw new ArgumentNullException( nameof( value ) )
			: value.Count == 0 ? throw new ArgumentException( "Message", nameof( value ) ) : value;

	//[Benchmark]
	//public List<string> Arg_Is() => Arg.Is.NotNullOrEmpty( value );

	[Benchmark]
	public IList<string> Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().NotEmpty().Value;

	[Benchmark]
	public IList<string> Ardalis_Guard() => ( IList<string> )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( value );

	[Benchmark]
	public IList<string> Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNull();
		EnsureThat.Ensure.That( value, nameof( value ) ).HasItems();

		return value;
	}
}