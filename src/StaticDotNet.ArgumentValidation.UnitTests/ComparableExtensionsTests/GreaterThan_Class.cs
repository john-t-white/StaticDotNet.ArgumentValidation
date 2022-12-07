namespace StaticDotNet.ArgumentValidation.UnitTests.ComparableExtensionsTests;

public sealed class GreaterThan_Class {

	[Fact]
	public void ReturnsCorrectly() {

		string value = "c";
		string comparisonValue = "b";

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = argInfo.GreaterThan( comparisonValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		string? value = null;
		string comparisionValue = "b";

		ArgInfo<string?> argInfo = new( value, null, null );

		ArgInfo<string?> result = argInfo.GreaterThan( comparisionValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "a" )]
	[InlineData( "b" )]
	public void WithValueNotGreaterThanThrowsArgumentOutOfRangeException( string value ) {

		string name = "Name";
		string comparisionValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.GreaterThan( comparisionValue );
		} );

		string expectedMessage = $"Value must be greater than {comparisionValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string name = "Name";
		string comparisionValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.GreaterThan( comparisionValue );
		} );

		string expectedMessage = $"Value must be greater than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanAndMessageThrowsArgumentOutOfRangeException() {

		string value = "a";
		string name = "Name";
		string message = "Message";
		string comparisionValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.GreaterThan( comparisionValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
