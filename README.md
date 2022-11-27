# Overview

StaticDotNet.ArgumentValidation is a guard library focused on performance, extensibility, ease of use and nullability support.

[Documentation](docs/README.md)

## Performance

Every guard claus is benchmarked against the same code you would write without using this library, as well as other popular guard libraries to show the difference in performance.

The library also fully supports trimming so applications can choose to only include the parts of the library they use.

## Extensibility

You can easily add your own guard methods by adding an extension method off of the Argument class.

## Ease of Use

The point of using a library like this is to make it easier to use as well as removing boiler plate code that takes space away from your code.

## Nullability

All of the guard clauses support the nullability attributes introduced in .NET 6.0.
