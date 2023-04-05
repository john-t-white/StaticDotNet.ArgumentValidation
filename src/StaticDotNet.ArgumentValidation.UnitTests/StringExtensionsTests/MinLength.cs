namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class MinLength {

	[Theory]
	[InlineData( "12" )]
	[InlineData( "123" )]
	public void ReturnsCorrectly( string argumentValue ) {

		int length = 2;

		ArgInfo<string> argInfo = new( argumentValue, null, null );

		ArgInfo<string> result = StringExtensions.MinLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLessThanMinLengthThrowsArgumentOutOfRangeException() {

		string argumentValue = "1";
		string name = "Name";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringExtensions.MinLength( argInfo, length );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Length} is below the minimum length of {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string argumentValue = "1";
		string name = "Name";
		string message = "Message";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringExtensions.MinLength( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
