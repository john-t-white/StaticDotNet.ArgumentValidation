using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class EndsWith_String_IgnoreCase {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string value = "UE";
		bool ignoreCase = true;

		ArgInfo<string> result = argInfo.EndsWith( value, ignoreCase );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithCultureReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string value = "UE";
		bool ignoreCase = true;
		CultureInfo culture = CultureInfo.InvariantCulture;

		ArgInfo<string> result = argInfo.EndsWith( value, ignoreCase, culture );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		string value = "ue";
		bool ignoreCase = true;

		ArgInfo<string?> result = argInfo.EndsWith( value, ignoreCase );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueThrowsArgumentException() {

		string name = "Name";
		string argumentValue = "Value";
		string value = "UE";
		bool ignoreCase = false;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.EndsWith( value, ignoreCase );
		} );

		string expectedMessage = $"Value must end with {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string argumentValue = "Value";
		string message = "Message";
		string value = "Does Not End With";
		bool ignoreCase = true;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.EndsWith( value, ignoreCase );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
