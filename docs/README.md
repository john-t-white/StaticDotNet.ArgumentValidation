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

# ArgInfo\<T\>

Every argument validation method, with the exception of ```IsNull```, returns a readonly ref struct, ```ArgInfo<T>```, which allows for chaining additional validation methods based on the result of the previous one. Since it is a ref readonly struct it is only allocated to the stack and prevents copying.

If you want to use the value after all of the argument validations, you can use the Value property.

``` c#
public class User {

	public User( string? name ) {

		// Nullability annontations let you set Name property
		// as name argument is not null.
		Name = Arg.IsNotNull( name ).NotWhiteSpace().Value;
	}

	public string User { get; }
}
```

Nullability annontations are also fully supported when you don't use the Value property, like when you validate arguments for a method and don't need to assign the result to a variable.

``` c#

public string AppendLetterA( string? value ) {
	_ = Arg.IsNotNull( value ).NotWhiteSpace();
	// Nullability annontations will say value is not null.
	return value + 'a';
}
```

The Value property will always be the specific type for that argument.  For example, if you have a custom class that implements IList, the value should always return the your custom class, not IList, unless a specific argument validation is used to change to a different type.  For example, ToType allows you to validate a string argument represents a type which will then have the value as System.Type.

``` c#

public string MyMethod( string typeFullName ) {
	Type type = Arg.IsNotNull( typeFullName ).ToType();
}
```

# Included Validations

While the following are included with the library, you can add extend the library with your own extension methods for more specific cases. All validation checks will return null if the argument is allowed to be null. This allows you to validate arguments if they aren't null, but still allow them to be null.

- [AssignableTo](AssignableTo.md)
- [Between](Between.md)
- [Contains](Contains.md)
- [EndsWith](EndsWith.md)
- [EqualTo](EqualTo.md)
- [GreaterThan](GreaterThan.md)
- [GreaterThanOrEqualTo](GreaterThanOrEqualTo.md)
- [Length](Length.md)
- [LengthBetween](LengthBetween.md)
- [LessThan](LessThan.md)
- [LessThanOrEqualTo](LessThanOrEqualTo.md)
- [Matches](Matches.md)
- [MaxLength](MaxLength.md)
- [MinLength](MinLength.md)
- [NotEmpty](NotEmpty.md)
- [NotWhiteSpace](NotWhiteSpace.md)
- [StartsWith](StartsWith.md)
- ToInt32
- [ToType / ToTypeMaybeNull](ToType.md)
