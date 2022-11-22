using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullOrEmptyArrayBenchmarks {

	public string[] value = { "Value" };

	[Benchmark( Baseline = true )]
	public string[] Baseline()
		=> this.value == null
			? throw new ArgumentNullException( nameof( this.value ) )
			: this.value.Length == 0 ? throw new ArgumentException( "Message", nameof( this.value ) ) : this.value;

	[Benchmark]
	public string[] Argument_Is() => Argument.Is.NotNullOrEmpty( this.value );

	[Benchmark]
	public string[] Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotEmpty();

	[Benchmark]
	public string[] Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.NullOrEmpty( this.value.AsEnumerable() ).ToArray();
}