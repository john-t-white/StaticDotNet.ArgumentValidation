# Between

Ensures the argument is between (inclusively) a minValue and maxValue, otherwise an ArgumentOutOfRangeException is thrown.

## System.IComparable\<T\>

**Example**

``` c#
Arg.Is( argument ).Between( minValue, maxValue );
```

**Benchmarks**

|               Method |           Job |       Runtime |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------- |-------------- |-------------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
|             Baseline |      .NET 6.0 |      .NET 6.0 | 0.1387 ns | 0.0347 ns | 0.0961 ns | 0.1082 ns |  1.00 |    0.00 |         - |          NA |
|   ArgumentValidation |      .NET 6.0 |      .NET 6.0 | 3.0907 ns | 0.0374 ns | 0.0350 ns | 3.0917 ns | 13.16 |    3.85 |         - |          NA |
|           Dawn_Guard |      .NET 6.0 |      .NET 6.0 | 3.0655 ns | 0.0179 ns | 0.0167 ns | 3.0687 ns | 13.04 |    3.78 |         - |          NA |
| Ardalis_GuardClauses |      .NET 6.0 |      .NET 6.0 | 2.0558 ns | 0.0211 ns | 0.0187 ns | 2.0536 ns |  8.96 |    2.58 |         - |          NA |
|          Ensure_That |      .NET 6.0 |      .NET 6.0 | 2.2575 ns | 0.0268 ns | 0.0250 ns | 2.2576 ns |  9.60 |    2.76 |         - |          NA |
|                      |               |               |           |           |           |           |       |         |           |             |
|             Baseline |      .NET 7.0 |      .NET 7.0 | 0.0050 ns | 0.0060 ns | 0.0056 ns | 0.0039 ns |     ? |       ? |         - |           ? |
|   ArgumentValidation |      .NET 7.0 |      .NET 7.0 | 2.1211 ns | 0.0257 ns | 0.0228 ns | 2.1231 ns |     ? |       ? |         - |           ? |
|           Dawn_Guard |      .NET 7.0 |      .NET 7.0 | 1.9435 ns | 0.0121 ns | 0.0101 ns | 1.9423 ns |     ? |       ? |         - |           ? |
| Ardalis_GuardClauses |      .NET 7.0 |      .NET 7.0 | 1.9149 ns | 0.0238 ns | 0.0211 ns | 1.9156 ns |     ? |       ? |         - |           ? |
|          Ensure_That |      .NET 7.0 |      .NET 7.0 | 2.0305 ns | 0.0224 ns | 0.0198 ns | 2.0294 ns |     ? |       ? |         - |           ? |
|                      |               |               |           |           |           |           |       |         |           |             |
|             Baseline | .NET Core 3.1 | .NET Core 3.1 | 0.2554 ns | 0.0064 ns | 0.0057 ns | 0.2542 ns |  1.00 |    0.00 |         - |          NA |
|   ArgumentValidation | .NET Core 3.1 | .NET Core 3.1 | 8.6860 ns | 0.0804 ns | 0.0713 ns | 8.6731 ns | 34.02 |    0.89 |         - |          NA |
|           Dawn_Guard | .NET Core 3.1 | .NET Core 3.1 | 4.7976 ns | 0.0698 ns | 0.0653 ns | 4.7905 ns | 18.81 |    0.39 |         - |          NA |
| Ardalis_GuardClauses | .NET Core 3.1 | .NET Core 3.1 | 1.7923 ns | 0.0179 ns | 0.0158 ns | 1.7924 ns |  7.02 |    0.18 |         - |          NA |
|          Ensure_That | .NET Core 3.1 | .NET Core 3.1 | 2.1162 ns | 0.0495 ns | 0.0439 ns | 2.1179 ns |  8.29 |    0.27 |         - |          NA |