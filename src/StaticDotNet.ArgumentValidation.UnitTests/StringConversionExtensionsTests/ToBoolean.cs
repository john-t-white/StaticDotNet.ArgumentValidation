namespace StaticDotNet.ArgumentValidation.UnitTests.StringConversionExtensionsTests;

public sealed class ToBoolean {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "true", null, null );

		ArgInfo<bool> result = StringConversionExtensions.ToBoolean( argInfo );

		Assert.True( result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToBoolean( argInfo );
		} );

		string expectedMessage = "Value must be a boolean.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToBoolean( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
