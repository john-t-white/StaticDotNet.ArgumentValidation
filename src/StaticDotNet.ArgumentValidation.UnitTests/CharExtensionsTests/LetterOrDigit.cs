namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class LetterOrDigit {

	[Fact]
	public void WithLetterReturnsCorrectly() {

		ArgInfo<char> argInfo = new( 'a', null, null );

		ArgInfo<char> result = argInfo.LetterOrDigit();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithDigitReturnsCorrectly() {

		ArgInfo<char> argInfo = new( '1', null, null );

		ArgInfo<char> result = argInfo.LetterOrDigit();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterOrDigitValueThrowsArgumentException() {

		char argumentValue = ' ';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.LetterOrDigit();
		} );

		string expectedMessage = "Value must be a letter or digit.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = ' ';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.LetterOrDigit();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
