using Ardalis.GuardClauses;
using Dawn;
using JetBrains.Annotations;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNull_Struct {

	public int? value = null;

	[Benchmark( Baseline = true )]
	public int? Baseline() => this.value == null ? this.value : throw new ArgumentException( "Value cannot be non null.", nameof( this.value ) );

	[Benchmark]
	public int? Arg_Is() => Arg.IsNull( this.value );

	[Benchmark]
	public int? Dawn_Guard() => Dawn.Guard.Argument( this.value ).Null();
}