#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.SpanExtensionsTests;

public sealed class NotWhiteSpace {

	[Fact]
	public void ReturnsCorrectly() {

		SpanArgInfo<char> argInfo = new( "Value".ToCharArray(), null, null );

		SpanArgInfo<char> result = argInfo.NotWhiteSpace();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string argumentValue = string.Empty;
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			SpanArgInfo<char> argInfo = new( argumentValue.ToCharArray(), name, null );
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
			SpanArgInfo<char> argInfo = new( argumentValue.ToCharArray(), name, null );
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
			SpanArgInfo<char> argInfo = new( argumentValue.ToCharArray(), name, message );
			_ = argInfo.NotWhiteSpace();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
