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
		=> this.value == null
			? throw new ArgumentNullException( nameof( this.value ) )
			: this.value.Count == 0 ? throw new ArgumentException( "Message", nameof( this.value ) ) : this.value;

	[Benchmark]
	public IDictionary<string, string> Arg_Is() => Arg.Is.NotNullOrEmpty( this.value );

	[Benchmark]
	public IDictionary<string, string> Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotEmpty().Value;

	[Benchmark]
	public IDictionary<string, string> Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNull();
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).HasItems();

		return this.value;
	}
}