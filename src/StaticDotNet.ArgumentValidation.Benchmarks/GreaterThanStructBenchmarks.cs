using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class GreaterThanStructBenchmarks {

	public int value = 2;
	public int comparisonValue = 0;

	[Benchmark( Baseline = true )]
	public int Baseline() => value > comparisonValue ? value : throw new ArgumentException( string.Format( CultureInfo.InvariantCulture, "Value must be greater than {0}.", comparisonValue ), nameof( value ) );

	//[Benchmark]
	//public int Arg_Is() => Arg.Is.GreaterThan( value, comparisonValue );

	[Benchmark]
	public int Dawn_Guard() => Dawn.Guard.Argument( value ).GreaterThan( comparisonValue );

	[Benchmark]
	public int Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.Negative( value );

	[Benchmark]
	public int Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsGt( comparisonValue );

		return value;
	}
}