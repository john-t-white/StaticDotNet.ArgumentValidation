namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class NotEmpty_ClassArray {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<object[]> argInfo = new( new object[] { new() }, null, null );

		ArgInfo<object[]> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullableArrayReturnsCorrectly() {

		ArgInfo<object?[]> argInfo = new( new object?[] { 1, null }, null, null );

		ArgInfo<object?[]> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<object[]?> argInfo = new( null, null, null );

		ArgInfo<object[]?> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		object[] value = Array.Empty<object>();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<object[]> argInfo = new( value, name, null );
			_ = argInfo .NotEmpty( );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		object[] value = Array.Empty<object>();
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<object[]> argInfo = new( value, name, message );
			_ = argInfo .NotEmpty( );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
