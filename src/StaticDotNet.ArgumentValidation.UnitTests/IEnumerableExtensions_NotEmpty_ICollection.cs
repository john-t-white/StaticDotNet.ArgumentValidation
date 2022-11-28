using System.Collections.ObjectModel;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class IEnumerableExtensions_NotEmpty_ICollection {

	[Fact]
	public void WithValueReturnsCorrectly() {
		ICollection<string> value = new Collection<string>() { "Value" };

		ICollection<string> result = Arg.Is.NotEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		ICollection<string>? value = null;

		ICollection<string>? result = Arg.Is.NotEmpty( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		ICollection<string> value = new Collection<string>() { };

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentException() {
		ICollection<string> value = new Collection<string>() { };
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.NotEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentException() {
		ICollection<string> value = new Collection<string>() { };
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}