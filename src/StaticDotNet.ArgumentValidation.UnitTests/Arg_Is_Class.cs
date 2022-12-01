namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class Arg_Is_Class {

	[Fact]
	public void ReturnsCorrectly() {

		object value = new();

		ArgInfo<object> result = Arg.Is( value );

		Assert.Same( value, result.Value );
		Assert.Equal( nameof( value ), result.Name );
		Assert.Null( result.Message );
	}

	[Fact]
	public void WithNameAndMessageReturnsCorrectly() {

		object value = new();
		string name = "Name";
		string message = "Message";

		ArgInfo<object> result = Arg.Is( value, name, message );

		Assert.Same( value, result.Value );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}

	[Fact]
	public void WithNullableValueNotNullReturnsCorrectly() {

		object? value = new();

		ArgInfo<object> result = Arg.Is( value );

		Assert.Same( value, result.Value );
	}

	[Fact]
	public void WithNullableValueIsNullReturnsCorrectly() {

		object? value = null;

		ArgInfo<object?> result = Arg.Is( value );

		Assert.Null( result.Value );
	}
}
