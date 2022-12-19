using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringParsingExtensionsTests;

public sealed class ParseByte {

	[Fact]
	public void ReturnsCorrectly() {

		byte expectedResult = 1;
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<byte> result = StringParsingExtensions.ParseByte( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		byte expectedResult = 1;
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		NumberStyles styles = NumberStyles.None;

		ArgInfo<byte> result = StringParsingExtensions.ParseByte( argInfo, styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		byte expectedResult = 1;
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = NumberFormatInfo.InvariantInfo;

		ArgInfo<byte> result = StringParsingExtensions.ParseByte( argInfo, provider: provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringParsingExtensions.ParseByte( argInfo );
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

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringParsingExtensions.ParseByte( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
