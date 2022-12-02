using Ardalis.GuardClauses;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class IsNotNull_NotEmpty_List {

	public IList<int> value = new List<int>() { 1 };

	[Benchmark( Baseline = true )]
	public IList<int> Baseline() {

		if( this.value == null ) {
			throw new ArgumentNullException( nameof( this.value ) );
		}

		if( this.value.Count == 0 ) { 
			throw new ArgumentException( "Message", nameof( this.value ) );
		}

		return this.value;
	}

	[Benchmark]
	public IList<int> Arg_Is() => Arg.IsNotNull( this.value ).NotEmpty().Value;

	[Benchmark]
	public IList<int> Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotEmpty().Value;

	[Benchmark]
	public IList<int> Ardalis_Guard() => ( IList<int> )Ardalis.GuardClauses.Guard.Against.NullOrEmpty( this.value );

	[Benchmark]
	public IList<int> Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNull();
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).HasItems();

		return this.value;
	}
}