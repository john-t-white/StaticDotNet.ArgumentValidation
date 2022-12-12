using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_Contains_List {

	public string value = "c";
	public IList<string> argumentValue = new string[] { "a", "b", "c" };

	[Benchmark( Baseline = true )]
	public IList<string> Baseline() {

		ArgumentNullException.ThrowIfNull( argumentValue );

		if( argumentValue.Contains( value ) ) {
			return argumentValue;
		}

		throw new ArgumentException( "Error" );
	}

	[Benchmark]
	public IList<string> Arg_Is() => Arg.IsNotNull( argumentValue ).Contains( value ).Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public IList<string> Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).NotNull().Contains( value ).Value;
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
	public IList<string> Ardalis_Guard() {
		_ = Ardalis.GuardClauses.Guard.Against.Null( argumentValue );
		return !argumentValue.Contains( value ) ? throw new ArgumentOutOfRangeException() : argumentValue;
	}

	[Benchmark]
	public IList<string> Ensure_That() {
		EnsureThat.Ensure.That( argumentValue, nameof( argumentValue ) ).IsNotNull();

		return !argumentValue.Contains( value ) ? throw new ArgumentOutOfRangeException() : argumentValue;
	}
}