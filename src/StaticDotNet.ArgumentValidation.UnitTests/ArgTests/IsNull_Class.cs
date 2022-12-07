namespace StaticDotNet.ArgumentValidation.UnitTests.ArgTests;

public sealed class IsNull_Class {

	[Fact]
	public void ReturnsCorrectly() {

		object? value = null;

		object? result = Arg.IsNull( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithNonNullValueThrowsArgumentException() {

		object? value = new();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.IsNull( value ) );

		string expectedMessage = "Value must be null.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNonNullValueAndNameThrowsArgumentException() {

		object? value = new();
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.IsNull( value, name ) );
	}

	[Fact]
	public void WithNonNullValueAndMessageThrowsArgumentException() {

		object? value = new();
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.IsNull( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
