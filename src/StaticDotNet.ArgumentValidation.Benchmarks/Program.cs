using BenchmarkDotNet.Running;
using StaticDotNet.ArgumentValidation.Benchmarks;

//_ = BenchmarkRunner.Run<Is_Between>();
_ = BenchmarkRunner.Run<IsNotNull_AssignableTo>();
