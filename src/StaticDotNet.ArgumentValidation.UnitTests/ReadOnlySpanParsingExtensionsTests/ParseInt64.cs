#if NETCOREAPP3_1_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanParsingExtensionsTests;

public sealed class ParseInt64 {

	[Fact]
	public void ReturnsCorrectly() {

		long expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<long> result = ReadOnlySpanParsingExtensions.ParseInt64( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		long expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		NumberStyles styles = NumberStyles.None;

		ArgInfo<long> result = ReadOnlySpanParsingExtensions.ParseInt64( argInfo, styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		long expectedResult = 1;
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = NumberFormatInfo.InvariantInfo;

		ArgInfo<long> result = ReadOnlySpanParsingExtensions.ParseInt64( argInfo, provider: provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanParsingExtensions.ParseInt64( argInfo );
		} );

		string expectedMessage = "Value must be parsable to System.Int64.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanParsingExtensions.ParseInt64( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
