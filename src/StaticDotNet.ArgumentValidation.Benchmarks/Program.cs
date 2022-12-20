using BenchmarkDotNet.Running;
using StaticDotNet.ArgumentValidation.Benchmarks;

//_ = BenchmarkRunner.Run<Is_Between>();
_ = BenchmarkRunner.Run<IsNotNull>();
//_ = BenchmarkRunner.Run<IsNotNull_AssignableTo>();
//_ = BenchmarkRunner.Run<IsNotNullOrWhiteSpace>();
//_ = BenchmarkRunner.Run<IsNotNull_NotWhiteSpace_ToBoolean>();
