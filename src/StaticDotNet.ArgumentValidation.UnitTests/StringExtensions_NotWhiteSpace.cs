namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StringExtensions_NotWhiteSpace {

	[Fact]
	public void WithValueReturnsCorrectly() {
		string value = "Value";

		string result = Argument.Is.NotWhiteSpace( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		string? value = null;

		string? result = Argument.Is.NotWhiteSpace( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		string value = string.Empty;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotWhiteSpace( value ) );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithWhiteSpaceValueThrowsArgumentException() {
		string value = " ";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotWhiteSpace( value ) );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithEmptyValueAndNameThrowsArgumentException() {
		string? value = string.Empty;
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotWhiteSpace( value, name ) );
	}

	[Fact]
	public void WithEmptyValueAndMessageThrowsArgumentException() {
		string? value = string.Empty;
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotWhiteSpace( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}