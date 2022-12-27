# Benchmarks

I ran benchmarks using a baseline of writing the guard code as you would without any library as well as comparing this library with other guard libaries to get all of the performance metrics.

All of the benchmark source code is under src/StaticDotNet.ArgumentValidation.Benchmarks.

**Machine**

```
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.963)
Intel Core i7-10750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.101
  [Host]   : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
```

## IsNotNull

**.NET 7.0**

|                       Method |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|----------:|------------:|
|                     Baseline |  0.8457 ns | 0.0691 ns | 0.0647 ns |  0.8565 ns |  1.00 |    0.00 |         - |          NA |
|           ArgumentValidation |  0.6786 ns | 0.0303 ns | 0.0283 ns |  0.6782 ns |  0.81 |    0.07 |         - |          NA |
|                   Dawn_Guard | 12.4283 ns | 0.2788 ns | 0.2608 ns | 12.3970 ns | 14.77 |    1.11 |      40 B |          NA |
|         Ardalis_GuardClauses |  1.1176 ns | 0.0578 ns | 0.0512 ns |  1.1014 ns |  1.32 |    0.11 |         - |          NA |
| CommunityToolkit_Diagnostics |  0.6712 ns | 0.0308 ns | 0.0273 ns |  0.6699 ns |  0.79 |    0.05 |         - |          NA |
|                  Ensure_That |  0.9368 ns | 0.0339 ns | 0.0318 ns |  0.9360 ns |  1.11 |    0.09 |         - |          NA |

**.NET 6.0**

|                       Method |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|----------:|------------:|
|                     Baseline |  0.2163 ns | 0.0195 ns | 0.0182 ns |  0.2175 ns |  1.00 |    0.00 |         - |          NA |
|           ArgumentValidation |  0.0137 ns | 0.0282 ns | 0.0263 ns |  0.0000 ns |  0.07 |    0.13 |         - |          NA |
|                   Dawn_Guard | 11.3648 ns | 0.1765 ns | 0.1565 ns | 11.3443 ns | 53.09 |    4.70 |      40 B |          NA |
|         Ardalis_GuardClauses |  0.4241 ns | 0.0269 ns | 0.0251 ns |  0.4156 ns |  1.97 |    0.20 |         - |          NA |
| CommunityToolkit_Diagnostics |  0.4085 ns | 0.0240 ns | 0.0225 ns |  0.4102 ns |  1.90 |    0.18 |         - |          NA |
|                  Ensure_That |  0.2117 ns | 0.0377 ns | 0.0352 ns |  0.1980 ns |  0.98 |    0.18 |         - |          NA |

## IsNotNullOrWhiteSpace

**.NET 7.0**

|                       Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |---------:|----------:|----------:|------:|--------:|----------:|------------:|
|                     Baseline | 2.229 ns | 0.0622 ns | 0.0582 ns |  1.00 |    0.00 |         - |          NA |
|           ArgumentValidation | 2.724 ns | 0.1034 ns | 0.0968 ns |  1.22 |    0.06 |         - |          NA |
|                   Dawn_Guard | 6.391 ns | 0.1796 ns | 0.1764 ns |  2.87 |    0.14 |         - |          NA |
|         Ardalis_GuardClauses | 3.710 ns | 0.0972 ns | 0.0909 ns |  1.67 |    0.05 |         - |          NA |
| CommunityToolkit_Diagnostics | 2.279 ns | 0.0617 ns | 0.0547 ns |  1.02 |    0.04 |         - |          NA |
|                  Ensure_That | 3.309 ns | 0.0685 ns | 0.0607 ns |  1.48 |    0.05 |         - |          NA |

**.NET 6.0**

|                       Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |---------:|----------:|----------:|------:|--------:|----------:|------------:|
|                     Baseline | 1.686 ns | 0.0300 ns | 0.0281 ns |  1.00 |    0.00 |         - |          NA |
|           ArgumentValidation | 1.817 ns | 0.0727 ns | 0.0680 ns |  1.08 |    0.04 |         - |          NA |
|                   Dawn_Guard | 5.584 ns | 0.0999 ns | 0.0934 ns |  3.31 |    0.07 |         - |          NA |
|         Ardalis_GuardClauses | 5.100 ns | 0.0570 ns | 0.0505 ns |  3.03 |    0.06 |         - |          NA |
| CommunityToolkit_Diagnostics | 1.909 ns | 0.0793 ns | 0.0742 ns |  1.13 |    0.04 |         - |          NA |
|                  Ensure_That | 3.141 ns | 0.1176 ns | 0.1100 ns |  1.86 |    0.08 |         - |          NA |

