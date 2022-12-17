namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class Lower {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<char> argInfo = new( 'a', null, null );

		ArgInfo<char> result = argInfo.Lower();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLowerValueThrowsArgumentException() {

		char argumentValue = 'A';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.Lower();
		} );

		string expectedMessage = "Value must be lower.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = 'A';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.Lower();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
