namespace StaticDotNet.ArgumentValidation.UnitTests.CharExtensionsTests;

public sealed class Number {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<char> argInfo = new( '1', null, null );

		ArgInfo<char> result = argInfo.Number();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotNumberValueThrowsArgumentException() {

		char argumentValue = 'a';
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.Number();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be a number.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		char argumentValue = 'a';
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.Number();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
