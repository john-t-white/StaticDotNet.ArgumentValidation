#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanExtensionsTests;

public sealed class MaxLength {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<byte> argInfo = new( new byte[] { 1, 2, 3 }, null, null );
		int length = 3;

		ReadOnlySpanArgInfo<byte> result = ReadOnlySpanExtensions.MaxLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithLengthNotEqualToValueThrowsArgumentOutOfRangeException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ReadOnlySpanArgInfo<byte> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanExtensions.MaxLength( argInfo, length );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Length} exceeds the maximum length of {length}.";

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
			_ = ReadOnlySpanExtensions.MaxLength( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithInvalidStringLengthThrowsArgumentOutOfRangeException() {

		string argumentValue = "12345";
		string name = "Name";
		int length = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanExtensions.MaxLength( argInfo, length );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" with a length of {argumentValue.Length} exceeds the maximum length of {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}
}

#endif
