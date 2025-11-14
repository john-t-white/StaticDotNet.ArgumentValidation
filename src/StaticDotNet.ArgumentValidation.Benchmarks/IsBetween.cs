using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Dawn;
using EnsureThat;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net10_0 )]
[SimpleJob( RuntimeMoniker.Net90 )]
[SimpleJob( RuntimeMoniker.Net80 )]
[SimpleJob( RuntimeMoniker.Net481 )]
public class IsBetween {

    public int argumentValue = 2;
    public int minValue = 1;
    public int maxValue = 3;

    [Benchmark( Baseline = true )]
    public int Baseline() => ( argumentValue >= minValue && argumentValue <= maxValue ) ? argumentValue : throw new ArgumentOutOfRangeException( nameof( argumentValue ) );

    [Benchmark]
    public int ArgumentValidation() => Arg.Is( argumentValue ).Between( minValue, maxValue ).Value;

    [Benchmark]
    public int Dawn_Guard() => Dawn.Guard.Argument( argumentValue ).InRange( minValue, maxValue );

    [Benchmark]
    public int Ardalis_GuardClauses() => Ardalis.GuardClauses.Guard.Against.OutOfRange( argumentValue, nameof( argumentValue ), minValue, maxValue );

    [Benchmark]
    public int CommunityToolkit_Diagnostics() {
        CommunityToolkit.Diagnostics.Guard.IsBetweenOrEqualTo( argumentValue, minValue, maxValue );

        return argumentValue;
    }

    [Benchmark]
    public int Ensure_That() {
        Ensure.That( argumentValue ).IsInRange( minValue, maxValue );

        return argumentValue;
    }
}