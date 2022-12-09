Need to document the following:

- Trimming
- Benchmarks

# Arg class

Arg is a static class that is the starting point for all argument validation. It has three basic methods, and all of them support nullability annontations.

- [Is](Is.md)
- [IsNotNull](IsNotNull.md)
- [IsNull](IsNull.md)

All of the methods allow for the value, name of the argument and if a message if you don't want to use the default exception message.  If you are using c# 10, the [CallerArgumentExpressionAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callerargumentexpressionattribute) is supported and you don't need to supply the argument name. Everything is under the StaticDotNet.ArgumentValidation namespace.

```c#
using StaticDotNet.ArgumentValidation;

Arg.IsNotNull( value );
Arg.IsNotNull( value, nameof( value ) );
Arg.IsNotNull( value, message: message );
Arg.IsNotNull( value, nameof( value ) ), message );
```

If you want to use the value after all of the argument validations, you can use the Value property.

```c#
public class Person {

	public Person( string? name ) {

		// Nullability annontations let you set Name property
		// as name argument is not null.
		Name = Arg.IsNotNull( name ).Value;
	}

	public string Name { get; }
}
```

Nullability annontations are also fully supported when you don't use the Value property, like when you validate arguments for a method.

```c#

public string AppendLetterA( string? value ) {
	_ = Arg.IsNotNull( value );
	// Nullability annontations will say value is not null.
	return value + 'a';
}
```

# ArgInfo\<T\>

Every argument validation method returns a readonly ref struct ArgInfo\<T\> which allows for chaining additional validation methods based on the result of the previous one. Since it is a ref readonly struct it is only allocated to the stack and prevents copying. All remaining validation checks will always return null if the argument is allowed to be null. This allows you to validate arguments if they aren't null, but still allow them to be null.

# Trimming

The library includes the specific attributes and analyzers to ensure it can be trimmed.  This allows you to only include the validations that are used within you application when you enable trimming.

# Included Validations

While the following are included with the library, you can add extend the library with your own extension methods for more specific cases.

## Object

Valdiation methods for any type.

- [EqualTo](EqualTo.md)

## Comparable

Validation methods types that implement System.IComparable\<T\>.

- [Between](Between.md)
- [GreaterThan](GreaterThan.md)
- [GreaterThanOrEqualTo](GreaterThanOrEqualTo.md)
- [LessThan](LessThan.md)
- [LessThanOrEqualTo](LessThanOrEqualTo.md)

## Enumerable

Validation methods for types that implement System.IEnumerable, which includes string.

- [Length](Length.md)
- [LengthBetween](LengthBetween.md)
- [MaxLength](MaxLength.md)
- [MinLength](MinLength.md)
- [NotEmpty](NotEmpty.md)

## String

Validation methods for string arguments.

- [Contains](Contains.md)
- [EndsWith](EndsWith.md)
- [NotWhiteSpace](NotWhiteSpace.md)
- [Matches](Matches.md)
- [StartsWith](StartsWith.md)
- [ToType](ToType.md)
- [ToTypeMaybeNull](ToTypeMaybeNull.md)

## Type

Validation metohds for System.Type arguments

- [AssignableTo](AssignableTo.md)
