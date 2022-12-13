# Contains

Ensures the argument contains the value, otherwise an ArgumentException is thrown.

## System.String

**Parameters**

- value : System.String

**Example**
``` c#
Arg.Is( argument ).Contains( value );
```

-----------------------------------------------------------

**Parameters**

- value : System.String
- comparisonType : System.StringComparison

**Example**
``` c#
Arg.Is( argument ).Contains( value, comparisonType );
```

## System.Collections.Generic.IEnumerable\<T\>

**Parameters**

- value : \<T\>

**Example**
``` c#
Arg.Is( argument ).Contains( value );
```

-----------------------------------------------------------

**Parameters**

- value : \<T\>
- comparer: System.Collection.Generics.IEqualityComparer\<T\>

**Example**
``` c#
Arg.Is( argument ).Contains( value, comparer );
```
