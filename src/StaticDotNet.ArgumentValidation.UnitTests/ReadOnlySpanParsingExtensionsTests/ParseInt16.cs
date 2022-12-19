#if NETCOREAPP3_1_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanParsingExtensionsTests;

public sealed class ParseInt16 {

	[Fact]
	public void ReturnsCorrectly() {

		short expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<short> result = ReadOnlySpanParsingExtensions.ParseInt16( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		short expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		NumberStyles styles = NumberStyles.None;

		ArgInfo<short> result = ReadOnlySpanParsingExtensions.ParseInt16( argInfo, styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		short expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = NumberFormatInfo.InvariantInfo;

		ArgInfo<short> result = ReadOnlySpanParsingExtensions.ParseInt16( argInfo, provider: provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanParsingExtensions.ParseInt16( argInfo );
		} );

		string expectedMessage = "Value must be parsable to System.Int16.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanParsingExtensions.ParseInt16( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
