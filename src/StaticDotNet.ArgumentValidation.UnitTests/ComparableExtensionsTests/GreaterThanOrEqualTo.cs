namespace StaticDotNet.ArgumentValidation.UnitTests.ComparableExtensionsTests;

public sealed class GreaterThanOrEqualTo {

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void ReturnsCorrectly( int argumentValue ) {

		int value = 2;

		ArgInfo<int> argInfo = new( argumentValue, null, null );

		ArgInfo<int> result = argInfo.GreaterThanOrEqualTo( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToThrowsArgumentOutOfRangeException() {

		int argumentValue = 1;
		string name = "Name";
		int value = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, null );
			_ = argInfo.GreaterThanOrEqualTo( value );
		} );

		string expectedMessage = $"Value must be greater than or equal to {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToToAndMessageThrowsArgumentOutOfRangeException() {

		int argumentValue = 1;
		string name = "Name";
		string message = "Message";
		int value = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, message );
			_ = argInfo.GreaterThanOrEqualTo( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
