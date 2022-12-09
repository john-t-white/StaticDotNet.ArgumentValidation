# Is

Takes the nullability of the argument.  If the argument is nullable, then all other validation checks are based on the argument possibly being null. This is not something that is generally used on it's own and has validation methods chained from it.

## Example

```c#
public void Method( string value ) {
	string result = Arg.Is( value ).Value;
}

public void Method( string? value ) {
	string? result = Arg.Is( value ).Value;
}

public void Method( int value ) {
	int result = Arg.Is( value ).Value;
}

public void Method( int? value ) {
	int? result = Arg.Is( value ).Value;
}
```