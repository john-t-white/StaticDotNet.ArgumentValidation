namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class NotWhiteSpace {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );

		ArgInfo<string> result = argInfo.NotWhiteSpace();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = argInfo.NotWhiteSpace();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		string value = string.Empty;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.NotWhiteSpace();
		} );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithWhiteSpaceValueThrowsArgumentException() {

		string name = "Name";
		string value = " ";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.NotWhiteSpace();
		} );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string value = string.Empty;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.NotWhiteSpace();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
