# IsNull

Ensures that the argument is null, otherwise an ArgumentException is thrown. As only null is acceptable, you do not need to use the Value property as null is returned instead of an ArgInfo\<T\> as there is no need for other argument validations.

## Example

``` c#
public void Method( string? value ) {
	string? result = Arg.IsNull( value );
}

Method( "Value" ); // Throws ArgumentException

Method( null ); // Does not throw exception
```