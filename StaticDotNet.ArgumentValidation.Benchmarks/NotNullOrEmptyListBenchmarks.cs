using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullOrEmptyListBenchmarks {

	public IList<string> value = new List<string>() { "Value" };

	[Benchmark( Baseline = true )]
	public IList<string> Baseline()
		=> this.value == null
			? throw new ArgumentNullException( nameof( this.value ) )
			: this.value.Count == 0 ? throw new ArgumentException( "Message", nameof( this.value ) ) : this.value;

	[Benchmark]
	public IList<string> Argument_Is() => Argument.Is.NotNullOrEmpty( this.value );

	[Benchmark]
	public IList<string> Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotEmpty().Value;

	[Benchmark]
	public List<string> Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.NullOrEmpty( this.value ).ToList();
}