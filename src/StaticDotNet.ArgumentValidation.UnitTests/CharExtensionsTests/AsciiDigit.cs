#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class AsciiDigit {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<char> argInfo = new( '1', null, null );

		ArgInfo<char> result = argInfo.AsciiDigit();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotDigitValueThrowsArgumentException() {

		char argumentValue = 'a';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.AsciiDigit();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be an ASCII digit.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = 'a';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.AsciiDigit();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif