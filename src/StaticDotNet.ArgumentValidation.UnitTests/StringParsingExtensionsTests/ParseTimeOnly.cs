#if NET6_0_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringParsingExtensionsTests;

public sealed class ParseTimeOnly {

	[Fact]
	public void ReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<TimeOnly> result = StringParsingExtensions.ParseTimeOnly( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<TimeOnly> result = StringParsingExtensions.ParseTimeOnly( argInfo, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		DateTimeStyles styles = DateTimeStyles.None;

		ArgInfo<TimeOnly> result = StringParsingExtensions.ParseTimeOnly( argInfo, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringParsingExtensions.ParseTimeOnly( argInfo );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be parsable to System.TimeOnly.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringParsingExtensions.ParseTimeOnly( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
