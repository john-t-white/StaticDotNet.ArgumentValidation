#if NET6_0_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class ToTimeSpan {

	[Fact]
	public void ReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<TimeSpan> result = StringConversionExtensions.ToTimeSpan( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3 );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<TimeSpan> result = StringConversionExtensions.ToTimeSpan( argInfo, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToTimeSpan( argInfo );
		} );

		string expectedMessage = "Value must be a time span.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToTimeSpan( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
