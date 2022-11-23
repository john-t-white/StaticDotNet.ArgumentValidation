using System.Collections.ObjectModel;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class IEnumerableExtensions_NotNullOrEmpty_ICollection {

	[Fact]
	public void WithValueReturnsCorrectly() {
		ICollection<string> value = new Collection<string>() { "Value" };

		ICollection<string> result = Argument.Is.NotNullOrEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		ICollection<string>? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrEmpty( value ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		ICollection<string> value = new Collection<string>() { };

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentNullException() {
		ICollection<string>? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Argument.Is.NotNullOrEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException() {
		ICollection<string>? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}