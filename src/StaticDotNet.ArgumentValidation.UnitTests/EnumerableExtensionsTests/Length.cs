namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class Length {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "123", null, null );
		int length = 3;

		ArgInfo<string> result = argInfo.Length( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void IEnumerableReturnsCorrectly() {

		EnumerableTestClass value = new( "123".ToCharArray() );
		ArgInfo<EnumerableTestClass> argInfo = new( value, null, null );
		int length = 3;

		ArgInfo<EnumerableTestClass> result = argInfo.Length( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );
		int length = 3;

		ArgInfo<string?> result = argInfo.Length( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthNotEqualToThrowsArgumentOutOfRangeException() {

		string value = "12";
		string name = "Name";
		int length = 3;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.Length( length );
		} );

		string expectedMessage = $"Value must have a length equal to {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string value = "12";
		string name = "Name";
		string message = "Message";
		int length = 3;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.Length( length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
