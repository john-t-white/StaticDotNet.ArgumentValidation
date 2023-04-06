#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanExtensionsTests;

public sealed class LengthBetween {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<byte> argInfo = new( new byte[] { 1, 2, 3 }, null, null );
		int minLength = 1;
		int maxLength = 3;

		ReadOnlySpanArgInfo<byte> result = ReadOnlySpanExtensions.LengthBetween( argInfo, minLength, maxLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithLengthNotEqualToValueThrowsArgumentOutOfRangeException() {

		byte[] argumentValue = new byte[] { 1, 2, 3, 4 };
		string name = "Name";
		int minLength = 1;
		int maxLength = 3;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ReadOnlySpanArgInfo<byte> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Length} must have a length between {minLength} and {maxLength}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithLengthNotEqualToValueAndMessageThrowsArgumentOutOfRangeException() {

		byte[] argumentValue = new byte[] { 1, 2, 3, 4 };
		string name = "Name";
		string message = "Message";
		int minLength = 1;
		int maxLength = 3;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ReadOnlySpanArgInfo<byte> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithInvalidStringThrowsArgumentOutOfRangeException() {

		string argumentValue = "1234";
		string name = "Name";
		int minLength = 1;
		int maxLength = 3;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" with a length of {argumentValue.Length} must have a length between {minLength} and {maxLength}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}
}

#endif
