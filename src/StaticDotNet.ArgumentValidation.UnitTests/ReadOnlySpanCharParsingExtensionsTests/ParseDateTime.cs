#if NETCOREAPP3_1_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanCharParsingExtensionsTests;

public sealed class ParseDateTime {

	[Fact]
	public void ReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5 );
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<DateTime> result = ReadOnlySpanCharParsingExtensions.ParseDateTime( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5 );
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<DateTime> result = ReadOnlySpanCharParsingExtensions.ParseDateTime( argInfo, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5, DateTimeKind.Utc );
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		DateTimeStyles styles = DateTimeStyles.AdjustToUniversal;

		ArgInfo<DateTime> result = ReadOnlySpanCharParsingExtensions.ParseDateTime( argInfo, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanCharParsingExtensions.ParseDateTime( argInfo );
		} );

		string expectedMessage = "Value must be parsable to System.DateTime.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanCharParsingExtensions.ParseDateTime( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
