using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;
using JetBrains.Annotations;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class GreaterThanClassBenchmarks {

	public string value = "c";
	public string comparisonValue = "b";

	[Benchmark( Baseline = true )]
	public string Baseline() => Comparer<string>.Default.Compare( this.value, this.comparisonValue ) > 0 ? this.value : throw new ArgumentException( string.Format( CultureInfo.InvariantCulture, "Value must be greater than {0}.", this.comparisonValue ), nameof( this.value ) );

	[Benchmark]
	public string Arg_Is() => Arg.Is.GreaterThan( this.value, this.comparisonValue );

	[Benchmark]
	public string Dawn_Guard() => Dawn.Guard.Argument( this.value ).GreaterThan( this.comparisonValue );

	[Benchmark]
	public string Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsGt( this.comparisonValue, StringComparison.OrdinalIgnoreCase );

		return this.value;
	}
}