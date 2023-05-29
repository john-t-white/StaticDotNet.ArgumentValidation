namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class Upper {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<char> argInfo = new( 'A', null, null );

		ArgInfo<char> result = argInfo.Upper();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLowerValueThrowsArgumentException() {

		char argumentValue = 'a';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.Upper();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be upper case.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = 'a';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.Upper();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
