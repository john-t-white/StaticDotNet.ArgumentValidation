using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNull_Struct {

	public int? value = null;

	[Benchmark( Baseline = true )]
	public int? Baseline() => value is null ? value : throw new ArgumentException( "Value cannot be non null.", nameof( value ) );

	[Benchmark]
	public int? Arg_Is() => Arg.IsNull( value );

	[Benchmark]
	public int? Dawn_Guard() => Dawn.Guard.Argument( value ).Null();
}