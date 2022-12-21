# Arg class

```StaticDotNet.ArgumentValidation.Arg``` is a static class that is the starting point for all argument validation. Additional validations can be chained using a fluent API.

All of the methods allow for the value, name of the argument and a message if you don't want to use the default exception message.  If you are using c# 10, the [CallerArgumentExpressionAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callerargumentexpressionattribute) is supported and you don't need to supply the argument name.

## IsNotNull

Ensures that the argument is not null, otherwise an ArgumentNullException is thrown. Additional validation checks can be chained.


``` c#
Arg.IsNotNull( value );
Arg.IsNotNull( value, name );
Arg.IsNotNull( value, message: message );
Arg.IsNotNull( value, name, message );
```

## IsNotNullOrWhiteSpace

Ensures that the argument is not null or white space, otherwise an ArgumentNullException is thrown. Additional validation checks can be chained.


``` c#
Arg.IsNotNullOrWhiteSpace( value );
Arg.IsNotNullOrWhiteSpace( value, name );
Arg.IsNotNullOrWhiteSpace( value, message: message );
Arg.IsNotNullOrWhiteSpace( value, name, message );
```

## Is

Use for all value type arguments that aren't nullable, or any time you have already ensured the argument is not null.

``` c#
Arg.Is( value );
Arg.Is( value, name );
Arg.Is( value, message: message );
Arg.Is( value, name, message );
```

## Null

Ensures that the argument is null, otherwise an ArgumentException is thrown. ```null``` is returned as it's the only acceptable value.

``` c#
Arg.Null( value );
Arg.Null( value, name );
Arg.Null( value, message: message );
Arg.Null( value, name ), message );
```

All remaining validation checks are based on the argument value is not null. This was done for a couple of reasons:

- The validation code becomes a lot simplier to write and maintain. Otherwise every validation check needs to have additional code to see if the argument is null.
- Code is much easier to follow as it is more explicit in your code that the argument validation is only running if an argument is not null.
- While it isn't a big performance hit, why have it run through every validation check when it will always be null.

# ArgInfo\<T\> / SpanArgInfo\<T\> / ReadOnlySpanArgInfo\<T\>

Every ```Arg``` validation method, with the exception of ```IsNull```, returns a readonly ref struct, ```ArgInfo<T>```, ```SpanArgInfo<T>``` or ```ReadOnlySpanArgInfo<T>```, which allows for chaining additional validation methods based on the result of the previous one. Since it is a ref readonly struct it is only allocated to the stack and prevents copying.

If you want to use the value after all of the argument validations, you can use the Value property.

``` c#
public class User {

	public User( string? name, int age, string phoneNumber ) {

		// Nullability annontations let you set Name property
		// as name argument is not null.
		Name = Arg.IsNotNullOrWhiteSpace( name ).Value;

		// Since age is an int, there is no need to check for null.
		Age = Arg.Is( age ).GreaterThan( 0 ).Value;

		// While phoneNumber isn't nullable, it's always still best practice
		// to check for null.
		PhoneNumber = Arg.IsNotNullOrWhiteSpace( phoneNumber ).Matches( phoneNumberRegex ).Value;
	}

	public string User { get; }

	public int Age { get; }

	public string PhoneNumber { get; }
}
```

Nullability annontations are also fully supported when you don't use the Value property, like when you validate arguments for a method and don't need to assign the result to a variable.

``` c#

public string AppendLetterA( string? value ) {
	_ = Arg.IsNotNullOrWhiteSpace( value );
	// Nullability annontations will say value is not null.
	return value + 'a';
}
```

There are also certain validations which will change the argument type, For example ```ParseInt32```, which will ensure the argument can be parsed into an int and the resulting argument value will be an int.

``` c#
int intValue = Arg.IsNotNullOrWhiteSpace( stringArgument ).ParseInt32().Value;
```

# Included Validations

While the following are included with the library, you can extend the library with your own extension methods for more specific cases.

## Boolean

- False
- True

## Char

- Digit
- Letter
- LetterOrDigit
- Lower
- NotWhiteSpace
- Number
- Upper

## IComparable

- Between
- GreaterThan
- GreaterThanOrEqualTo
- LessThan
- LessThanOrEqualTo

## DateTime

- Local
- Utc

## IEnumerable

- Contains
- Length
- LengthBetween
- MinLength
- MaxLength
- NotEmpty

## Enumeration

- Defined

## Object

- As
- EqualTo
- Same

## ReadOnlySpan

- Contains
- EndsWith
- Length
- LengthBetween
- MaxLength
- MinLength
- NotEmpty
- StartsWith

## ReadOnlySpan\<char\>

- Contains
- EndsWith
- EqualTo
- NotWhiteSpace
- Parse
- ParseByte
- ParseDateOnly
- ParseDateOnlyExact
- ParseDateTime
- ParseDateTimeExact
- ParseDateTimeOffset
- ParseDateTimeOffsetExact
- ParseGuid
- ParseGuidExact
- ParseInt16
- ParseInt32
- ParseInt64
- ParseTimeOnly
- ParseTimeOnyExact
- ParseTimeSpan
- ParseTimeSpanExact
- StartsWith

## Span

- Contains
- EndsWith
- Length
- LengthBetween
- MaxLength
- MinLength
- NotEmpty
- StartsWith

## Stream

- Readable
- Writable

## String

- Contains
- EndsWith
- EqualTo
- Matches
- NotWhiteSpace
- Parse
- ParseBoolean
- ParseByte
- ParseDateOnly
- ParseDateOnlyExact
- ParseDateTime
- ParseDateTimeExact
- ParseDateTimeOffset
- ParseDateTimeOffsetExact
- ParseGuid
- ParseGuidExact
- ParseInt16
- ParseInt32
- ParseInt64
- ParseTimeOnly
- ParseTimeOnyExact
- ParseTimeSpan
- ParseTimeSpanExact
- ParseType
- ParseUri
- StartsWith

## Type

- AssignableTo

## Uri

- Absolute
- Relative
