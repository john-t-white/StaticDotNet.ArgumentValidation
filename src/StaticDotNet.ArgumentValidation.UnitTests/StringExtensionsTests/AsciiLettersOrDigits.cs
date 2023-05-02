#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class AsciiLettersOrDigits {

	[Fact]
	public void WithLetterReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "abc", null, null );

		ArgInfo<string> result = argInfo.AsciiLettersOrDigits();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithDigitReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "123", null, null );

		ArgInfo<string> result = argInfo.AsciiLettersOrDigits();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterOrDigitValueThrowsArgumentException() {

		string argumentValue = " ";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.AsciiLettersOrDigits();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be ASCII letters or digits.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = " ";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.AsciiLettersOrDigits();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif