using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_NotEmpty_String {

	public string? value = "Value";

	[Benchmark( Baseline = true )]
	public string Baseline() {
		if( string.IsNullOrEmpty( this.value ) ) {
			if( this.value == null ) {
				throw new ArgumentNullException( nameof( this.value ) );
			}

			throw new ArgumentException( "Message", nameof( this.value ) );
		}

		return this.value;
	}

	[Benchmark]
	public string Arg_Is() => Arg.IsNotNull( this.value ).NotEmpty().Value;

	[Benchmark]
	public string Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotEmpty();

	[Benchmark]
	public string Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.NullOrEmpty( this.value );

	[Benchmark]
	public string Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNullOrEmpty();

		return this.value;
	}
}