## Is_Between

**.NET 7.0**

|                       Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
|                     Baseline | 0.0093 ns | 0.0153 ns | 0.0135 ns | 0.0021 ns |     ? |       ? |         - |           ? |
|           ArgumentValidation | 1.9734 ns | 0.0676 ns | 0.0778 ns | 1.9425 ns |     ? |       ? |         - |           ? |
|                   Dawn_Guard | 2.1409 ns | 0.0517 ns | 0.0483 ns | 2.1263 ns |     ? |       ? |         - |           ? |
|         Ardalis_GuardClauses | 1.9418 ns | 0.0646 ns | 0.0604 ns | 1.9223 ns |     ? |       ? |         - |           ? |
| CommunityToolkit_Diagnostics | 0.2726 ns | 0.0106 ns | 0.0099 ns | 0.2703 ns |     ? |       ? |         - |           ? |
|                  Ensure_That | 2.0380 ns | 0.0448 ns | 0.0419 ns | 2.0330 ns |     ? |       ? |         - |           ? |

**.NET 6.0**

|                       Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
|                     Baseline | 0.0980 ns | 0.0160 ns | 0.0150 ns | 0.0996 ns |  1.00 |    0.00 |         - |          NA |
|           ArgumentValidation | 2.6429 ns | 0.0544 ns | 0.0509 ns | 2.6442 ns | 27.59 |    4.40 |         - |          NA |
|                   Dawn_Guard | 2.8464 ns | 0.0573 ns | 0.0536 ns | 2.8484 ns | 29.69 |    4.67 |         - |          NA |
|         Ardalis_GuardClauses | 2.2606 ns | 0.0668 ns | 0.0625 ns | 2.2301 ns | 23.58 |    3.72 |         - |          NA |
| CommunityToolkit_Diagnostics | 0.5532 ns | 0.0099 ns | 0.0088 ns | 0.5525 ns |  5.80 |    0.98 |         - |          NA |
|                  Ensure_That | 2.5407 ns | 0.0649 ns | 0.0607 ns | 2.5187 ns | 26.51 |    4.22 |         - |          NA |

## Is_NotEmpty (Array)

**.NET 7.0**

|                       Method |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|----------:|------------:|
|                     Baseline |  0.7688 ns | 0.0181 ns | 0.0142 ns |  0.7730 ns |  1.00 |    0.00 |         - |          NA |
|           ArgumentValidation |  2.4578 ns | 0.1030 ns | 0.0964 ns |  2.4297 ns |  3.20 |    0.15 |         - |          NA |
|                   Dawn_Guard |  7.3657 ns | 0.1973 ns | 0.1845 ns |  7.4235 ns |  9.52 |    0.26 |         - |          NA |
|         Ardalis_GuardClauses |  9.3892 ns | 0.0719 ns | 0.0672 ns |  9.3811 ns | 12.22 |    0.22 |         - |          NA |
| CommunityToolkit_Diagnostics |  0.6573 ns | 0.0227 ns | 0.0212 ns |  0.6544 ns |  0.85 |    0.03 |         - |          NA |
|                  Ensure_That |  3.0095 ns | 0.0492 ns | 0.0460 ns |  2.9987 ns |  3.92 |    0.08 |         - |          NA |

**.NET 6.0**

|                       Method |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|----------:|------------:|
|                     Baseline |  0.0019 ns | 0.0046 ns | 0.0043 ns |  0.0000 ns |     ? |       ? |         - |           ? |
|           ArgumentValidation |  6.9347 ns | 0.0972 ns | 0.0909 ns |  6.9425 ns |     ? |       ? |         - |           ? |
|                   Dawn_Guard |  6.9180 ns | 0.0853 ns | 0.0756 ns |  6.9056 ns |     ? |       ? |         - |           ? |
|         Ardalis_GuardClauses | 15.5611 ns | 0.1655 ns | 0.1467 ns | 15.5066 ns |     ? |       ? |         - |           ? |
| CommunityToolkit_Diagnostics |  0.3880 ns | 0.0178 ns | 0.0158 ns |  0.3862 ns |     ? |       ? |         - |           ? |
|                  Ensure_That |  2.6520 ns | 0.0429 ns | 0.0402 ns |  2.6421 ns |     ? |       ? |         - |           ? |

## IsNotNull_NotEmpty (IList)

**.NET 7.0**

|                       Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|                     Baseline |  2.400 ns | 0.0372 ns | 0.0330 ns |  1.00 |    0.00 |         - |          NA |
|           ArgumentValidation | 11.039 ns | 0.2811 ns | 0.3941 ns |  4.54 |    0.22 |         - |          NA |
|                   Dawn_Guard | 58.875 ns | 1.2308 ns | 2.1557 ns | 24.56 |    0.64 |         - |          NA |
|         Ardalis_GuardClauses |  6.870 ns | 0.0799 ns | 0.0748 ns |  2.86 |    0.06 |         - |          NA |
| CommunityToolkit_Diagnostics |  2.384 ns | 0.0185 ns | 0.0164 ns |  0.99 |    0.01 |         - |          NA |
|                  Ensure_That |  4.600 ns | 0.0728 ns | 0.0645 ns |  1.92 |    0.04 |         - |          NA |

**.NET 6.0**

|                       Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|                     Baseline |  1.631 ns | 0.0395 ns | 0.0351 ns |  1.00 |    0.00 |         - |          NA |
|           ArgumentValidation | 10.126 ns | 0.1285 ns | 0.1073 ns |  6.22 |    0.19 |         - |          NA |
|                   Dawn_Guard | 56.431 ns | 1.1911 ns | 1.5901 ns | 34.05 |    0.93 |         - |          NA |
|         Ardalis_GuardClauses | 10.033 ns | 0.2520 ns | 0.2475 ns |  6.15 |    0.17 |         - |          NA |
| CommunityToolkit_Diagnostics |  1.955 ns | 0.0999 ns | 0.1026 ns |  1.19 |    0.07 |         - |          NA |
|                  Ensure_That |  4.015 ns | 0.0530 ns | 0.0470 ns |  2.46 |    0.06 |         - |          NA |

## IsNotNullOrWhiteSpace_Length (String)

**.NET 7.0**

|                       Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |---------:|----------:|----------:|------:|--------:|----------:|------------:|
|                     Baseline | 2.431 ns | 0.1078 ns | 0.1324 ns |  1.00 |    0.00 |         - |          NA |
|           ArgumentValidation | 4.098 ns | 0.1362 ns | 0.1722 ns |  1.69 |    0.09 |         - |          NA |
|                   Dawn_Guard | 7.344 ns | 0.2048 ns | 0.2663 ns |  3.04 |    0.21 |         - |          NA |
| CommunityToolkit_Diagnostics | 2.544 ns | 0.0553 ns | 0.0518 ns |  1.03 |    0.05 |         - |          NA |
|                  Ensure_That | 4.872 ns | 0.1549 ns | 0.2222 ns |  2.03 |    0.13 |         - |          NA |

**.NET 6.0**

|                       Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------- |---------:|----------:|----------:|------:|--------:|----------:|------------:|
|                     Baseline | 1.739 ns | 0.0831 ns | 0.0777 ns |  1.00 |    0.00 |         - |          NA |
|           ArgumentValidation | 3.962 ns | 0.1391 ns | 0.1546 ns |  2.29 |    0.13 |         - |          NA |
|                   Dawn_Guard | 7.027 ns | 0.2054 ns | 0.2523 ns |  4.06 |    0.22 |         - |          NA |
| CommunityToolkit_Diagnostics | 2.373 ns | 0.1069 ns | 0.1000 ns |  1.37 |    0.08 |         - |          NA |
|                  Ensure_That | 5.063 ns | 0.1631 ns | 0.2539 ns |  2.91 |    0.20 |         - |          NA |
