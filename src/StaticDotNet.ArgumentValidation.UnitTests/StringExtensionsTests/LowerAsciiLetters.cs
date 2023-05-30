#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class LowerAsciiLetters {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "abc", null, null );

		ArgInfo<string> result = argInfo.LowerAsciiLetters();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLetterValueThrowsArgumentException() {

		string argumentValue = "Abc";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.LowerAsciiLetters();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be lower case ASCII letters.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Abc";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.LowerAsciiLetters();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
