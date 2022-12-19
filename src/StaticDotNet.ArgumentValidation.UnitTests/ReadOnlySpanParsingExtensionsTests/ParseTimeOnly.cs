#if NET6_0_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanParsingExtensionsTests;

public sealed class ParseTimeOnly {

	[Fact]
	public void ReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2 );
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<TimeOnly> result = ReadOnlySpanParsingExtensions.ParseTimeOnly( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2 );
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<TimeOnly> result = ReadOnlySpanParsingExtensions.ParseTimeOnly( argInfo, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2 );
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		DateTimeStyles styles = DateTimeStyles.None;

		ArgInfo<TimeOnly> result = ReadOnlySpanParsingExtensions.ParseTimeOnly( argInfo, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanParsingExtensions.ParseTimeOnly( argInfo );
		} );

		string expectedMessage = "Value must be parsable to System.TimeOnly.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanParsingExtensions.ParseTimeOnly( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
