namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StringExtensions_EndsWith {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string endsWidth = "ue";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string> result = StringExtensions.EndsWith( argInfo, endsWidth, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		string endsWidth = "ue";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string?> result = StringExtensions.EndsWith( argInfo, endsWidth, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string endsWidth = "Does Not End With";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;


		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = StringExtensions.EndsWith( argInfo, endsWidth, comparisonType );
		} );

		string expectedMessage = $"Value must end with {endsWidth}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string message = "Message";
		string endsWidth = "Does Not End With";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = StringExtensions.EndsWith( argInfo, endsWidth, comparisonType );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
