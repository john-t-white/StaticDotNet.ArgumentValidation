#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanExtensionsTests;

public sealed class StartsWith {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<byte> argInfo = new( new byte[] { 1, 2, 3 }, null, null );
		ReadOnlySpan<byte> value = new( new byte[] { 1 } );

		ReadOnlySpanArgInfo<byte> result = argInfo.StartsWith( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotStartsWithValueThrowsArgumentException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		byte[] value = new byte[] { 2 };

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpan<byte> spanValue = new( value );
			ReadOnlySpanArgInfo<byte> argInfo = new( argumentValue, name, null );
			_ = argInfo.StartsWith( value );
		} );

		string expectedMessage = $"Value must start with {string.Join( ", ", value )}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		string message = "Message";
		byte[] value = new byte[] { 2 };

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<byte> argInfo = new( argumentValue, name, message );
			_ = argInfo.StartsWith( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
