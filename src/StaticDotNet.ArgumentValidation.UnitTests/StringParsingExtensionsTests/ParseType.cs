namespace StaticDotNet.ArgumentValidation.UnitTests.StringParsingExtensionsTests;

public sealed class ParseType {

	[Fact]
	public void ReturnsCorrectly() {

		Type expectedType = typeof( string );
		ArgInfo<string> argInfo = new( expectedType.FullName ?? throw new InvalidOperationException( "Fullname not available." ), null, null );

		ArgInfo<Type> result = StringParsingExtensions.ParseType( argInfo );

		Assert.Same( expectedType, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringParsingExtensions.ParseType( argInfo );
		} );

		string expectedMessage = "Value must be parsable to System.Type.";

		Assert.StartsWith( expectedMessage, exception.Message );
		Assert.NotNull( exception.InnerException );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringParsingExtensions.ParseType( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
		Assert.NotNull( exception.InnerException );
	}
}
