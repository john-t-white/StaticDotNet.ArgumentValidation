using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullTrueBenchmarks {

	public bool? value = true;

	[Benchmark( Baseline = true )]
	public bool Baseline() => value is null ? throw new ArgumentNullException( nameof( value ) ) : value.Value ? true : throw new ArgumentException( "Value must be true.", nameof( value ) );

	//[Benchmark]
	//public bool Arg_Is() => Arg.Is.NotNullTrue( value );

	[Benchmark]
	public bool Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().True();

	[Benchmark]
	public bool Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNull();
		EnsureThat.Ensure.That( value!.Value, nameof( value ) ).IsTrue();

		return value!.Value;
	}
}