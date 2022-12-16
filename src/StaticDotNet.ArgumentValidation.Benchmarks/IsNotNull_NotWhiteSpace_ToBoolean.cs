using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
[SimpleJob( RuntimeMoniker.Net60 )]
[SimpleJob( RuntimeMoniker.NetCoreApp31 )]
[SimpleJob( RuntimeMoniker.Net481 )]
public class IsNotNull_NotWhiteSpace_ToBoolean {

	public string? argumentValue = bool.TrueString;

	[Benchmark( Baseline = true )]
	public bool Baseline() {

		if( string.IsNullOrWhiteSpace( argumentValue ) ) {
			throw new ArgumentException();
		}

		if( !bool.TryParse( argumentValue, out bool result) ) {
			throw new ArgumentException();
		}

		return result;
	}

	[Benchmark]
	public bool ArgumentValidation() => Arg.IsNotNull( argumentValue ).NotWhiteSpace().ToBoolean().Value;

	[Benchmark]
	public bool Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).NotNull().NotWhiteSpace().Wrap( x => bool.Parse( x ) );
}