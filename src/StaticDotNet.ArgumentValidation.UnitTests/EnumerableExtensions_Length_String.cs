namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EnumerableExtensions_Length_String {

    [Fact]
	public void ReturnsCorrectly() {

        string value = "12";
		int length = 2;

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = EnumerableExtensions.Length( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int length = 2;

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = EnumerableExtensions.Length( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthNotEqualToThrowsArgumentOutOfRangeException() {

		string name = "123";
		string value = "Value";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = EnumerableExtensions.Length( argInfo, length );
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
			_ = EnumerableExtensions.Length( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
