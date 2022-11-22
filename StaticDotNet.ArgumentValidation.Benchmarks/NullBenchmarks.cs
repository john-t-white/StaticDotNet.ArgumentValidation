using Ardalis.GuardClauses;
using Dawn;
using JetBrains.Annotations;

namespace StaticDotNet.ArgumentValidation.Benchmarks; 

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
public class NullBenchmarks {

	public object? value = null;

	[Benchmark(Baseline = true)]
	public object? Baseline()
	{
		if (this.value == null)
		{
			return this.value;
		}

		throw new ArgumentException( "Value cannot be non null.", nameof( this.value ) );
	}

	[Benchmark]
	public object? Argument_Is_NotNull()
	{
		return Argument.Is.Null( this.value );
	}

	[Benchmark]
	public object? Dawn_Guard_NotNull()
	{
		return Dawn.Guard.Argument( this.value ).Null();
	}
}