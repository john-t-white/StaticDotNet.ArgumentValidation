#if NET6_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanExtensionsTests;

public sealed class NotEmpty {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<char> argInfo = new( "Value", null, null );

		ReadOnlySpanArgInfo<char> result = argInfo.NotEmpty();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string argumentValue = string.Empty;
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.NotEmpty();
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = string.Empty;
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.NotEmpty();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
