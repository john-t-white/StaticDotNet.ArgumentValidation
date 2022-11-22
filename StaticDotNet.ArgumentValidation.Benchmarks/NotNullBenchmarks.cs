using Ardalis.GuardClauses;
using Dawn;

namespace StaticDotNet.ArgumentValidation.Benchmarks; 

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
public class NotNullBenchmarks {

	public object value = new();

	[Benchmark(Baseline = true)]
	public object Baseline()
	{
		return this.value ?? new ArgumentNullException( nameof( this.value ) );
	}

	[Benchmark]
	public object Argument_Is_NotNull()
	{
		return Argument.Is.NotNull( this.value );
	}

	[Benchmark]
	public object Dawn_Guard_NotNull()
	{
		return Dawn.Guard.Argument( this.value ).NotNull();
	}
	
	[Benchmark]
	public object Ardalis_Guard_NotNull()
	{
		return Ardalis.GuardClauses.Guard.Against.Null( this.value );
	}
}