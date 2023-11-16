using BenchmarkDotNet.Running;
using StaticDotNet.ArgumentValidation.Benchmarks;

//_ = BenchmarkRunner.Run<IsBetween>();
//_ = BenchmarkRunner.Run<IsNotEmptyArray>();
//_ = BenchmarkRunner.Run<IsNotNull_NotEmptyList>();
_ = BenchmarkRunner.Run<IsNotNull>();
//_ = BenchmarkRunner.Run<IsNotNullOrWhiteSpaceLengthString>();
//_ = BenchmarkRunner.Run<IsNotNullOrWhiteSpace>();
