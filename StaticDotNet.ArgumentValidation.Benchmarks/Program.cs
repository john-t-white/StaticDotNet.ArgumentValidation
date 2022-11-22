using BenchmarkDotNet.Running;
using StaticDotNet.ArgumentValidation.Benchmarks;

_ = BenchmarkRunner.Run<NotNullBenchmarks>();
// _ = BenchmarkRunner.Run<NullBenchmarks>();