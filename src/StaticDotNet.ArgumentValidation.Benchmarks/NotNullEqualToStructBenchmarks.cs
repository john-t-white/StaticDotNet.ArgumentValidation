using Dawn;
using EnsureThat;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullEqualToStructBenchmarks {

	public int? value = 1;
	public int comparisonValue = 1;

	[Benchmark( Baseline = true )]
	public int Baseline()
		=> value is null
			? throw new ArgumentNullException( nameof( value ) )
			: value.Value == comparisonValue ? value.Value : throw new ArgumentException( string.Format( CultureInfo.InvariantCulture, "Value must be equal to {0}.", comparisonValue ), nameof( value ) );

	//[Benchmark]
	//public int Arg_Is() => Arg.Is.NotNullEqualTo( value, comparisonValue );

	[Benchmark]
	public int Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().Equal( comparisonValue );

	[Benchmark]
	public int Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNull();
		EnsureThat.Ensure.That( value!.Value, nameof( value ) ).Is( comparisonValue );

		return value.Value;
	}
}