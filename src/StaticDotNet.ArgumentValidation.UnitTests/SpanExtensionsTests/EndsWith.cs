#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.SpanExtensionsTests;

public sealed class EndsWith {

	[Fact]
	public void ReturnsCorrectly() {

		SpanArgInfo<byte> argInfo = new( new byte[] { 1, 2, 3 }, null, null );
		ReadOnlySpan<byte> value = new( new byte[] { 3 } );

		SpanArgInfo<byte> result = argInfo.EndsWith( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotEndsWithValueThrowsArgumentException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		byte[] value = new byte[] { 2 };

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpan<byte> spanValue = new( value );
			SpanArgInfo<byte> argInfo = new( argumentValue, name, null );
			_ = argInfo.EndsWith( spanValue );
		} );

		string expectedMessage = $"Value must end with {string.Join( ", ", value )}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		string message = "Message";
		byte[] value = new byte[] { 2 };

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpan<byte> spanValue = new( value );
			SpanArgInfo<byte> argInfo = new( argumentValue, name, message );
			_ = argInfo.EndsWith( spanValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
