
namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class IEnumerableExtensions_NotEmpty_IDictionary {

	[Fact]
	public void WithValueReturnsCorrectly() {
		IDictionary<string, string> value = new Dictionary<string, string>() { { "Key", "Value" } };

		IDictionary<string, string> result = Argument.Is.NotEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {
		IDictionary<string, string>? value = null;

		IDictionary<string, string>? result = Argument.Is.NotEmpty( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		IDictionary<string, string> value = new Dictionary<string, string>();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentException() {
		IDictionary<string, string> value = new Dictionary<string, string>();
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentException() {
		IDictionary<string, string> value = new Dictionary<string, string>();
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}