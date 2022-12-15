namespace StaticDotNet.ArgumentValidation.UnitTests.ArgTests;

public sealed class IsNotNullOrWhiteSpace {

	[Fact]
	public void ReturnsCorrectly() {

		string value = "Value";

		ArgInfo<string> result = Arg.IsNotNullOrWhiteSpace( value );

		Assert.Same( value, result.Value );
		Assert.Equal( nameof( value ), result.Name );
		Assert.Null( result.Message );
	}

	[Fact]
	public void WithNameAndMessageReturnsCorrectly() {

		string value = "Value";
		string name = "Name";
		string message = "Message";

		ArgInfo<string> result = Arg.IsNotNullOrWhiteSpace( value, name, message );

		Assert.Same( value, result.Value );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.IsNotNullOrWhiteSpace( value ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string value = string.Empty;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.IsNotNullOrWhiteSpace( value ) );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithWhiteSpaceValueThrowsArgumentException() {

		string value = " ";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.IsNotNullOrWhiteSpace( value ) );

		string expectedMessage = "Value cannot be white space.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueIsNullAndNameThrowsArgumentNullException() {

		string? value = null;
		string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Arg.IsNotNullOrWhiteSpace( value, name ) );
	}

	[Fact]
	public void WithNullableValueIsNullAndMessageThrowsArgumentNullException() {

		string? value = null;
		string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.IsNotNullOrWhiteSpace( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
