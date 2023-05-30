#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class LowerAsciiLettersOrDigits {

	[Fact]
	public void WithLetterReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "abc123", null, null );

		ArgInfo<string> result = argInfo.LowerAsciiLettersOrDigits();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterOrDigitValueThrowsArgumentException() {

		string argumentValue = "ABC123";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.LowerAsciiLettersOrDigits();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be lower case ASCII letters or digits.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "ABC123";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.LowerAsciiLettersOrDigits();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif