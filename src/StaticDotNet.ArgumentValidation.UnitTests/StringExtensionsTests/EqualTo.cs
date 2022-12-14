namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class EqualTo {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string value = "value";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string> result = argInfo.EqualTo( value, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string value = "Not Equal Value";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;


		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.EqualTo( value, comparisonType );
		} );

		string expectedMessage = $"Value must be equal to {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string message = "Message";
		string value = "Not Equal Value";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.EqualTo( value, comparisonType );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
