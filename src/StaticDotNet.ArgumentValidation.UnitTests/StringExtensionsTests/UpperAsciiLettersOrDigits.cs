#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class UpperAsciiLettersOrDigits {

	[Fact]
	public void WithLetterReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "ABC123", null, null );

		ArgInfo<string> result = argInfo.UpperAsciiLettersOrDigits();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterOrDigitValueThrowsArgumentException() {

		string argumentValue = "abc123";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.UpperAsciiLettersOrDigits();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be upper case ASCII letters or digits.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "abc123";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.UpperAsciiLettersOrDigits();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif