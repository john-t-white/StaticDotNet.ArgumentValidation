namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class ToInt16 {

	[Fact]
	public void ReturnsCorrectly() {

		short expectedResult = 1;
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<short> result = StringExtensions.ToInt16( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringExtensions.ToInt16( argInfo );
		} );

		string expectedMessage = "Value must be an int16.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringExtensions.ToInt16( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
