using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullOrEmptyArrayBenchmarks {

	public string[] value = { "Value" };

	[Benchmark( Baseline = true )]
	public string[] Baseline()
		=> this.value is null
			? throw new ArgumentNullException( nameof( this.value ) )
			: this.value.Length == 0 ? throw new ArgumentException( "Message", nameof( this.value ) ) : this.value;

	//[Benchmark]
	//public string[] Arg_Is() => Arg.Is.NotNullOrEmpty( this.value );

	[Benchmark]
	public string[] Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotEmpty();

	[Benchmark]
	public string[] Ardalis_Guard() => ( string[] )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( this.value );

	[Benchmark]
	public string[] Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNull();
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).HasItems();

		return this.value;
	}
}