using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_NotWhiteSpace {

	public string? value = "Value";

	[Benchmark( Baseline = true )]
	public string Baseline() {
		if( string.IsNullOrWhiteSpace( this.value ) ) {
			if( this.value is null ) {
				throw new ArgumentNullException( nameof( this.value ) );
			}

			throw new ArgumentException( "Message", nameof( this.value ) );
		}

		return this.value;
	}

	[Benchmark]
	public string Arg_Is() => Arg.IsNotNull( this.value ).NotWhiteSpace().Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public string Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotWhiteSpace();
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
	public string Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.NullOrWhiteSpace( this.value );

	[Benchmark]
	public string Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNullOrWhiteSpace();

#pragma warning disable CS8603 // Possible null reference return.
		return this.value;
#pragma warning restore CS8603 // Possible null reference return.
	}
}