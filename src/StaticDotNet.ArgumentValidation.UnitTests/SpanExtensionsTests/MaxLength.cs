#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.SpanExtensionsTests;

public sealed class MaxLength {

	[Fact]
	public void ReturnsCorrectly() {

		SpanArgInfo<byte> argInfo = new( new byte[] { 1, 2, 3 }, null, null );
		int length = 3;

		SpanArgInfo<byte> result = SpanExtensions.MaxLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithLengthNotEqualToValueThrowsArgumentOutOfRangeException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			SpanArgInfo<byte> argInfo = new( argumentValue, name, null );
			_ = SpanExtensions.MaxLength( argInfo, length );
		} );

		string expectedMessage = $"Value cannot have a length greater than {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithLengthNotEqualToValueAndMessageThrowsArgumentOutOfRangeException() {

		byte[] argumentValue = new byte[] { 1, 2, 3 };
		string name = "Name";
		string message = "Message";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			SpanArgInfo<byte> argInfo = new( argumentValue, name, message );
			_ = SpanExtensions.MaxLength( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
