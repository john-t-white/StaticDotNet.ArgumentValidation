using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_NotWhiteSpace_EqualTo_String {

	public string? value = "Value";
	public string comparisonValue = "Value";

	[Benchmark( Baseline = true )]
	public string Baseline() {
		if( string.IsNullOrEmpty( this.value ) ) {
			if( this.value is null ) {
				throw new ArgumentNullException( nameof( this.value ) );
			}

			throw new ArgumentException( "Message", nameof( this.value ) );
		}

		return !StringComparer.OrdinalIgnoreCase.Equals( this.value, this.comparisonValue )
			? throw new ArgumentException( "Value not equal.", nameof( this.value ) )
			: this.value;
	}

	[Benchmark]
	public string Arg_Is() => Arg.IsNotNull( this.value ).NotWhiteSpace().EqualTo( this.comparisonValue, StringComparison.OrdinalIgnoreCase ).Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public string Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotWhiteSpace().Equal( this.comparisonValue, StringComparison.OrdinalIgnoreCase );
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
	public string Ardalis_Guard() {
		_ = Ardalis.GuardClauses.Guard.Against.NullOrWhiteSpace( this.value );

		return !StringComparer.OrdinalIgnoreCase.Equals( this.value, this.comparisonValue )
			? throw new ArgumentException( "Value not equal.", nameof( this.value ) )
			: this.value;
	}

	[Benchmark]
	public string Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNullOrWhiteSpace();
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsEqualTo( this.comparisonValue, StringComparison.OrdinalIgnoreCase );

#pragma warning disable CS8603 // Possible null reference return.
		return this.value;
#pragma warning restore CS8603 // Possible null reference return.
	}
}