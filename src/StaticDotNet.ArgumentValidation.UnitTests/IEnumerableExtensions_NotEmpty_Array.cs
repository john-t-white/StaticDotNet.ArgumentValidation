using System.Collections;
using System.Collections.ObjectModel;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class IEnumerableExtensions_NotEmpty_Array {

	[Fact]
	public void WithValueReturnsCorrectly() {
		IEnumerable value = new string[] { "Value" };

		IEnumerable result = Arg.Is.NotEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		IEnumerable? value = null;

		IEnumerable? result = Arg.Is.NotEmpty( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		IEnumerable value = Array.Empty<string>();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithEmptyValueAndNameThrowsArgumentException() {
		IEnumerable? value = Array.Empty<string>();
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.NotEmpty( value, name ) );
	}

	[Fact]
	public void WithEmptyValueAndMessageThrowsArgumentException() {
		IEnumerable? value = Array.Empty<string>();
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}