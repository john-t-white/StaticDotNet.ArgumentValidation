using BenchmarkDotNet.Running;
using StaticDotNet.ArgumentValidation.Benchmarks;

//_ = BenchmarkRunner.Run<NotNullClassBenchmarks>();
//_ = BenchmarkRunner.Run<NotNullStructBenchmarks>();
//_ = BenchmarkRunner.Run<NullBenchmarks>();
//_ = BenchmarkRunner.Run<TrueBenchmarks>();
//_ = BenchmarkRunner.Run<NullableTrueBenchmarks>();
//_ = BenchmarkRunner.Run<NotNullTrueBenchmarks>();
//_ = BenchmarkRunner.Run<NotNullOrWhiteSpaceBenchmarks>();
//_ = BenchmarkRunner.Run<NotNullOrEmptyArrayBenchmarks>();
//_ = BenchmarkRunner.Run<NotNullOrEmptyIListBenchmarks>();
//_ = BenchmarkRunner.Run<NotNullOrEmptyICollectionBenchmarks>();
//_ = BenchmarkRunner.Run<EqualToStructBenchmarks>();
//_ = BenchmarkRunner.Run<NotNullEqualToStructBenchmarks>();
//_ = BenchmarkRunner.Run<NotNullNotEqualToStructBenchmarks>();
//_ = BenchmarkRunner.Run<GreaterThanClassBenchmarks>();
//_ = BenchmarkRunner.Run<GreaterThanNullableStructBenchmarks>();
_ = BenchmarkRunner.Run<BetweenStructBenchmarks>();
