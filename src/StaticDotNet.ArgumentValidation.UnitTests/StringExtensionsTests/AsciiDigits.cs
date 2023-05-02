#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class AsciiDigits {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "123", null, null );

		ArgInfo<string> result = argInfo.AsciiDigits();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotDigitValueThrowsArgumentException() {

		string argumentValue = "abc";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.AsciiDigits();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be ASCII digits.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "abc";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.AsciiDigits();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif