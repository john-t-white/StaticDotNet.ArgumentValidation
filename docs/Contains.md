# Contains

Ensures the argument contains a value, otherwise an ArgumentException is thrown.

**Example**
``` c#
Arg.Is( argument ).EqualTo( value );

Arg.Is( argument ).EqualTo( value, comparer );
```

## String (>= .NET Standard 2.0)

For string arguments, an additional overload allows you to specify the [StringComparision](https://learn.microsoft.com/en-us/dotnet/api/system.stringcomparison) type to use.

**Example**
``` c#
Arg.Is( argument ).EqualTo( value, StringComparision.OrdinalIgnoreCase );
```
