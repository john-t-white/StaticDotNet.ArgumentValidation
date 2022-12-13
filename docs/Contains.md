# Contains

Ensures the argument contains a System.String value, otherwise an ArgumentException is thrown.

## System.String

**Example**
``` c#
Arg.Is( argument ).Contains( value );

Arg.Is( argument ).Contains( value, comparisonType );
```

## System.Collections.Generic.IEnumerable\<T\>

**Example**
``` c#
Arg.Is( argument ).Contains( value );

Arg.Is( argument ).Contains( value, comparer );
```
