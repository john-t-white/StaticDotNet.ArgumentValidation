using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNull_Class {

	public object? value = null;

	[Benchmark( Baseline = true )]
	public object? Baseline() => value is null ? value : throw new ArgumentException( "Value cannot be non null.", nameof( value ) );

	[Benchmark]
	public object? Arg_Is() => Arg.IsNull( value );

	[Benchmark]
	public object? Dawn_Guard() => Dawn.Guard.Argument( value ).Null();
}