namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class Length_String {

	[Fact]
	public void ReturnsCorrectly() {

		string value = "12";
		int length = 2;

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = argInfo.Length( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int length = 2;

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = argInfo.Length( length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthNotEqualToThrowsArgumentOutOfRangeException() {

		string name = "123";
		string value = "Value";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.Length( length );
		} );

		string expectedMessage = $"Value must have a length equal to {length}.";

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
			_ = argInfo.Length( length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
