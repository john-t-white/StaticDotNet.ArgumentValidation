﻿#if NET6_0_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringParsingExtensionsTests;

public sealed class ParseDateOnly {

	[Fact]
	public void ReturnsCorrectly() {

		DateOnly expectedResult = new( 2000, 1, 2 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<DateOnly> result = StringParsingExtensions.ParseDateOnly( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		DateOnly expectedResult = new( 2000, 1, 2 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<DateOnly> result = StringParsingExtensions.ParseDateOnly( argInfo, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		DateOnly expectedResult = new( 2000, 1, 2 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		DateTimeStyles styles = DateTimeStyles.None;

		ArgInfo<DateOnly> result = StringParsingExtensions.ParseDateOnly( argInfo, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringParsingExtensions.ParseDateOnly( argInfo );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be parsable to System.DateOnly.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringParsingExtensions.ParseDateOnly( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
