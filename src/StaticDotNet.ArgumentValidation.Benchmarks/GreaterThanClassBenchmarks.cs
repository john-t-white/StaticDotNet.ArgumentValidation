using Dawn;
using EnsureThat;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class GreaterThanClassBenchmarks {

	public string value = "c";
	public string comparisonValue = "b";

	[Benchmark( Baseline = true )]
	public string Baseline() => Comparer<string>.Default.Compare( value, comparisonValue ) > 0 ? value : throw new ArgumentException( string.Format( CultureInfo.InvariantCulture, "Value must be greater than {0}.", comparisonValue ), nameof( value ) );

	//[Benchmark]
	//public string Arg_Is() => Arg.Is.GreaterThan( value, comparisonValue );

	[Benchmark]
	public string Dawn_Guard() => Dawn.Guard.Argument( value ).GreaterThan( comparisonValue );

	[Benchmark]
	public string Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsGt( comparisonValue, StringComparison.OrdinalIgnoreCase );

		return value;
	}
}