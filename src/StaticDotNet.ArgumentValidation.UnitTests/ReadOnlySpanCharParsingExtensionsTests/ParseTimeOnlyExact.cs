#if NET6_0_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanCharParsingExtensionsTests;

public sealed class ParseTimeOnlyExact {

	[Fact]
	public void ReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2, 3, 4 );
		string format = "hh:mm:ss.ffffff";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );

		ArgInfo<TimeOnly> result = ReadOnlySpanCharParsingExtensions.ParseTimeOnlyExact( argInfo, format );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2, 3, 4 );
		string format = "hh:mm:ss.ffffff";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<TimeOnly> result = ReadOnlySpanCharParsingExtensions.ParseTimeOnlyExact( argInfo, format, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2, 3, 4 );
		string format = "hh:mm:ss.ffffff";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );
		DateTimeStyles styles = DateTimeStyles.None;

		ArgInfo<TimeOnly> result = ReadOnlySpanCharParsingExtensions.ParseTimeOnlyExact( argInfo, format, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string format = "hh:mm:ss.ffffff";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanCharParsingExtensions.ParseTimeOnlyExact( argInfo, format );
		} );

		string expectedMessage = "Value must be parsable to System.TimeOnly.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string format = "hh:mm:ss.ffffff";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanCharParsingExtensions.ParseTimeOnlyExact( argInfo, format );
		} );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithMultipleFormatsReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2, 3, 4 );
		string[] formats = new[] {
			"hh:mm:ss.ffffff",
			"hh:mm:ss"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[0] ), null, null );

		ArgInfo<TimeOnly> result = ReadOnlySpanCharParsingExtensions.ParseTimeOnlyExact( argInfo, formats );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndProviderReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2, 3, 4 );
		string[] formats = new[] {
			"hh:mm:ss.ffffff",
			"hh:mm:ss"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[0] ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<TimeOnly> result = ReadOnlySpanCharParsingExtensions.ParseTimeOnlyExact( argInfo, formats, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndStylesReturnsCorrectly() {

		TimeOnly expectedResult = new( 1, 2, 3, 4 );
		string[] formats = new[] {
			"hh:mm:ss.ffffff",
			"hh:mm:ss"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[0] ), null, null );
		DateTimeStyles styles = DateTimeStyles.None;

		ArgInfo<TimeOnly> result = ReadOnlySpanCharParsingExtensions.ParseTimeOnlyExact( argInfo, formats, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string[] formats = new[] {
			"hh:mm:ss.ffffff",
			"hh:mm:ss"
		};

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanCharParsingExtensions.ParseTimeOnlyExact( argInfo, formats );
		} );

		string expectedMessage = "Value must be parsable to System.TimeOnly.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithMultipleFormatsAndInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string[] formats = new[] {
			"hh:mm:ss.ffffff",
			"hh:mm:ss"
		};

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanCharParsingExtensions.ParseTimeOnlyExact( argInfo, formats );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
