namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class StartsWith_String {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string value = "Va";

		ArgInfo<string> result = argInfo.StartsWith( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithComparisonTypeReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string value = "va";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string> result = argInfo.StartsWith( value, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string value = "Does Not Start With";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.StartsWith( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must start with \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string value = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.StartsWith( value );
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

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.StartsWith( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
