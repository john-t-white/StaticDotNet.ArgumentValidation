namespace StaticDotNet.ArgumentValidation.UnitTests.LengthExtensionsTests;

public sealed class Length {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );
		int length = 5;

		ArgInfo<string> result = StringExtensions.Length( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthNotEqualToThrowsArgumentOutOfRangeException() {

		string argumentValue = "Value";
		string name = "Name";
		int length = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringExtensions.Length( argInfo, length );
		} );

		string expectedMessage = $"Value must have a length equal to {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string argumentValue = "Value";
		string name = "Name";
		string message = "Message";
		int length = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringExtensions.Length( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
