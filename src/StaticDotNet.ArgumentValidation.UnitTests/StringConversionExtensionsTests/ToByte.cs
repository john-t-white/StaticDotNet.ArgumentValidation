namespace StaticDotNet.ArgumentValidation.UnitTests.StringConversionExtensionsTests;

public sealed class ToByte {

	[Fact]
	public void ReturnsCorrectly() {

		byte expectedResult = 1;
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<byte> result = StringConversionExtensions.ToByte( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToByte( argInfo );
		} );

		string expectedMessage = "Value must be a byte.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToByte( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
