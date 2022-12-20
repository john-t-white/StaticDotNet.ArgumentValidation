#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanExtensionsTests;

public sealed class Length {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<byte> argInfo = new( new byte[] { 1, 2, 3 }, null, null );
		int length = 3;

		ReadOnlySpanArgInfo<byte> result = ReadOnlySpanExtensions.Length( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithLengthNotEqualToValueThrowsArgumentOutOfRangeException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ReadOnlySpanArgInfo<byte> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanExtensions.Length( argInfo, length );
		} );

		string expectedMessage = $"Value must have a length equal to {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithLengthNotEqualToValueAndMessageThrowsArgumentOutOfRangeException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		string message = "Message";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ReadOnlySpanArgInfo<byte> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanExtensions.Length( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
