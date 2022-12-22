namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class LengthBetween {

	[Theory]
	[InlineData( "12" )]
	[InlineData( "123" )]
	[InlineData( "1234" )]
	public void ReturnsCorrectly( string argumentValue ) {

		ArgInfo<string> argInfo = new( argumentValue, null, null );
		int minLength = 2;
		int maxLength = 4;

		ArgInfo<string> result = StringExtensions.LengthBetween( argInfo, minLength, maxLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "1" )]
	[InlineData( "12345" )]
	public void WithValueLengthNotBetweenThrowsArgumentOutOfRangeException( string argumentValue ) {

		string name = "Name";
		int minLength = 2;
		int maxLength = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		string expectedMessage = $"Value must have a length between {minLength} and {maxLength}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string argumentValue = "1";
		string name = "Name";
		string message = "Message";
		int minLength = 2;
		int maxLength = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
