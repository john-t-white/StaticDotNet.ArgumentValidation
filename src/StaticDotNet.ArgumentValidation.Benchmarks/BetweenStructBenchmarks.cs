using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class BetweenStructBenchmarks {

	public int value = 2;
	public int minValue = 1;
	public int maxValue = 3;

	[Benchmark( Baseline = true )]
	public int Baseline() => value >= minValue && value <= maxValue ? value : throw new ArgumentOutOfRangeException( string.Format( CultureInfo.InvariantCulture, "Value must be between to {0} and {1}.", minValue, maxValue ), nameof( value ) );

	//[Benchmark]
	//public int Arg_Is() => Arg.Is.Between( value, minValue, maxValue );

	[Benchmark]
	public int Dawn_Guard() => Dawn.Guard.Argument( value ).InRange( minValue, maxValue );


	[Benchmark]
	public int Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.OutOfRange( value, nameof( value ), minValue, maxValue );

	[Benchmark]
	public int Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsInRange( minValue, maxValue );

		return value;
	}
}