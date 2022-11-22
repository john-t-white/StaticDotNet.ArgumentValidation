using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullOrWhiteSpaceBenchmarks {

	public string value = "Value";

	[Benchmark( Baseline = true )]
	public string Baseline() {
		if( string.IsNullOrWhiteSpace( this.value ) ) {
			if( this.value == null ) {
				throw new ArgumentNullException( nameof( this.value ) );
			}

			throw new ArgumentException( "Message", nameof( this.value ) );
		}

		return this.value;
	}

	[Benchmark]
	public string Argument_Is() => Argument.Is.NotNullOrWhiteSpace( this.value );

	[Benchmark]
	public string Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotWhiteSpace();

	[Benchmark]
	public string Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.NullOrWhiteSpace( this.value );
}