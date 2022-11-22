namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class Argument_String_NotNullOrWhiteSpace {

	[Fact]
	public void WithValueReturnsCorrectly() {
		string value = "Value";

		string result = Argument.Is.NotNullOrWhiteSpace( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		string? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpace( value ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		string value = string.Empty;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpace( value ) );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithWhiteSpaceValueThrowsArgumentException() {
		string value = " ";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpace( value ) );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentNullException() {
		string? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Argument.Is.NotNullOrWhiteSpace( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException() {
		string? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpace( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}