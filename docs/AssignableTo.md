# AssignableTo

## System.Type

Ensures a System.Type argument is assignable to the specific System.Type, otherwise an ArgumentException is thrown.

**Example**

``` c#
Arg.Is( argument ).AssignableTo( value );
```

**Benchmarks**

|             Method |           Job |       Runtime |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |-------------- |-------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|           Baseline |      .NET 6.0 |      .NET 6.0 |  7.413 ns | 0.0806 ns | 0.0754 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation |      .NET 6.0 |      .NET 6.0 | 14.971 ns | 0.2035 ns | 0.1804 ns |  2.02 |    0.03 |         - |          NA |
|                    |               |               |           |           |           |       |         |           |             |
|           Baseline |      .NET 7.0 |      .NET 7.0 |  7.564 ns | 0.1300 ns | 0.1085 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation |      .NET 7.0 |      .NET 7.0 | 12.359 ns | 0.2950 ns | 0.3397 ns |  1.65 |    0.04 |         - |          NA |
|                    |               |               |           |           |           |       |         |           |             |
|           Baseline | .NET Core 3.1 | .NET Core 3.1 | 43.321 ns | 0.7485 ns | 0.6635 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation | .NET Core 3.1 | .NET Core 3.1 | 64.694 ns | 0.4837 ns | 0.4039 ns |  1.50 |    0.02 |         - |          NA |

## System.Reflection.TypeInfo

Ensures a System.Reflection.TypeInfo argument is assignable to the specific System.Reflection.TypeInfo, otherwise an ArgumentException is thrown.

**Example**

``` c#
Arg.Is( argument ).AssignableTo( value );
```

**Benchmarks**

|             Method |           Job |       Runtime |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |-------------- |-------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|           Baseline |      .NET 6.0 |      .NET 6.0 |  7.633 ns | 0.2182 ns | 0.2598 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation |      .NET 6.0 |      .NET 6.0 | 15.750 ns | 0.1860 ns | 0.1649 ns |  2.06 |    0.07 |         - |          NA |
|                    |               |               |           |           |           |       |         |           |             |
|           Baseline |      .NET 7.0 |      .NET 7.0 |  7.526 ns | 0.0520 ns | 0.0487 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation |      .NET 7.0 |      .NET 7.0 | 12.796 ns | 0.1102 ns | 0.0920 ns |  1.70 |    0.02 |         - |          NA |
|                    |               |               |           |           |           |       |         |           |             |
|           Baseline | .NET Core 3.1 | .NET Core 3.1 | 44.857 ns | 0.4645 ns | 0.4345 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation | .NET Core 3.1 | .NET Core 3.1 | 64.166 ns | 0.2793 ns | 0.2333 ns |  1.43 |    0.02 |         - |          NA |
