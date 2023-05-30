#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class UpperAsciiLetterOrDigit {

	[Fact]
	public void WithLetterReturnsCorrectly() {

		ArgInfo<char> argInfo = new( 'A', null, null );

		ArgInfo<char> result = argInfo.UpperAsciiLetterOrDigit();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithDigitReturnsCorrectly() {

		ArgInfo<char> argInfo = new( '1', null, null );

		ArgInfo<char> result = argInfo.UpperAsciiLetterOrDigit();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterOrDigitValueThrowsArgumentException() {

		char argumentValue = 'a';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.UpperAsciiLetterOrDigit();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be an upper case ASCII letter or digit.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = 'a';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.UpperAsciiLetterOrDigit();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif