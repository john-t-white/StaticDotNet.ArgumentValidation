#if NETCOREAPP3_1_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanParsingExtensionsTests;

public sealed class ParseInt32 {

	[Fact]
	public void ReturnsCorrectly() {

		int expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<int> result = ReadOnlySpanParsingExtensions.ParseInt32( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		int expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		NumberStyles styles = NumberStyles.None;

		ArgInfo<int> result = ReadOnlySpanParsingExtensions.ParseInt32( argInfo, styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		int expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = NumberFormatInfo.InvariantInfo;

		ArgInfo<int> result = ReadOnlySpanParsingExtensions.ParseInt32( argInfo, provider: provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanParsingExtensions.ParseInt32( argInfo );
		} );

		string expectedMessage = "Value must be parsable to System.Int32.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanParsingExtensions.ParseInt32( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
