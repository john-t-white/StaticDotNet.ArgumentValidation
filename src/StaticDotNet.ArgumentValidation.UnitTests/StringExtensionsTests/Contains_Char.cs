namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class Contains_Char {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		char value = 'l';

		ArgInfo<string> result = StringExtensions.Contains( argInfo, value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		char value = 'z';

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
		char value = 'z';

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringExtensions.Contains( argInfo, value );
		} );

		Assert.StartsWith( message, exception.Message );
	}

#if !NET481

	[Fact]
	public void WithStringComparisonReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		char value = 'l';
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgInfo<string> result = StringExtensions.Contains( argInfo, value, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithWithStringComparisonAndValueNotEqualToValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		char value = 'z';
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringExtensions.Contains( argInfo, value, comparisonType );
		} );

		string expectedMessage = $"Value must contain {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithWithStringComparisonAndInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string message = "Message";
		char value = 'z';
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringExtensions.Contains( argInfo, value, comparisonType );
		} );

		Assert.StartsWith( message, exception.Message );
	}

#endif
}
