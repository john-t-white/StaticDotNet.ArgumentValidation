#if NETCOREAPP3_1_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanCharParsingExtensionsTests;

public sealed class ParseTimeSpanExact {

	[Fact]
	public void ReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string format = @"d\.hh\:mm\:ss\.ffffff";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );

		ArgInfo<TimeSpan> result = ReadOnlySpanCharParsingExtensions.ParseTimeSpanExact( argInfo, format );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string format = @"d\.hh\:mm\:ss\.ffffff";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<TimeSpan> result = ReadOnlySpanCharParsingExtensions.ParseTimeSpanExact( argInfo, format, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string format = @"d\.hh\:mm\:ss\.ffffff";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );
		TimeSpanStyles styles = TimeSpanStyles.None;

		ArgInfo<TimeSpan> result = ReadOnlySpanCharParsingExtensions.ParseTimeSpanExact( argInfo, format, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string format = @"d\.hh\:mm\:ss\.ffffff";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanCharParsingExtensions.ParseTimeSpanExact( argInfo, format );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be parsable to System.TimeSpan.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string format = @"d\.hh\:mm\:ss\.ffffff";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanCharParsingExtensions.ParseTimeSpanExact( argInfo, format );
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
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[0] ), null, null );

		ArgInfo<TimeSpan> result = ReadOnlySpanCharParsingExtensions.ParseTimeSpanExact( argInfo, formats );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndProviderReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string[] formats = new[] {
			@"d\.hh\:mm\:ss\.ffffff",
			@"hh\:mm\:ss"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[0] ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<TimeSpan> result = ReadOnlySpanCharParsingExtensions.ParseTimeSpanExact( argInfo, formats, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndStylesReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3, 4 );
		string[] formats = new[] {
			@"d\.hh\:mm\:ss\.ffffff",
			@"hh\:mm\:ss"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[0] ), null, null );
		TimeSpanStyles styles = TimeSpanStyles.None;

		ArgInfo<TimeSpan> result = ReadOnlySpanCharParsingExtensions.ParseTimeSpanExact( argInfo, formats, styles: styles );

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

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanCharParsingExtensions.ParseTimeSpanExact( argInfo, formats );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be parsable to System.TimeSpan.";

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

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanCharParsingExtensions.ParseTimeSpanExact( argInfo, formats );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
