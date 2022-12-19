#if NETCOREAPP3_1_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanParsingExtensionsTests;

public sealed class ParseDateTimeExact {

	[Fact]
	public void ReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5 );
		string format = "yyyy-MM-dd (hh:mm:ss)";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );

		ArgInfo<DateTime> result = ReadOnlySpanParsingExtensions.ParseDateTimeExact( argInfo, format );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5 );
		string format = "yyyy-MM-dd (hh:mm:ss)";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<DateTime> result = ReadOnlySpanParsingExtensions.ParseDateTimeExact( argInfo, format, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5, DateTimeKind.Utc );
		string format = "yyyy-MM-dd (hh:mm:ss)";
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );
		DateTimeStyles styles = DateTimeStyles.AdjustToUniversal;

		ArgInfo<DateTime> result = ReadOnlySpanParsingExtensions.ParseDateTimeExact( argInfo, format, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string format = "yyyy-MM-dd (hh:mm:ss)";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanParsingExtensions.ParseDateTimeExact( argInfo, format );
		} );

		string expectedMessage = "Value must be parsable to System.DateTime.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string format = "yyyy-MM-dd (hh:mm:ss)";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanParsingExtensions.ParseDateTimeExact( argInfo, format );
		} );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithMultipleFormatsReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5 );
		string[] formats = new[] {
			"yyyy-MM-dd (hh:mm:ss)",
			"MM/dd/yyyy hh:mm:ss"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[ 0 ] ), null, null );

		ArgInfo<DateTime> result = ReadOnlySpanParsingExtensions.ParseDateTimeExact( argInfo, formats );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndProviderReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5 );
		string[] formats = new[] {
			"yyyy-MM-dd (hh:mm:ss)",
			"MM/dd/yyyy hh:mm:ss"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[ 0 ] ), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<DateTime> result = ReadOnlySpanParsingExtensions.ParseDateTimeExact( argInfo, formats, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndStylesReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5, DateTimeKind.Utc );
		string[] formats = new[] {
			"yyyy-MM-dd (hh:mm:ss)",
			"MM/dd/yyyy hh:mm:ss"
		};
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( formats[ 0 ] ), null, null );
		DateTimeStyles styles = DateTimeStyles.AdjustToUniversal;

		ArgInfo<DateTime> result = ReadOnlySpanParsingExtensions.ParseDateTimeExact( argInfo, formats, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithMultipleFormatsAndInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string[] formats = new[] {
			"yyyy-MM-dd (hh:mm:ss)",
			"MM/dd/yyyy hh:mm:ss"
		};

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanParsingExtensions.ParseDateTimeExact( argInfo, formats );
		} );

		string expectedMessage = "Value must be parsable to System.DateTime.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithMultipleFormatsAndInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		string[] formats = new[] {
			"yyyy-MM-dd (hh:mm:ss)",
			"MM/dd/yyyy hh:mm:ss"
		};

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanParsingExtensions.ParseDateTimeExact( argInfo, formats );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
