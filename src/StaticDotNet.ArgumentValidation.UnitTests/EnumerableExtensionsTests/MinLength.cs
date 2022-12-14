namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class MinLength {

	[Theory]
	[InlineData( "12" )]
	[InlineData( "123" )]
	public void ReturnsCorrectly( string argumentValue ) {

		int length = 2;

		ArgInfo<string> argInfo = new( argumentValue, null, null );

		ArgInfo<string> result = argInfo.MinLength( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "12" )]
	[InlineData( "123" )]
	public void IEnumerableReturnsCorrectly( string argumentValue ) {

		EnumerableTestClass enumerableValue = new( argumentValue.ToCharArray() );
		ArgInfo<EnumerableTestClass> argInfo = new( enumerableValue, null, null );
		int length = 2;

		ArgInfo<EnumerableTestClass> result = argInfo.MinLength( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLessThanMinLengthThrowsArgumentOutOfRangeException() {

		string argumentValue = "1";
		string name = "Name";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.MinLength( length );
		} );

		string expectedMessage = $"Value cannot have a length less than {length}.";

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
			_ = argInfo.MinLength( length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
