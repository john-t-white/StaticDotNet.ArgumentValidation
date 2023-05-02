#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class AsciiLetters {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "abc", null, null );

		ArgInfo<string> result = argInfo.AsciiLetters();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterValueThrowsArgumentException() {

		string argumentValue = "123";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.AsciiLetters();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be ASCII letters.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "123";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.AsciiLetters();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
