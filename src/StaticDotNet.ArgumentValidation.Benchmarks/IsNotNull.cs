using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser( false )]
[SimpleJob( RuntimeMoniker.Net80 )]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
public class IsNotNull {

	public object? argumentValue = "Value";

	[Benchmark( Baseline = true )]
	public object Baseline() => argumentValue ?? throw new ArgumentNullException();

	[Benchmark]
	public object ArgumentValidation() => Arg.IsNotNull( argumentValue ).Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public object Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).NotNull();
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
	public object Ardalis_GuardClauses() => Ardalis.GuardClauses.Guard.Against.Null( argumentValue, nameof( argumentValue ) );

	[Benchmark]
	public object CommunityToolkit_Diagnostics() {
		CommunityToolkit.Diagnostics.Guard.IsNotNull( argumentValue );

		return argumentValue;
	}

	[Benchmark]
	public object Ensure_That() {
		Ensure.That( argumentValue ).IsNotNull();

#pragma warning disable CS8603 // Possible null reference return.
		return argumentValue;
#pragma warning restore CS8603 // Possible null reference return.
	}
}