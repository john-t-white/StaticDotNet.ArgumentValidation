namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class EndsWith_Char {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		char value = 'e';

		ArgInfo<string> result = argInfo.EndsWith( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		char value = 'e';

		ArgInfo<string?> result = argInfo.EndsWith( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueThrowsArgumentException() {

		string name = "Name";
		string argumentValue = "Value";
		char value = 'm';

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.EndsWith( value );
		} );

		string expectedMessage = $"Value must end with {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string argumentValue = "Value";
		string message = "Message";
		char value = 'm';

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.EndsWith( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
