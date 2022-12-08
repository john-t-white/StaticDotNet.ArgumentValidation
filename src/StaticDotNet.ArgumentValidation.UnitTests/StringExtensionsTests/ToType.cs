namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class ToType {

	[Fact]
	public void ReturnsCorrectly() {

		Type expectedType = typeof( string );
		ArgInfo<string> argInfo = new( expectedType.FullName ?? throw new InvalidOperationException( "Fullname should not be null." ), null, null );

		ArgInfo<Type> result = StringExtensions.ToType( argInfo );

		Assert.Same( expectedType, result.Value );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string value = null!;
		string name = "Name";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( name, () => {

			ArgInfo<string> argInfo = new( value, name, null );
			_ = StringExtensions.ToType( argInfo );
		} );

		string expectedMessage = "Value must not be null and be a valid type.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException() {

		string value = null!;
		string name = "Name";
		string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( name, () => {

			ArgInfo<string> argInfo = new( value, name, message );
			_ = StringExtensions.ToType( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string value = "Not a type.";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( value, name, null );
			_ = StringExtensions.ToType( argInfo );
		} );

		string expectedMessage = "Value must not be null and be a valid type.";

		Assert.StartsWith( expectedMessage, exception.Message );
		Assert.NotNull( exception.InnerException );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string value = "Not a type.";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( value, name, message );
			_ = StringExtensions.ToType( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
		Assert.NotNull( exception.InnerException );
	}
}
