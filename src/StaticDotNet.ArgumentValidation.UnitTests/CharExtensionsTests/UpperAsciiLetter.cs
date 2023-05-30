#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class UpperAsciiLetter {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<char> argInfo = new( 'A', null, null );

		ArgInfo<char> result = argInfo.UpperAsciiLetter();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterValueThrowsArgumentException() {

		char argumentValue = 'a';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.UpperAsciiLetter();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be an upper case ASCII letter.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = 'a';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.UpperAsciiLetter();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
