#if NETCOREAPP3_1_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanParsingExtensionsTests;

public sealed class ParseByte {

	[Fact]
	public void ReturnsCorrectly() {

		byte expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<byte> result = ReadOnlySpanParsingExtensions.ParseByte( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		byte expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		NumberStyles styles = NumberStyles.None;

		ArgInfo<byte> result = ReadOnlySpanParsingExtensions.ParseByte( argInfo, styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		byte expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = NumberFormatInfo.InvariantInfo;

		ArgInfo<byte> result = ReadOnlySpanParsingExtensions.ParseByte( argInfo, provider: provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanParsingExtensions.ParseByte( argInfo );
		} );

		string expectedMessage = "Value must be parsable to System.Byte.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanParsingExtensions.ParseByte( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
