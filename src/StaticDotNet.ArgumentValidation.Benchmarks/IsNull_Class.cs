using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNull_Class {

	public object? value = null;

	[Benchmark( Baseline = true )]
	public object? Baseline() => this.value == null ? this.value : throw new ArgumentException( "Value cannot be non null.", nameof( this.value ) );

	[Benchmark]
	public object? Arg_Is() => Arg.IsNull( this.value );

	[Benchmark]
	public object? Dawn_Guard() => Dawn.Guard.Argument( this.value ).Null();
}