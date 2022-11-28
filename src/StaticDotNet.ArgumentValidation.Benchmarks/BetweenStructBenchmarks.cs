using Ardalis.GuardClauses;
using Dawn;
using JetBrains.Annotations;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class BetweenStructBenchmarks {

	public int value = 2;
	public int minValue = 1;
	public int maxValue = 3;

	[Benchmark( Baseline = true )]
	public int Baseline() => this.value >= this.minValue && this.value <= this.maxValue ? this.value : throw new ArgumentOutOfRangeException( string.Format( CultureInfo.InvariantCulture, "Value must be between to {0} and {1}.", this.minValue, this.maxValue ), nameof( this.value ) );

	[Benchmark]
	public int Argument_Is() => Arg.Is.Between( this.value, this.minValue, this.maxValue );

	[Benchmark]
	public int Dawn_Guard() => Dawn.Guard.Argument( this.value ).InRange( this.minValue, this.maxValue );


	[Benchmark]
	public int Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.OutOfRange( this.value, nameof( this.value ), this.minValue, this.maxValue );
}