#if !NET481

namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class StartsWith_Char {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		char value = 'V';

		ArgInfo<string> result = argInfo.StartsWith( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToValueThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		char value = 'z';

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.StartsWith( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must start with \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Value";
		string name = "Name";
		string message = "Message";
		char value = 'z';

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.StartsWith( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
