StaticDotNet.ArgumentValiation is a nullability annotation supported fluent guard library with performance and ease of use in mind.

**Supports:**
- Nullability
- CallerArgumentExpressionAttribute
- Span/ReadOnlySpan
- Trimming

# Installation

Package can install via NuGet and can be found at https://www.nuget.org/packages/StaticDotNet.ArgumentValidation.

# Nullability annotations makes guard clauses pointless

While nullability annontations is a huge step forward in helping us developers write better applications (which we don't need as we get it right 100% of the time), it doesn't replace the need for guard clauses. And most of the guard libraries aren't able to fully support nullability annotations, which means you have to constantly ignore those warnings which really makes nullability annotations less helpful. And without them you have a bigger chance of getting the fun "Object not set to an instance of an object" error. If you haven't had to look at the stack trace, open a method of over 500 lines of code and tried to figure out what could possible be null in some random situation, you haven't lived.

If you are writing libraries that other developers/applications are using, your code has no way of knowing if nullability annontations are turned on.  Or worse case those warnings are just ignored anyway. Not you of course, you are one of the good developers, hence why you are here.

Lastly nullability annotations only help with checking for null. It doesn't help with the other requirements that parameters have.

# This is what validation is for

Validation is focused on the end user, guard clauses are focused on developers. This is a big difference and why guard clauses are still important. The point of a guard clause is to prevent a developer from doing something that will always result in an issue with the application. Validation is focused on helping the end user accomplish a specific work flow based on the business requirements while adhering to the limitations of the application. Both are important, but serve completely different purposes.

# Performance

Since the point of guard clauses are to ensure the developer doesn't write bad code, ideally they should never throw an exception.  This library is built around the idea that it should be just as fast as possible and avoid allocating any memory with the idea that the exception will not happen.

It also uses a readonly ref struct so as much as possible stays on the stack without copying the struct on every call.

# Trimming

The library includes the specific attributes and analyzers to ensure it can be trimmed.  This allows you to only include the validations that are used within you application when you enable trimming.

# Writing guard clauses are ugly

Yes, writing guard clauses are ugly and they take up a lot of space.  We all agree they are important but they take up too many lines of code and are ugly.  Ok, maybe you don't agree, yet, but drink the Kool-Aid and I promise no space ships are involved.

The library is built using fluent syntax as that allows the developer a lot of flexibility with how they want to combine different argument validation. It is also built to only show the available validation methods for the specific argument type.

# Documentation

All documentation can be found at [here](https://github.com/john-t-white/StaticDotNet.ArgumentValidation/blob/main/docs/README.md).

# Release Notes

**0.5.1**

- Performance improvements for Array and String validation checks.

**0.5.2**

- Moved exception messages to resource file.
- Replaced Writable/Readable with CanWrite/CanRead and marked existing obsolete.
- Added CanSeek.

**0.5.3**

- Updated exception messages to include more information.

**0.6.0**

- Added ASCII digit and letter checks for char and string (.NET 7.0).

**0.6.1**

- Update Arg.Is to only accept structs since it is always best to still check for null with reference types.

**0.6.2**

- Added checks for validating the scale of decimal types (.NET 7.0).

**0.6.3**

- Added checks for upper case/lower case strings.

**0.6.4**

- Added checks for upper case/lower case ASCII strings (.NET 7.0).

**0.6.5**

- Added check for not same.

**1.0.0**

- Added support for .NET 8.0
    - Used CompositeFormat to increase performance for formatting exception messages
- Removed support for .NET 5.0 since it is no longer supported.
