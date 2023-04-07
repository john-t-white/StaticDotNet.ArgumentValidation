#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanCharExtensionsTests;

public sealed class EqualTo {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<char> argInfo = new( "Value", null, null );
		string value = "Value";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

		ReadOnlySpanArgInfo<char> result = argInfo.EqualTo( value, comparisonType );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string value = "Not Equal Value";
		StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;


		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.EqualTo( value, comparisonType );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be equal to \"{value}\".";

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
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.EqualTo( value, comparisonType );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
