namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class ToInt32 {

	[Fact]
	public void ReturnsCorrectly() {

		int expectedInt32 = 1;
		ArgInfo<string> argInfo = new( expectedInt32.ToString(), null, null );

		ArgInfo<int> result = StringExtensions.ToInt32( argInfo );

		Assert.Equal( expectedInt32, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringExtensions.ToInt32( argInfo );
		} );

		string expectedMessage = "Value must be an int32.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringExtensions.ToInt32( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
