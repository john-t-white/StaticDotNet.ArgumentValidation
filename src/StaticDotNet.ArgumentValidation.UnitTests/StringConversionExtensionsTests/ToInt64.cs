namespace StaticDotNet.ArgumentValidation.UnitTests.StringConversionExtensionsTests;

public sealed class ToInt64 {

	[Fact]
	public void ReturnsCorrectly() {

		long expectedResult = 1;
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<long> result = StringConversionExtensions.ToInt64( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToInt64( argInfo );
		} );

		string expectedMessage = "Value must be an int64.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToInt64( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
