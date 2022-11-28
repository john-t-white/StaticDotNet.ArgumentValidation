using System.Collections;
using System.Collections.ObjectModel;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class IEnumerableExtensions_NotNullOrEmpty_Array {

	[Fact]
	public void WithValueReturnsCorrectly() {
		IEnumerable value = new string[] { "Value" };

		IEnumerable result = Arg.Is.NotNullOrEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		IEnumerable? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		IEnumerable value = Array.Empty<string>();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentNullException() {
		IEnumerable? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Arg.Is.NotNullOrEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException() {
		IEnumerable? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullOrEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}