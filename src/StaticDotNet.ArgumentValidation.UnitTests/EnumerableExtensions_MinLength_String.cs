namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EnumerableExtensions_MinLength_String {

	[Theory]
	[InlineData( "12" )]
	[InlineData( "123" )]
	public void ReturnsCorrectly( string value ) {

		int minLength = 2;

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = EnumerableExtensions.MinLength( argInfo, minLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int minLength = 2;

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = EnumerableExtensions.MinLength( argInfo, minLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLessThanMinLengthThrowsArgumentOutOfRangeException() {

		string name = "Name";
		string value = "1";
		int minLength = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = EnumerableExtensions.MinLength( argInfo, minLength );
		} );

		string expectedMessage = $"Value cannot have a length less than {minLength}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string name = "Name";
		string value = "1";
		string message = "Message";
		int minLength = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = EnumerableExtensions.MinLength( argInfo, minLength );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
