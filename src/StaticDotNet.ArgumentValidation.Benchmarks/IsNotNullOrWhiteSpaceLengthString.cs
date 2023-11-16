using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser( false )]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
public class IsNotNullOrWhiteSpaceLengthString {

	public string? argumentValue = "123";

	[Benchmark( Baseline = true )]
	public string Baseline() => !string.IsNullOrWhiteSpace( argumentValue ) && argumentValue.Length == 3 ? argumentValue : throw new ArgumentException();

	[Benchmark]
	public string ArgumentValidation() => Arg.IsNotNullOrWhiteSpace( argumentValue ).Length( 3 ).Value;

	[Benchmark]
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
	public string Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).NotNull().NotWhiteSpace().Length( 3 );
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

	[Benchmark]
	public string CommunityToolkit_Diagnostics() {
		CommunityToolkit.Diagnostics.Guard.IsNotNullOrWhiteSpace( argumentValue );
		CommunityToolkit.Diagnostics.Guard.HasSizeEqualTo( argumentValue, 3 );

		return argumentValue;
	}

	[Benchmark]
	public string Ensure_That() {
		Ensure.That( argumentValue ).IsNotNullOrWhiteSpace();
		Ensure.That( argumentValue ).HasLength( 3 );

#pragma warning disable CS8603 // Possible null reference return.
		return argumentValue;
#pragma warning restore CS8603 // Possible null reference return.
	}
}