using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringConversionExtensionsTests;

public sealed class ToGuidExact {

	[Fact]
	public void ReturnsCorrectly() {

		string format = "N";
		var expectedResult = Guid.NewGuid();
		ArgInfo<string> argInfo = new( expectedResult.ToString( format ), null, null );

		ArgInfo<Guid> result = StringConversionExtensions.ToGuidExact( argInfo, format );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string format = "N";
		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToGuidExact( argInfo, format );
		} );

		string expectedMessage = "Value must be a guid.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string format = "N";
		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToGuidExact( argInfo, format );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
