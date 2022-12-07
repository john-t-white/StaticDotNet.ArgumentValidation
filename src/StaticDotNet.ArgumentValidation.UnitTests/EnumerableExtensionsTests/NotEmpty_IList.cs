namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class NotEmpty_IList {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<IList<object>> argInfo = new( new List<object>() { new() }, null, null );

		ArgInfo<IList<object>> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<IList<object>?> argInfo = new( null, null, null );

		ArgInfo<IList<object>?> result = argInfo .NotEmpty( );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		IList<object> value = new List<object>();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<IList<object>> argInfo = new( value, name, null );
			_ = argInfo .NotEmpty( );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		IList<object> value = new List<object>();
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<IList<object>> argInfo = new( value, name, message );
			_ = argInfo .NotEmpty( );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
