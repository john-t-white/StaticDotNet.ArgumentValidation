# AssignableTo

Ensures the argument is assignable to the specific type, otherwise an ArgumentException is thrown.

## System.Type

**Parameters**

- value : System.Type

**Example**

``` c#
Arg.Is( argument ).AssignableTo( value );
```

**Benchmarks**

|             Method |           Job |       Runtime |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |-------------- |-------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|           Baseline |      .NET 6.0 |      .NET 6.0 |  9.946 ns | 0.1898 ns | 0.1776 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation |      .NET 6.0 |      .NET 6.0 | 16.129 ns | 0.3888 ns | 0.3637 ns |  1.62 |    0.05 |         - |          NA |
|        Ensure_That |      .NET 6.0 |      .NET 6.0 |  8.829 ns | 0.1420 ns | 0.1259 ns |  0.89 |    0.01 |         - |          NA |
|                    |               |               |           |           |           |       |         |           |             |
|           Baseline |      .NET 7.0 |      .NET 7.0 |  6.825 ns | 0.1378 ns | 0.1289 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation |      .NET 7.0 |      .NET 7.0 | 12.171 ns | 0.2754 ns | 0.2576 ns |  1.78 |    0.03 |         - |          NA |
|        Ensure_That |      .NET 7.0 |      .NET 7.0 |  8.812 ns | 0.1976 ns | 0.1752 ns |  1.29 |    0.03 |         - |          NA |
|                    |               |               |           |           |           |       |         |           |             |
|           Baseline | .NET Core 3.1 | .NET Core 3.1 | 43.945 ns | 0.7396 ns | 0.6918 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation | .NET Core 3.1 | .NET Core 3.1 | 64.725 ns | 0.5934 ns | 0.5260 ns |  1.47 |    0.03 |         - |          NA |
|        Ensure_That | .NET Core 3.1 | .NET Core 3.1 | 47.931 ns | 0.7777 ns | 0.7274 ns |  1.09 |    0.03 |         - |          NA |

## System.Reflection.TypeInfo

**Parameters**

- value : System.Reflection.TypeInfo

**Example**

``` c#
Arg.Is( argument ).AssignableTo( value );
```

**Benchmarks**

|             Method |           Job |       Runtime |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |-------------- |-------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|           Baseline |      .NET 6.0 |      .NET 6.0 |  7.776 ns | 0.1806 ns | 0.1689 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation |      .NET 6.0 |      .NET 6.0 | 14.658 ns | 0.1654 ns | 0.1466 ns |  1.88 |    0.04 |         - |          NA |
|        Ensure_That |      .NET 6.0 |      .NET 6.0 |  8.008 ns | 0.1363 ns | 0.1275 ns |  1.03 |    0.03 |         - |          NA |
|                    |               |               |           |           |           |       |         |           |             |
|           Baseline |      .NET 7.0 |      .NET 7.0 |  7.606 ns | 0.1310 ns | 0.1161 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation |      .NET 7.0 |      .NET 7.0 | 12.835 ns | 0.1163 ns | 0.0971 ns |  1.69 |    0.03 |         - |          NA |
|        Ensure_That |      .NET 7.0 |      .NET 7.0 |  8.664 ns | 0.0771 ns | 0.0684 ns |  1.14 |    0.02 |         - |          NA |
|                    |               |               |           |           |           |       |         |           |             |
|           Baseline | .NET Core 3.1 | .NET Core 3.1 | 45.872 ns | 0.2440 ns | 0.2037 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation | .NET Core 3.1 | .NET Core 3.1 | 63.820 ns | 0.9223 ns | 0.8627 ns |  1.39 |    0.02 |         - |          NA |
|        Ensure_That | .NET Core 3.1 | .NET Core 3.1 | 47.799 ns | 0.5822 ns | 0.5446 ns |  1.04 |    0.01 |         - |          NA |
