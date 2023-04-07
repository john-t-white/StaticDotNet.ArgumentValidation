namespace StaticDotNet.ArgumentValidation.UnitTests.StringParsingExtensionsTests;

public sealed class ParseBoolean {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "true", null, null );

		ArgInfo<bool> result = StringParsingExtensions.ParseBoolean( argInfo );

		Assert.True( result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringParsingExtensions.ParseBoolean( argInfo );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be parsable to System.Boolean.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringParsingExtensions.ParseBoolean( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
