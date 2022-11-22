namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class Argument_Object_Null {

	[Fact]
	public void WithNullValueReturnsCorrectly() {
		object? value = null;

		object? result = Argument.Is.Null( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithNotNullValueThrowsArgumentException() {
		object value = new();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.Null( value ) );

		const string expectedMessage = "Value must be null.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNotNullValueAndNameThrowsArgumentException() {
		object value = new();
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.Null( value, name ) );
	}

	[Fact]
	public void WithNotNullValueAndMessageThrowsArgumentException() {
		object value = new();
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.Null( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}