using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NullableTrueBenchmarks {

	public bool? value = true;

	[Benchmark( Baseline = true )]
	public bool? Baseline() => value.HasValue && value == true ? true : throw new ArgumentException( "Value must be true.", nameof( value ) );

	//[Benchmark]
	//public bool? Arg_Is() => Arg.Is.True( value );

	[Benchmark]
	public bool? Dawn_Guard() => Dawn.Guard.Argument( value ).True();

	[Benchmark]
	public bool? Ensure_That() {
		if( value is not null ) {
			EnsureThat.Ensure.That( value.Value, nameof( value ) ).IsTrue();
		}

		return value;
	}
}