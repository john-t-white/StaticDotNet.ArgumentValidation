namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StringExtensions_Contains {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string endsWidth = "alu";

		ArgInfo<string> result = StringExtensions.Contains( argInfo, endsWidth );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		string endsWidth = "alu";

		ArgInfo<string?> result = StringExtensions.Contains( argInfo, endsWidth );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string endsWidth = "Does Not Contain";


		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = StringExtensions.Contains( argInfo, endsWidth );
		} );

		string expectedMessage = $"Value must contain {endsWidth}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string message = "Message";
		string endsWidth = "Does Not Contain";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = StringExtensions.Contains( argInfo, endsWidth );
		} );

		Assert.StartsWith( message, exception.Message );
	}

#if !NET48

	[Fact]
	public void WithStringComparisonReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		string endsWidth = "alu";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string> result = StringExtensions.Contains( argInfo, endsWidth, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullAndStringComparisonValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		string endsWidth = "alu";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string?> result = StringExtensions.Contains( argInfo, endsWidth, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueAndStringComparisonThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string endsWidth = "Does Not Contain";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;


		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = StringExtensions.Contains( argInfo, endsWidth, comparisonType );
		} );

		string expectedMessage = $"Value must contain {endsWidth}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndStringComparisonAndMessageThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string message = "Message";
		string endsWidth = "Does Not Contain";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = StringExtensions.Contains( argInfo, endsWidth, comparisonType );
		} );

		Assert.StartsWith( message, exception.Message );
	}

#endif
}
