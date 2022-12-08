namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class MaxLength {

	[Theory]
	[InlineData( "1" )]
	[InlineData( "12" )]
	public void ReturnsCorrectly( string value ) {

		int length = 2;

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = argInfo.MaxLength( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "1" )]
	[InlineData( "12" )]
	public void IEnumerableReturnsCorrectly( string value ) {

		EnumerableTestClass enumerableValue = new( value.ToCharArray() );
		ArgInfo<EnumerableTestClass> argInfo = new( enumerableValue, null, null );
		int length = 2;

		ArgInfo<EnumerableTestClass> result = argInfo.MaxLength( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int length = 2;

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = argInfo.MaxLength( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLargerThanMaxThrowsArgumentOutOfRangeException() {

		string name = "123";
		string value = "Value";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.MaxLength( length );
		} );

		string expectedMessage = $"Value cannot have a length greater than {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string name = "123";
		string value = "Value";
		string message = "Message";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.MaxLength( length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
