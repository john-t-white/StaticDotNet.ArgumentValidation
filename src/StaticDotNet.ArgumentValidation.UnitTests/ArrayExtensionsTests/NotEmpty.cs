namespace StaticDotNet.ArgumentValidation.UnitTests.ArrayExtensionsTests;

public sealed class NotEmpty {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string[]> argInfo = new( new[] { "A" }, null, null );

		ArgInfo<string[]> result = ArrayExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string[] argumentValue = Array.Empty<string>();
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, null );
			_ = ArrayExtensions.NotEmpty( argInfo );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string[] argumentValue = Array.Empty<string>();
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, message );
			_ = ArrayExtensions.NotEmpty( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
