#if NET6_0_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class ToTimeSpanExact {

	[Fact]
	public void ReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string format = @"d\.hh\:mm\:ss\.ffffff";
		ArgInfo<string> argInfo = new( expectedResult.ToString( format ), null, null );

		ArgInfo<TimeSpan> result = StringConversionExtensions.ToTimeSpanExact( argInfo, format );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string format = @"d\.hh\:mm\:ss\.ffffff";
		ArgInfo<string> argInfo = new( expectedResult.ToString( format ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<TimeSpan> result = StringConversionExtensions.ToTimeSpanExact( argInfo, format, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string format = @"d\.hh\:mm\:ss\.ffffff";
		ArgInfo<string> argInfo = new( expectedResult.ToString( format ), null, null );
		TimeSpanStyles styles = TimeSpanStyles.None;

		ArgInfo<TimeSpan> result = StringConversionExtensions.ToTimeSpanExact( argInfo, format, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string format = @"d\.hh\:mm\:ss\.ffffff";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToTimeSpanExact( argInfo, format );
		} );

		string expectedMessage = "Value must be a time span.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string format = @"d\.hh\:mm\:ss\.ffffff";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToTimeSpanExact( argInfo, format );
		} );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithMultipleFormatsReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string[] formats = new[] {
			@"d\.hh\:mm\:ss\.ffffff",
			@"hh\:mm\:ss"
		};
		ArgInfo<string> argInfo = new( expectedResult.ToString( formats[0] ), null, null );

		ArgInfo<TimeSpan> result = StringConversionExtensions.ToTimeSpanExact( argInfo, formats );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndProviderReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string[] formats = new[] {
			@"d\.hh\:mm\:ss\.ffffff",
			@"hh\:mm\:ss"
		};
		ArgInfo<string> argInfo = new( expectedResult.ToString( formats[0] ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<TimeSpan> result = StringConversionExtensions.ToTimeSpanExact( argInfo, formats, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndStylesReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string[] formats = new[] {
			@"d\.hh\:mm\:ss\.ffffff",
			@"hh\:mm\:ss"
		};
		ArgInfo<string> argInfo = new( expectedResult.ToString( formats[0] ), null, null );
		TimeSpanStyles styles = TimeSpanStyles.None;

		ArgInfo<TimeSpan> result = StringConversionExtensions.ToTimeSpanExact( argInfo, formats, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string[] formats = new[] {
			@"d\.hh\:mm\:ss\.ffffff",
			@"hh\:mm\:ss"
		};

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToTimeSpanExact( argInfo, formats );
		} );

		string expectedMessage = "Value must be a time span.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithMultipleFormatsAndInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string[] formats = new[] {
			@"d\.hh\:mm\:ss\.ffffff",
			@"hh\:mm\:ss"
		};

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToTimeSpanExact( argInfo, formats );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
