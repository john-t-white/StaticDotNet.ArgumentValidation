using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class StartsWith_String_IgnoreCase {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string value = "Va";
		bool ignoreCase = false;

		ArgInfo<string> result = argInfo.StartsWith( value, ignoreCase );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithIgnoreCaseTrueReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string value = "VA";
		bool ignoreCase = true;

		ArgInfo<string> result = argInfo.StartsWith( value, ignoreCase );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithCultureTrueReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string value = "VA";
		bool ignoreCase = true;
		CultureInfo culture = CultureInfo.InvariantCulture;

		ArgInfo<string> result = argInfo.StartsWith( value, ignoreCase, culture );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string value = "Does Not Start With";
		bool ignoreCase = false;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.StartsWith( value, ignoreCase );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must start with \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string value = null!;
		bool ignoreCase = false;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.StartsWith( value, ignoreCase );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must start with <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string message = "Message";
		string value = "Does Not Start With";
		bool ignoreCase = false;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.StartsWith( value, ignoreCase );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
