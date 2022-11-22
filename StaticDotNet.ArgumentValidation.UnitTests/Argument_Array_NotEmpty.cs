namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class Argument_Array_NotEmpty {

	[Fact]
	public void WithValueReturnsCorrectly() {
		string[] value = { "Value" };

		string[] result = Argument.Is.NotEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {
		string[]? value = null;

		string[]? result = Argument.Is.NotEmpty( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		string[] value = Array.Empty<string>();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithEmptyValueAndNameThrowsArgumentException() {
		string[] value = { };
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentException() {
		string[] value = { };
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}