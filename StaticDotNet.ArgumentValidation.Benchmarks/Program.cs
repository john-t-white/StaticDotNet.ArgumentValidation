using BenchmarkDotNet.Running;
using StaticDotNet.ArgumentValidation.Benchmarks;

//_ = BenchmarkRunner.Run<NotNullBenchmarks>();
//_ = BenchmarkRunner.Run<NullBenchmarks>();
//_ = BenchmarkRunner.Run<TrueBenchmarks>();
//_ = BenchmarkRunner.Run<NullableTrueBenchmarks>();
_ = BenchmarkRunner.Run<NotNullTrueBenchmarks>();
