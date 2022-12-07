using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_Length {

    public string? value = new( 'a', 10 );
    public int length = 10;

    [Benchmark( Baseline = true )]
    public string Baseline() {
        if( string.IsNullOrWhiteSpace( value ) ) {
            if( value is null ) {
                throw new ArgumentNullException( nameof( value ) );
            }

            throw new ArgumentException( "Message", nameof( value ) );
        }

        if( value.Length != length ) {
            throw new ArgumentException();
        }

        return value;
    }

    [Benchmark]
    public string Arg_Is() => Arg.IsNotNull( value ).Length( length ).Value;

    [Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
    public string Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().Length( length );
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

    [Benchmark]
    public string Ardalis_Guard() {
        string result = Ardalis.GuardClauses.Guard.Against.NullOrWhiteSpace( value );
        if( result.Length != length ) {
            throw new ArgumentOutOfRangeException();
        }

        return result;
    }

    [Benchmark]
    public string Ensure_That() {
        EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNullOrWhiteSpace();
        EnsureThat.Ensure.That( value, nameof( value ) ).HasLength( length );

#pragma warning disable CS8603 // Possible null reference return.
        return value;
#pragma warning restore CS8603 // Possible null reference return.
    }
}