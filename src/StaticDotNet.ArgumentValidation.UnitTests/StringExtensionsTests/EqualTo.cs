namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class EqualTo {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string comparisonValue = "value";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string> result = argInfo.EqualTo( comparisonValue, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		string comparisonValue = "value";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string?> result = argInfo.EqualTo( comparisonValue, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string comparisonValue = "Not Equal Value";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;


		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.EqualTo( comparisonValue, comparisonType );
		} );

		string expectedMessage = $"Value must be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string message = "Message";
		string comparisonValue = "Not Equal Value";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.EqualTo( comparisonValue, comparisonType );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
