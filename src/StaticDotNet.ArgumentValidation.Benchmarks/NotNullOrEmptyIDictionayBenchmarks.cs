using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullOrEmptyIDictionaryBenchmarks {

	public IDictionary<string, string> value = new Dictionary<string, string>() { { "Key", "Value" } };

	[Benchmark( Baseline = true )]
	public IDictionary<string, string> Baseline()
		=> this.value == null
			? throw new ArgumentNullException( nameof( this.value ) )
			: this.value.Count == 0 ? throw new ArgumentException( "Message", nameof( this.value ) ) : this.value;

	[Benchmark]
	public IDictionary<string, string> Argument_Is() => Arg.Is.NotNullOrEmpty( this.value );

	[Benchmark]
	public IDictionary<string, string> Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotEmpty().Value;
}