using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_NotWhiteSpace_EqualTo {

	public string? value = "Value";
	public string comparisonValue = "Value";

	[Benchmark( Baseline = true )]
	public string Baseline() {
		if( string.IsNullOrEmpty( value ) ) {
			if( value is null ) {
				throw new ArgumentNullException( nameof( value ) );
			}

			throw new ArgumentException( "Message", nameof( value ) );
		}

		return !StringComparer.OrdinalIgnoreCase.Equals( value, comparisonValue )
			? throw new ArgumentException( "Value not equal.", nameof( value ) )
			: value;
	}

	[Benchmark]
	public string Arg_Is() => Arg.IsNotNull( value ).NotWhiteSpace().EqualTo( comparisonValue, StringComparison.OrdinalIgnoreCase ).Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public string Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().NotWhiteSpace().Equal( comparisonValue, StringComparison.OrdinalIgnoreCase );
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
	public string Ardalis_Guard() {
		_ = Ardalis.GuardClauses.Guard.Against.NullOrWhiteSpace( value );

		return !StringComparer.OrdinalIgnoreCase.Equals( value, comparisonValue )
			? throw new ArgumentException( "Value not equal.", nameof( value ) )
			: value;
	}

	[Benchmark]
	public string Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNullOrWhiteSpace();
		EnsureThat.Ensure.That( value, nameof( value ) ).IsEqualTo( comparisonValue, StringComparison.OrdinalIgnoreCase );

#pragma warning disable CS8603 // Possible null reference return.
		return value;
#pragma warning restore CS8603 // Possible null reference return.
	}
}