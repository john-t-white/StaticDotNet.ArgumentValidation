namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StringExtensions_Contains {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string value = "alu";

		ArgInfo<string> result = StringExtensions.Contains( argInfo, value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithStringComparisonReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string value = "alu";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string> result = StringExtensions.Contains( argInfo, value, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string value = "Does Not Contain";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringExtensions.Contains( argInfo, value );
		} );

		string expectedMessage = $"Value must contain {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string message = "Message";
		string value = "Does Not Contain";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringExtensions.Contains( argInfo, value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
