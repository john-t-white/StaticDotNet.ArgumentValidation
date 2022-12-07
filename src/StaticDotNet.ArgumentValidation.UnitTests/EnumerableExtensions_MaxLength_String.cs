namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EnumerableExtensions_MaxLength_String {

	[Theory]
	[InlineData( "1" )]
	[InlineData( "12" )]
	public void ReturnsCorrectly( string value ) {

		int maxLength = 2;

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = EnumerableExtensions.MaxLength( argInfo, maxLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int maxLength = 2;

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = EnumerableExtensions.MaxLength( argInfo, maxLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLargerThanMaxThrowsArgumentOutOfRangeException() {

		string name = "123";
		string value = "Value";
		int maxLength = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = EnumerableExtensions.MaxLength( argInfo, maxLength );
		} );

		string expectedMessage = $"Value cannot have a length greater than {maxLength}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string name = "123";
		string value = "Value";
		string message = "Message";
		int maxLength = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = EnumerableExtensions.MaxLength( argInfo, maxLength );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
