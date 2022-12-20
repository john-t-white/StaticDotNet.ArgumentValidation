#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanExtensionsTests;

public sealed class MinLength {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<byte> argInfo = new( new byte[] { 1, 2, 3 }, null, null );
		int length = 3;

		ReadOnlySpanArgInfo<byte> result = ReadOnlySpanExtensions.MinLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithLengthNotEqualToValueThrowsArgumentOutOfRangeException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		int length = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ReadOnlySpanArgInfo<byte> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanExtensions.MinLength( argInfo, length );
		} );

		string expectedMessage = $"Value cannot have a length less than {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithLengthNotEqualToValueAndMessageThrowsArgumentOutOfRangeException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		string message = "Message";
		int length = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ReadOnlySpanArgInfo<byte> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanExtensions.MinLength( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
