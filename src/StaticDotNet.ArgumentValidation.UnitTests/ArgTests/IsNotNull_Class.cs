namespace StaticDotNet.ArgumentValidation.UnitTests.ArgTests;

public sealed class IsNotNull_Class {

	[Fact]
	public void ReturnsCorrectly() {

		object value = new();

		ArgInfo<object> result = Arg.IsNotNull( value );

		Assert.Same( value, result.Value );
		Assert.Equal( nameof( value ), result.Name );
		Assert.Null( result.Message );
	}

	[Fact]
	public void WithNameAndMessageReturnsCorrectly() {

		object value = new();
		string name = "Name";
		string message = "Message";

		ArgInfo<object> result = Arg.IsNotNull( value, name, message );

		Assert.Same( value, result.Value );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}

	[Fact]
	public void WithNullableValueNotNullReturnsCorrectly() {

		object? value = new();

		ArgInfo<object> result = Arg.IsNotNull( value );

		Assert.Same( value, result.Value );
	}

	[Fact]
	public void WithNullableValueIsNullThrowsArgumentNullException() {

		object? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.IsNotNull( value ) );
	}

	[Fact]
	public void WithNullableValueIsNullAndNameThrowsArgumentNullException() {

		object? value = null;
		string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Arg.IsNotNull( value, name ) );
	}

	[Fact]
	public void WithNullableValueIsNullAndMessageThrowsArgumentNullException() {

		object? value = null;
		string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.IsNotNull( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
