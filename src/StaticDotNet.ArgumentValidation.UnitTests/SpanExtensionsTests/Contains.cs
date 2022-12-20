#if NET6_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.SpanExtensionsTests;

public sealed class Contains {

	[Fact]
	public void ReturnsCorrectly() {

		SpanArgInfo<byte> argInfo = new( new byte[] { 1, 2, 3 }, null, null );
		byte value = 2;

		SpanArgInfo<byte> result = SpanExtensions.Contains( argInfo, value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotContainToValueThrowsArgumentException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		byte value = 0;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			SpanArgInfo<byte> argInfo = new( argumentValue, name, null );
			_ = SpanExtensions.Contains( argInfo, value );
		} );

		string expectedMessage = $"Value must contain {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		string message = "Message";
		byte value = 0;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			SpanArgInfo<byte> argInfo = new( argumentValue, name, message );
			_ = SpanExtensions.Contains( argInfo, value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
