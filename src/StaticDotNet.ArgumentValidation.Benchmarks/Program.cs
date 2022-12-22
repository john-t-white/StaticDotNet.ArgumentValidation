using BenchmarkDotNet.Running;
using StaticDotNet.ArgumentValidation.Benchmarks;

//_ = BenchmarkRunner.Run<Between>();
_ = BenchmarkRunner.Run<IsNotEmptyArray>();
//_ = BenchmarkRunner.Run<IsNotNull>();
//_ = BenchmarkRunner.Run<IsNotNullOrWhiteSpace>();
