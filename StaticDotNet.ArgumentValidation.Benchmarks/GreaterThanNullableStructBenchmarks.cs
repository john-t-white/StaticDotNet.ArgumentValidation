using Ardalis.GuardClauses;
using Dawn;
using JetBrains.Annotations;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class GreaterThanNullableStructBenchmarks {

	public int? value = 2;
	public int comparisonValue = 1;

	[Benchmark( Baseline = true )]
	public int? Baseline() => Comparer<int?>.Default.Compare( this.value, this.comparisonValue ) > 0 ? this.value : throw new ArgumentException( string.Format( CultureInfo.InvariantCulture, "Value must be greater than {0}.", this.comparisonValue ), nameof( this.value ) );

	[Benchmark]
	public int? Argument_Is() => Argument.Is.GreaterThan( this.value, this.comparisonValue );

	[Benchmark]
	public int? Dawn_Guard() => Dawn.Guard.Argument( this.value ).GreaterThan( this.comparisonValue );

	[Benchmark]
	public int Ardalis_Guard() => Ardalis.GuardClauses.Guard.Against.Negative( this.value!.Value );
}