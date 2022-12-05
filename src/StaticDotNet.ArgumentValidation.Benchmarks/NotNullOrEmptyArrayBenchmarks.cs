using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullOrEmptyArrayBenchmarks {

	public string[] value = { "Value" };

	[Benchmark( Baseline = true )]
	public string[] Baseline()
		=> value is null
			? throw new ArgumentNullException( nameof( value ) )
			: value.Length == 0 ? throw new ArgumentException( "Message", nameof( value ) ) : value;

	//[Benchmark]
	//public string[] Arg_Is() => Arg.Is.NotNullOrEmpty( value );

	[Benchmark]
	public string[] Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().NotEmpty();

	[Benchmark]
	public string[] Ardalis_Guard() => ( string[] )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( value );

	[Benchmark]
	public string[] Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNull();
		EnsureThat.Ensure.That( value, nameof( value ) ).HasItems();

		return value;
	}
}