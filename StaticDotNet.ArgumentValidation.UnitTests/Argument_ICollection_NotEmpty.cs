using System.Collections.ObjectModel;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class Argument_ICollection_NotEmpty {

	[Fact]
	public void WithValueReturnsCorrectly() {
		ICollection<string> value = new Collection<string>() { "Value" };

		ICollection<string> result = Argument.Is.NotEmpty( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		ICollection<string>? value = null;

		ICollection<string>? result = Argument.Is.NotEmpty( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {
		ICollection<string> value = new Collection<string>() { };

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEmpty( value ) );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentException() {
		ICollection<string> value = new Collection<string>() { };
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotEmpty( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentException() {
		ICollection<string> value = new Collection<string>() { };
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEmpty( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}