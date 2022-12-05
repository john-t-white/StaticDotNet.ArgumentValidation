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

		if( string.IsNullOrWhiteSpace( value ) ) {
			if( value is null ) {

				throw new ArgumentNullException( nameof( value ) );
			}

			throw new ArgumentException( "Message", nameof( value ) );
		}

		return DigitRegex().IsMatch( value ) ? value : throw new ArgumentException( "Message", nameof( value ) );
	}

	//[Benchmark]
	//public string Arg_Is() => Arg.IsNotNull( value ).NotWhiteSpace().Matches( DigitRegex() ).Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public string Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().NotWhiteSpace().Matches( DigitRegex() );
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
	public string Ensure_That() {

		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNullOrWhiteSpace();
		EnsureThat.Ensure.That( value, nameof( value ) ).Matches( DigitRegex() );

#pragma warning disable CS8603 // Possible null reference return.
		return value;
#pragma warning restore CS8603 // Possible null reference return.
	}
}