using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringConversionExtensionsTests;

public sealed class ToDateTimeOffset {

	[Fact]
	public void ReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<DateTimeOffset> result = StringConversionExtensions.ToDateTimeOffset( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<DateTimeOffset> result = StringConversionExtensions.ToDateTimeOffset( argInfo, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5, DateTimeKind.Utc );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		DateTimeStyles styles = DateTimeStyles.AssumeUniversal;

		ArgInfo<DateTimeOffset> result = StringConversionExtensions.ToDateTimeOffset( argInfo, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToDateTimeOffset( argInfo );
		} );

		string expectedMessage = "Value must be a date/time with offset.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToDateTimeOffset( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
