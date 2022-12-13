# EndsWith

Ensures the argument ends with a value, otherwise an ArgumentException is thrown.

**Parameters**

- value : System.String

**Example**
``` c#
Arg.Is( argument ).EndsWith( value );
```

-----------------------------------------------------------

**Parameters**

- value : System.String
- comparisonType : System.StringComparison

**Example**
``` c#
Arg.Is( argument ).EndsWith( value, comparisonType );
```
