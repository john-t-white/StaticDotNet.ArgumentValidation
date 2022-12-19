#if NETCOREAPP3_1_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanParsingExtensionsTests;

public sealed class ParseGuidExact {

	[Fact]
	public void ReturnsCorrectly() {

		string format = "N";
		var expectedResult = Guid.NewGuid();
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString( format ), null, null );

		ArgInfo<Guid> result = ReadOnlySpanParsingExtensions.ParseGuidExact( argInfo, format );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string format = "N";
		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanParsingExtensions.ParseGuidExact( argInfo, format );
		} );

		string expectedMessage = "Value must be parsable to System.Guid.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string format = "N";
		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanParsingExtensions.ParseGuidExact( argInfo, format );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
