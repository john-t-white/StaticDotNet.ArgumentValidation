
namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class Argument_IList_NotNullOrEmpty {

	[Fact]
	public void WithValueReturnsCorrectly() {
		IList<string> value = new List<string>() { "Value" };

		IList<string> result = Argument.Is.NotNullOrEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		IList<string>? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrEmpty( value ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		IList<string> value = new List<string>() { };

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentNullException() {
		IList<string>? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Argument.Is.NotNullOrEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException() {
		IList<string>? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}