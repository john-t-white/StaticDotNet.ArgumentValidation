namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class ArrayExtensions_NotEmpty {

	[Fact]
	public void WithValueReturnsCorrectly() {
		string[] value = { "Value" };

		string[] result = Arg.Is.NotEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {
		string[]? value = null;

		string[]? result = Arg.Is.NotEmpty( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		string[] value = Array.Empty<string>();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithEmptyValueAndNameThrowsArgumentException() {
		string[] value = Array.Empty<string>(); ;
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.NotEmpty( value, name ) );
	}

	[Fact]
	public void WithEmptyValueAndMessageThrowsArgumentException() {
		string[] value = Array.Empty<string>(); ;
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithArrayValueReturnsCorrectly() {
		Array value = new string[] { "Value" };

		Array result = Arg.Is.NotEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullArrayValueReturnsCorrectly() {
		Array? value = null;

		Array? result = Arg.Is.NotEmpty( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithEmptyArrayValueThrowsArgumentException() {
		Array value = Array.Empty<string>();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithEmptyArrayValueAndNameThrowsArgumentException() {
		Array value = Array.Empty<string>();
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.NotEmpty( value, name ) );
	}

	[Fact]
	public void WithEmptyArrayValueAndMessageThrowsArgumentException() {
		Array value = Array.Empty<string>();
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}