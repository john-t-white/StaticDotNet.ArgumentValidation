#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanCharExtensionsTests;

public sealed class Contains {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<char> argInfo = new( "Value", null, null );
		string value = "alu";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ReadOnlySpanArgInfo<char> result = ReadOnlySpanCharExtensions.Contains( argInfo, value, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotContainToValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string value = "Does Not Contain";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanCharExtensions.Contains( argInfo, value, comparisonType );
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
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanCharExtensions.Contains( argInfo, value, comparisonType );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
