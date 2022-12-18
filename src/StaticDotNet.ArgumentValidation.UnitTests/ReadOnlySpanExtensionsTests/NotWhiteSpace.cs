#if NET6_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanExtensionsTests;

public sealed class NotWhiteSpace {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<char> argInfo = new( "Value", null, null );

		ReadOnlySpanArgInfo<char> result = argInfo.NotWhiteSpace();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string argumentValue = string.Empty;
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.NotWhiteSpace();
		} );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithWhiteSpaceValueThrowsArgumentException() {

		string argumentValue = " ";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.NotWhiteSpace();
		} );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = string.Empty;
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.NotWhiteSpace();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
