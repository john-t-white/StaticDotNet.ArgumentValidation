using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;
using System.Collections.ObjectModel;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullOrEmptyICollectionBenchmarks {

	public ICollection<string> value = new Collection<string>() { "Value" };

	[Benchmark( Baseline = true )]
	public ICollection<string> Baseline()
		=> value is null
			? throw new ArgumentNullException( nameof( value ) )
			: value.Count == 0 ? throw new ArgumentException( "Message", nameof( value ) ) : value;

	//[Benchmark]
	//public Collection<string> Arg_Is() => Arg.Is.NotNullOrEmpty( value );

	[Benchmark]
	public ICollection<string> Dawn_Guard() => Dawn.Guard.Argument( value ).NotNull().NotEmpty().Value;

	[Benchmark]
	public ICollection<string> Ardalis_Guard() => ( ICollection<string> )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( value );

	[Benchmark]
	public ICollection<string> Ensure_That() {
		EnsureThat.Ensure.That( value, nameof( value ) ).IsNotNull();
		EnsureThat.Ensure.That( value, nameof( value ) ).HasItems();

		return value;
	}
}