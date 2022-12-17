namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class NotWhiteSpace {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<char> argInfo = new( 'a', null, null );

		ArgInfo<char> result = argInfo.NotWhiteSpace();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithWhiteSpaceValueThrowsArgumentException() {

		char argumentValue = ' ';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.NotWhiteSpace();
		} );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = ' ';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.NotWhiteSpace();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
