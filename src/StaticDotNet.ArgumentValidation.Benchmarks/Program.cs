using BenchmarkDotNet.Running;
using StaticDotNet.ArgumentValidation.Benchmarks;

_ = BenchmarkRunner.Run<IsNotNull_AssignableTo>();
