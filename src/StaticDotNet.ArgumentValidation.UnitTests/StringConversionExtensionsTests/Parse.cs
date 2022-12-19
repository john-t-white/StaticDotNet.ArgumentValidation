#if NET7_0_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringConversionExtensionsTests;

public sealed class Parse {

	[Fact]
	public void ReturnsCorrectly() {

		var expectedResult = Guid.NewGuid();
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<Guid> result = StringConversionExtensions.Parse<Guid>( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.Parse<Guid>( argInfo );
		} );

		string expectedMessage = $"Value must be parsable to {typeof( Guid ).FullName}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.Parse<Guid>( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
