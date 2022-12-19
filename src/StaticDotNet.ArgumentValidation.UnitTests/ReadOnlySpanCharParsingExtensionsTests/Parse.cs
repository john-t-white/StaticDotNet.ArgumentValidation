#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanCharParsingExtensionsTests;

public sealed class Parse {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpanArgInfo<char> argInfo = new( "1", "Name", "Message" );

		ArgInfo<int> result = argInfo.Parse<int>();

		int expectedValue = int.Parse( argInfo.Value );

		Assert.Equal( expectedValue, result.Value );
		Assert.Equal( argInfo.Name, result.Name );
		Assert.Equal( argInfo.Message, result.Message );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.Parse<int>();
		} );

		string expectedMessage = $"Value must be parsable to {typeof( int ).FullName}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = argInfo.Parse<int>();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
