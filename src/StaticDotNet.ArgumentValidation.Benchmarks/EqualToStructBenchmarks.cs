using Ardalis.GuardClauses;
using Dawn;
using JetBrains.Annotations;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class EqualToStructBenchmarks {

	public int value = 1;
	public int comparisonValue = 1;

	[Benchmark( Baseline = true )]
	public int Baseline() => this.value == this.comparisonValue ? this.value : throw new ArgumentException( string.Format( CultureInfo.InvariantCulture, "Value must be equal to {0}.", this.comparisonValue ), nameof( this.value ) );

	[Benchmark]
	public int Argument_Is() => Arg.Is.EqualTo( this.value, this.comparisonValue );

	[Benchmark]
	public int Dawn_Guard() => Dawn.Guard.Argument( this.value ).Equal( this.comparisonValue );
}