namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class MinLength {

	[Theory]
	[InlineData( "12" )]
	[InlineData( "123" )]
	public void ReturnsCorrectly( string value ) {

		int length = 2;

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = argInfo.MinLength( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "12" )]
	[InlineData( "123" )]
	public void IEnumerableReturnsCorrectly( string value ) {

		EnumerableTestClass enumerableValue = new( value.ToCharArray() );
		ArgInfo<EnumerableTestClass> argInfo = new( enumerableValue, null, null );
		int length = 2;

		ArgInfo<EnumerableTestClass> result = argInfo.MinLength( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int length = 2;

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = argInfo.MinLength( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLessThanMinLengthThrowsArgumentOutOfRangeException() {

		string name = "Name";
		string value = "1";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.MinLength( length );
		} );

		string expectedMessage = $"Value cannot have a length less than {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string name = "Name";
		string value = "1";
		string message = "Message";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.MinLength( length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
