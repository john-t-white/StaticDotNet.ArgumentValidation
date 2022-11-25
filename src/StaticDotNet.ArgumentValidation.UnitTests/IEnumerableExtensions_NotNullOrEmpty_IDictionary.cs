
namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class IEnumerableExtensions_NotNullOrEmpty_IDicationary {

	[Fact]
	public void WithValueReturnsCorrectly() {
		IDictionary<string, string> value = new Dictionary<string, string>() { { "Key", "Value" } };

		IDictionary<string, string> result = Argument.Is.NotNullOrEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		IDictionary<string, string>? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrEmpty( value ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		IDictionary<string, string> value = new Dictionary<string, string>();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentNullException() {
		IDictionary<string, string>? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Argument.Is.NotNullOrEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException() {
		IDictionary<string, string>? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}