#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.SpanExtensionsTests;

public sealed class NotEmpty {

	[Fact]
	public void ReturnsCorrectly() {

		SpanArgInfo<byte> argInfo = new( new byte[] { 1 }, null, null );

		SpanArgInfo<byte> result = argInfo.NotEmpty();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		byte[] argumentValue = Array.Empty<byte>();
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			SpanArgInfo<byte> argInfo = new( argumentValue, name, null );
			_ = argInfo.NotEmpty();
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		byte[] argumentValue = Array.Empty<byte>();
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			SpanArgInfo<byte> argInfo = new( argumentValue, name, message );
			_ = argInfo.NotEmpty();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
