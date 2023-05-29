namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class Lower {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "a", null, null );

		ArgInfo<string> result = argInfo.Lower();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLowerValueThrowsArgumentException() {

		string argumentValue = "A";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.Lower();
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be lower case.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "A";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.Lower();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
