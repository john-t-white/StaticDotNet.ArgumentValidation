
namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class IEnumerableExtensions_IList_NotEmpty {

	[Fact]
	public void WithValueReturnsCorrectly() {
		IList<string> value = new List<string>() { "Value" };

		IList<string> result = Argument.Is.NotEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {
		IList<string>? value = null;

		IList<string>? result = Argument.Is.NotEmpty( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		IList<string> value = new List<string>() { };

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentException() {
		IList<string> value = new List<string>() { };
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentException() {
		IList<string> value = new List<string>() { };
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}