# AssignableTo

Ensures the argument is assignable to the specific type, otherwise an ArgumentException is thrown.

## System.Type

**Parameters**

- value : System.Type

**Example**

``` c#
ArgInfo<T> AssignableTo<T>( in this ArgInfo<T> argInfo, [DisallowNull] T type )
		where T : Type?
```

**Benchmarks**

|             Method |       Runtime |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |-------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|           Baseline |      .NET 6.0 |  9.946 ns | 0.1898 ns | 0.1776 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation |      .NET 6.0 | 16.129 ns | 0.3888 ns | 0.3637 ns |  1.62 |    0.05 |         - |          NA |
|        Ensure_That |      .NET 6.0 |  8.829 ns | 0.1420 ns | 0.1259 ns |  0.89 |    0.01 |         - |          NA |
|                    |               |           |           |           |       |         |           |             |
|           Baseline |      .NET 7.0 |  6.825 ns | 0.1378 ns | 0.1289 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation |      .NET 7.0 | 12.171 ns | 0.2754 ns | 0.2576 ns |  1.78 |    0.03 |         - |          NA |
|        Ensure_That |      .NET 7.0 |  8.812 ns | 0.1976 ns | 0.1752 ns |  1.29 |    0.03 |         - |          NA |
|                    |               |           |           |           |       |         |           |             |
|           Baseline | .NET Core 3.1 | 43.945 ns | 0.7396 ns | 0.6918 ns |  1.00 |    0.00 |         - |          NA |
| ArgumentValidation | .NET Core 3.1 | 64.725 ns | 0.5934 ns | 0.5260 ns |  1.47 |    0.03 |         - |          NA |
|        Ensure_That | .NET Core 3.1 | 47.931 ns | 0.7777 ns | 0.7274 ns |  1.09 |    0.03 |         - |          NA |
