namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StringExtensions_NotEmpty {

	[Fact]
	public void WithValueReturnsCorrectly() {
		string value = "Value";

		string result = Argument.Is.NotEmpty( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		string? value = null;

		string? result = Argument.Is.NotEmpty( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		string value = string.Empty;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithWhiteSpaceValueReturnsCorrectly() {
		string value = " ";

		string result = Argument.Is.NotEmpty( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithEmptyValueAndNameThrowsArgumentException() {
		string value = string.Empty;
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotEmpty( value, name ) );
	}

	[Fact]
	public void WithEmptyValueAndMessageThrowsArgumentException() {
		string value = string.Empty;
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}