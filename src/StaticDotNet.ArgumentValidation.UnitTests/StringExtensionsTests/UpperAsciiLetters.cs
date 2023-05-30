#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class UpperAsciiLetters {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "ABC", null, null );

		ArgInfo<string> result = argInfo.UpperAsciiLetters();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterValueThrowsArgumentException() {

		string argumentValue = "aBC";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.UpperAsciiLetters();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be upper case ASCII letters.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Abc";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.UpperAsciiLetters();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
