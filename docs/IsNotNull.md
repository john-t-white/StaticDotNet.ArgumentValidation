# IsNotNull

Ensures that the argument is not null, otherwise an ArgumentNullException is thrown. Additional validation checks can be chained.

**Example**
``` c#
public void Method( string? value ) {
	string result = Arg.IsNull( value ).Value;
}

Method( "Value" ); // Does not throw exception

Method( null ); // Throws ArgumentNullException
```