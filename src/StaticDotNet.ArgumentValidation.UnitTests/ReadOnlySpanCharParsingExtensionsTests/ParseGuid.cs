#if NETCOREAPP3_1_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanCharParsingExtensionsTests;

public sealed class ParseGuid {

	[Fact]
	public void ReturnsCorrectly() {

		var expectedResult = Guid.NewGuid();
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<Guid> result = ReadOnlySpanCharParsingExtensions.ParseGuid( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanCharParsingExtensions.ParseGuid( argInfo );
		} );

		string expectedMessage = "Value must be parsable to System.Guid.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanCharParsingExtensions.ParseGuid( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
