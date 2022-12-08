namespace StaticDotNet.ArgumentValidation.UnitTests.StringExtensionsTests;

public sealed class ToTypeMaybeNull {

	[Fact]
	public void ReturnsCorrectly() {

		Type expectedType = typeof( string );
		ArgInfo<string?> argInfo = new( expectedType.FullName ?? throw new InvalidOperationException( "Fullname should not be null." ), null, null );

		ArgInfo<Type?> result = StringExtensions.ToTypeMaybeNull( argInfo );

		Assert.Same( expectedType, result.Value );
	}

	[Fact]
	public void WithNullValueThrowsReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<Type?> result = StringExtensions.ToTypeMaybeNull( argInfo );

		Assert.Null( result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string value = "Not a type.";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string?> argInfo = new( value, name, null );
			_ = StringExtensions.ToTypeMaybeNull( argInfo );
		} );

		string expectedMessage = "Value must be a valid type.";

		Assert.StartsWith( expectedMessage, exception.Message );
		Assert.NotNull( exception.InnerException );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string value = "Not a type.";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string?> argInfo = new( value, name, message );
			_ = StringExtensions.ToTypeMaybeNull( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
		Assert.NotNull( exception.InnerException );
	}
}
