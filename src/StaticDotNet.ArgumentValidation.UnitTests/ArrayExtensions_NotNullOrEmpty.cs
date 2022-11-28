namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class ArrayExtensions_NotNullOrEmpty {

	[Fact]
	public void WithValueReturnsCorrectly() {
		string[] value = { "Value" };

		string[] result = Arg.Is.NotNullOrEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		string[]? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		string[] value = Array.Empty<string>();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentNullException() {
		string[]? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Arg.Is.NotNullOrEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException() {
		string[]? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithArrayValueReturnsCorrectly() {
		Array value = new string[] { "Value" };

		Array result = Arg.Is.NotNullOrEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullArrayValueThrowsArgumentNullException() {
		Array? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value ) );
	}

	[Fact]
	public void WithEmptyArrayValueThrowsArgumentException() {
		Array value = Array.Empty<string>();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullArrayValueAndNameThrowsArgumentNullException() {
		Array? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Arg.Is.NotNullOrEmpty( value, name ) );
	}

	[Fact]
	public void WithNullArrayValueAndMessageThrowsArgumentNullException() {
		Array? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}