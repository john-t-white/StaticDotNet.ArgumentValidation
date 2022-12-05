using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_Class {

	public object? value = new();

	[Benchmark( Baseline = true )]
	public object Baseline() => value ?? throw new ArgumentNullException( nameof( value ) );

	[Benchmark]
	public object Arg_IsNotNull() => Arg.IsNotNull( value ).Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public object Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull();
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
#pragma warning disable CS8603 // Possible null reference return.
	public object Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.Null( value );
#pragma warning restore CS8603 // Possible null reference return.

	[Benchmark]
	public object Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNull();

#pragma warning disable CS8603 // Possible null reference return.
		return value;
#pragma warning restore CS8603 // Possible null reference return.
	}
}