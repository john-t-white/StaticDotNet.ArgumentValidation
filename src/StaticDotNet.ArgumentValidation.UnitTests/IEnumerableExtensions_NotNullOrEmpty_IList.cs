
namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class IEnumerableExtensions_NotNullOrEmpty_IList {

	[Fact]
	public void WithValueReturnsCorrectly() {
		List<string> value = new List<string>() { "Value" };

		IList<string> result = Arg.Is.NotNullOrEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		IList<string>? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		IList<string> value = new List<string>() { };

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentNullException() {
		IList<string>? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Arg.Is.NotNullOrEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException() {
		IList<string>? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}