#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanExtensionsTests;

public sealed class StartsWith {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<char> argInfo = new( "Value", null, null );
		string value = "Va";

		ReadOnlySpanArgInfo<char> result = argInfo.StartsWith( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithComparisonTypeReturnsCorrectly() {

		ReadOnlySpanArgInfo<char> argInfo = new( "Value", null, null );
		string value = "va";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ReadOnlySpanArgInfo<char> result = argInfo.StartsWith( value, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string value = "Does Not Start With";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.StartsWith( value );
		} );

		string expectedMessage = $"Value must start with {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string message = "Message";
		string value = "Does Not Start With";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.StartsWith( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
