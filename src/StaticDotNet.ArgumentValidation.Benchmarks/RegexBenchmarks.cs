using Ardalis.GuardClauses;
using Dawn;
using JetBrains.Annotations;
using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public partial class RegexBenchmarks {

	[GeneratedRegex( @"\d" )]
	private static partial Regex DigitRegex();

	public string value = "1";

	[Benchmark( Baseline = true )]
	public string Baseline() {

		if( string.IsNullOrWhiteSpace( this.value ) ) {
			if( this.value == null ) {

				throw new ArgumentNullException( nameof( this.value ) );
			}

			throw new ArgumentException( "Message", nameof( this.value ) );
		}

		return DigitRegex().IsMatch( this.value ) ? this.value : throw new ArgumentException( "Message", nameof( this.value ) );
	}

	[Benchmark]
	public string Argument_Is() {
		_ = Argument.Is.NotNullOrWhiteSpace( this.value );
		return Argument.Is.Match( this.value, DigitRegex() );
	}

	[Benchmark]
	public string Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotWhiteSpace().Matches( DigitRegex() );
}