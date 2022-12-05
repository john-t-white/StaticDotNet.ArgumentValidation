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
		if( string.IsNullOrEmpty( value ) ) {
			if( value is null ) {
				throw new ArgumentNullException( nameof( value ) );
			}

			throw new ArgumentException( "Message", nameof( value ) );
		}

		return value;
	}

	[Benchmark]
	public string Arg_Is() => Arg.IsNotNull( value ).NotEmpty().Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public string Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().NotEmpty();
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
	public string Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.NullOrEmpty( value );

	[Benchmark]
	public string Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNullOrEmpty();

#pragma warning disable CS8603 // Possible null reference return.
		return value;
#pragma warning restore CS8603 // Possible null reference return.
	}
}