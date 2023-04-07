﻿using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringParsingExtensionsTests;

public sealed class ParseDateTimeOffsetExact {

	[Fact]
	public void ReturnsCorrectly() {

		DateTimeOffset expectedResult = new( 2000, 1, 2, 3, 4, 5, TimeSpan.Zero );
		string format = "yyyy-MM-dd (hh:mm:ss) K";
		ArgInfo<string> argInfo = new( expectedResult.ToString( format ), null, null );

		ArgInfo<DateTimeOffset> result = StringParsingExtensions.ParseDateTimeOffsetExact( argInfo, format );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		DateTimeOffset expectedResult = new( 2000, 1, 2, 3, 4, 5, TimeSpan.Zero );
		string format = "yyyy-MM-dd (hh:mm:ss) K";
		ArgInfo<string> argInfo = new( expectedResult.ToString( format ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<DateTimeOffset> result = StringParsingExtensions.ParseDateTimeOffsetExact( argInfo, format, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		DateTimeOffset expectedResult = new( 2000, 1, 2, 3, 4, 5, TimeSpan.Zero );
		string format = "yyyy-MM-dd (hh:mm:ss) K";
		ArgInfo<string> argInfo = new( expectedResult.ToString( format ), null, null );
		DateTimeStyles styles = DateTimeStyles.AdjustToUniversal;

		ArgInfo<DateTimeOffset> result = StringParsingExtensions.ParseDateTimeOffsetExact( argInfo, format, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string format = "yyyy-MM-dd (hh:mm:ss) K";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringParsingExtensions.ParseDateTimeOffsetExact( argInfo, format );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be parsable to System.DateTimeOffset.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string format = "yyyy-MM-dd (hh:mm:ss) K";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringParsingExtensions.ParseDateTimeOffsetExact( argInfo, format );
		} );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithMultipleFormatsReturnsCorrectly() {

		DateTimeOffset expectedResult = new( 2000, 1, 2, 3, 4, 5, TimeSpan.Zero );
		string[] formats = new[] {
			"yyyy-MM-dd (hh:mm:ss) K",
			"MM/dd/yyyy hh:mm:ss K"
		};
		ArgInfo<string> argInfo = new( expectedResult.ToString( formats[ 0 ] ), null, null );

		ArgInfo<DateTimeOffset> result = StringParsingExtensions.ParseDateTimeOffsetExact( argInfo, formats );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndProviderReturnsCorrectly() {

		DateTimeOffset expectedResult = new( 2000, 1, 2, 3, 4, 5, TimeSpan.Zero );
		string[] formats = new[] {
			"yyyy-MM-dd (hh:mm:ss) K",
			"MM/dd/yyyy hh:mm:ss K"
		};
		ArgInfo<string> argInfo = new( expectedResult.ToString( formats[ 0 ] ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<DateTimeOffset> result = StringParsingExtensions.ParseDateTimeOffsetExact( argInfo, formats, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndStylesReturnsCorrectly() {

		DateTimeOffset expectedResult = new( 2000, 1, 2, 3, 4, 5, TimeSpan.Zero );
		string[] formats = new[] {
			"yyyy-MM-dd (hh:mm:ss) K",
			"MM/dd/yyyy hh:mm:ss K"
		};
		ArgInfo<string> argInfo = new( expectedResult.ToString( formats[ 0 ] ), null, null );
		DateTimeStyles styles = DateTimeStyles.AdjustToUniversal;

		ArgInfo<DateTimeOffset> result = StringParsingExtensions.ParseDateTimeOffsetExact( argInfo, formats, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string[] formats = new[] {
			"yyyy-MM-dd (hh:mm:ss) K",
			"MM/dd/yyyy hh:mm:ss K"
		};

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringParsingExtensions.ParseDateTimeOffsetExact( argInfo, formats );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be parsable to System.DateTimeOffset.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithMultipleFormatsAndInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string[] formats = new[] {
			"yyyy-MM-dd (hh:mm:ss) K",
			"MM/dd/yyyy hh:mm:ss K"
		};

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringParsingExtensions.ParseDateTimeOffsetExact( argInfo, formats );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
