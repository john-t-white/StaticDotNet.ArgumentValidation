namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class Letter {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<char> argInfo = new( 'a', null, null );

		ArgInfo<char> result = argInfo.Letter();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterValueThrowsArgumentException() {

		char argumentValue = '1';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.Letter();
		} );

		string expectedMessage = "Value must be a letter.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = '1';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.Letter();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
