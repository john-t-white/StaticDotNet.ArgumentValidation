using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringConversionExtensionsTests;

public sealed class ToDateTime {

	[Fact]
	public void ReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<DateTime> result = StringConversionExtensions.ToDateTime( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<DateTime> result = StringConversionExtensions.ToDateTime( argInfo, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithStylesReturnsCorrectly() {

		DateTime expectedResult = new( 2000, 1, 2, 3, 4, 5, DateTimeKind.Utc );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		DateTimeStyles styles = DateTimeStyles.AdjustToUniversal;

		ArgInfo<DateTime> result = StringConversionExtensions.ToDateTime( argInfo, styles: styles );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToDateTime( argInfo );
		} );

		string expectedMessage = "Value must be a date/time.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToDateTime( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
