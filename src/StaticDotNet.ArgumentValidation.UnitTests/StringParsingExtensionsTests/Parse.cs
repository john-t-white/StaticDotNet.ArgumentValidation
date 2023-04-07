#if NET7_0_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringParsingExtensionsTests;

public sealed class Parse {

	[Fact]
	public void ReturnsCorrectly() {

		var expectedResult = Guid.NewGuid();
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<Guid> result = StringParsingExtensions.Parse<Guid>( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringParsingExtensions.Parse<Guid>( argInfo );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be parsable to {typeof( Guid ).FullName}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringParsingExtensions.Parse<Guid>( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
