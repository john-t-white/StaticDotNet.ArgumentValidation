namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EnumerableExtensions_NotEmpty_ISet {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<ISet<object>> argInfo = new( new HashSet<object>() { new() }, null, null );

		ArgInfo<ISet<object>> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<ISet<object>?> argInfo = new( null, null, null );

		ArgInfo<ISet<object>?> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		ISet<object> value = new HashSet<object>();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<ISet<object>> argInfo = new( value, name, null );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		ISet<object> value = new HashSet<object>();
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<ISet<object>> argInfo = new( value, name, message );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
