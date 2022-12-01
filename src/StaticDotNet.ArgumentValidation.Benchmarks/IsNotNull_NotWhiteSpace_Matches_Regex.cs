using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;
using JetBrains.Annotations;
using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public partial class IsNotNull_NotWhiteSpace_Matches_Regex {

	[GeneratedRegex( @"\d" )]
	private static partial Regex DigitRegex();

	public string? value = "1";

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

	//[Benchmark]
	//public string Arg_Is() => Arg.IsNotNull( this.value ).NotWhiteSpace().Matches( DigitRegex() ).Value;

	[Benchmark]
	public string Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotWhiteSpace().Matches( DigitRegex() );

	[Benchmark]
	public string Ensure_That() {

		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNullOrWhiteSpace();
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).Matches( DigitRegex() );

		return this.value;
	}
}