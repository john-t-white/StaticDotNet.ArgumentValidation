using Dawn;
using EnsureThat;
using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public partial class ___IsNotNull_NotWhiteSpace_Matches_Regex {

	[GeneratedRegex( @"\d" )]
	private static partial Regex DigitRegex();

	public string? value = "1";

	[Benchmark( Baseline = true )]
	public string Baseline() {

		if( string.IsNullOrWhiteSpace( this.value ) ) {
			if( this.value is null ) {

				throw new ArgumentNullException( nameof( this.value ) );
			}

			throw new ArgumentException( "Message", nameof( this.value ) );
		}

		return DigitRegex().IsMatch( this.value ) ? this.value : throw new ArgumentException( "Message", nameof( this.value ) );
	}

	//[Benchmark]
	//public string Arg_Is() => Arg.IsNotNull( this.value ).NotWhiteSpace().Matches( DigitRegex() ).Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public string Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotWhiteSpace().Matches( DigitRegex() );
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
	public string Ensure_That() {

		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNullOrWhiteSpace();
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).Matches( DigitRegex() );

#pragma warning disable CS8603 // Possible null reference return.
		return this.value;
#pragma warning restore CS8603 // Possible null reference return.
	}
}