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

		EnumerableTestClass argumentValue = new( "123".ToCharArray() );
		ArgInfo<EnumerableTestClass> argInfo = new( argumentValue, null, null );
		int length = 3;

		ArgInfo<EnumerableTestClass> result = argInfo.Length( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthNotEqualToThrowsArgumentOutOfRangeException() {

		string argumentValue = "12";
		string name = "Name";
		int length = 3;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.Length( length );
		} );

		string expectedMessage = $"Value must have a length equal to {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string argumentValue = "12";
		string name = "Name";
		string message = "Message";
		int length = 3;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.Length( length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
