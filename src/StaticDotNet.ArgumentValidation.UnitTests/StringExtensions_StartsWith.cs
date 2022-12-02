namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StringExtensions_StartsWith {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string startsWith = "va";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string> result = StringExtensions.StartsWith( argInfo, startsWith, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		string startsWith = "va";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string?> result = StringExtensions.StartsWith( argInfo, startsWith, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string startsWith = "Does Not Start With";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;


		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = StringExtensions.StartsWith( argInfo, startsWith, comparisonType );
		} );

		string expectedMessage = $"Value must start with {startsWith}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string message = "Message";
		string startsWith = "Does Not Start With";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = StringExtensions.StartsWith( argInfo, startsWith, comparisonType );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
