#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class AsciiLetter {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<char> argInfo = new( 'a', null, null );

		ArgInfo<char> result = argInfo.AsciiLetter();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterValueThrowsArgumentException() {

		char argumentValue = '1';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.AsciiLetter();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be an ASCII letter.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = '1';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.AsciiLetter();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
