namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class NotEmpty_Array {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<Array> argInfo = new( new int[] { 1 }, null, null );

		ArgInfo<Array> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullableArrayReturnsCorrectly() {

		ArgInfo<Array> argInfo = new( new int?[] { 1 }, null, null );

		ArgInfo<Array> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<Array?> argInfo = new( null, null, null );

		ArgInfo<Array?> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		Array value = Array.Empty<int>();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Array> argInfo = new( value, name, null );
			_ = argInfo .NotEmpty( );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		Array value = Array.Empty<int>();
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Array> argInfo = new( value, name, message );
			_ = argInfo .NotEmpty( );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
