using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullOrEmptyIDictionaryBenchmarks {

	public IDictionary<string, string> value = new Dictionary<string, string>() { { "Key", "Value" } };

	[Benchmark( Baseline = true )]
	public IDictionary<string, string> Baseline()
		=> value is null
			? throw new ArgumentNullException( nameof( value ) )
			: value.Count == 0 ? throw new ArgumentException( "Message", nameof( value ) ) : value;

	//[Benchmark]
	//public Dictionary<string, string> Arg_Is() => Arg.Is.NotNullOrEmpty( value );

	[Benchmark]
	public IDictionary<string, string> Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().NotEmpty().Value;

	[Benchmark]
	public IDictionary<string, string> Ardalis_Guard() => ( IDictionary<string, string> )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( value );

	[Benchmark]
	public IDictionary<string, string> Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNull();
		EnsureThat.Ensure.That( value, nameof( value ) ).HasItems();

		return value;
	}
}