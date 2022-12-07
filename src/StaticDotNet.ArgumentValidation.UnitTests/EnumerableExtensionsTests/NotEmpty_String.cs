namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class NotEmpty_String {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );

		ArgInfo<string> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithWhiteSpaceValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( " ", null, null );

		ArgInfo<string?> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		string value = string.Empty;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo .NotEmpty( );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string value = string.Empty;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo .NotEmpty( );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
