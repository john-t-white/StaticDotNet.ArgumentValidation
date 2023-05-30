#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class LowerAsciiLetter {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<char> argInfo = new( 'a', null, null );

		ArgInfo<char> result = argInfo.LowerAsciiLetter();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterValueThrowsArgumentException() {

		char argumentValue = 'A';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.LowerAsciiLetter();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be a lower case ASCII letter.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = 'A';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.LowerAsciiLetter();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
