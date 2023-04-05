namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class MaxLength {

	[Theory]
	[InlineData( "1" )]
	[InlineData( "12" )]
	public void ReturnsCorrectly( string argumentValue ) {

		int length = 2;

		ArgInfo<string> argInfo = new( argumentValue, null, null );

		ArgInfo<string> result = StringExtensions.MaxLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLargerThanMaxThrowsArgumentOutOfRangeException() {

		string argumentValue = "123";
		string name = "Name";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringExtensions.MaxLength( argInfo, length );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Length} exceeds the maximum length of {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string argumentValue = "123";
		string name = "Name";
		string message = "Message";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringExtensions.MaxLength( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
