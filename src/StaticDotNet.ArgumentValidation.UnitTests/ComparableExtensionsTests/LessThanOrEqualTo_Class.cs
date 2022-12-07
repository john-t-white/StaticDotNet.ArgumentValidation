namespace StaticDotNet.ArgumentValidation.UnitTests.ComparableExtensionsTests;

public sealed class LessThanOrEqualTo_Class {

	[Theory]
	[InlineData( "a" )]
	[InlineData( "b" )]
	public void ReturnsCorrectly( string value ) {

		string comparisonValue = "b";

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = argInfo.LessThanOrEqualTo( comparisonValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		string? value = null;
		string comparisionValue = "b";

		ArgInfo<string?> argInfo = new( value, null, null );

		ArgInfo<string?> result = argInfo.LessThanOrEqualTo( comparisionValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToThrowsArgumentOutOfRangeException() {

		string value = "c";
		string name = "Name";
		string comparisionValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.LessThanOrEqualTo( comparisionValue );
		} );

		string expectedMessage = $"Value must be less than or equal to {comparisionValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string name = "Name";
		string comparisionValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.LessThanOrEqualTo( comparisionValue );
		} );

		string expectedMessage = $"Value must be less than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToAndMessageThrowsArgumentOutOfRangeException() {

		string value = "c";
		string name = "Name";
		string message = "Message";
		string comparisionValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.LessThanOrEqualTo( comparisionValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
