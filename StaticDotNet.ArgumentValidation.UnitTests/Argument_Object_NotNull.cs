namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class Argument_Object_NotNull {

	[Fact]
	public void WithNotNullClassValueReturnsCorrectly() {
		object value = new();

		object result = Argument.Is.NotNull( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullClassValueThrowsArgumentNullException() {
		object? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNull( value ) );
	}

	[Fact]
	public void WithNullClassValueAndNameThrowsArgumentNullException() {
		object? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Argument.Is.NotNull( value, name ) );
	}

	[Fact]
	public void WithNullClassValueAndMessageThrowsArgumentNullException() {
		object? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ),
			() => Argument.Is.NotNull( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithNotNullStructValueReturnsCorrectly() {
		int? value = 1;

		int result = Argument.Is.NotNull( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullStructValueThrowsArgumentNullException() {
		int? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNull( value ) );
	}

	[Fact]
	public void WithNullStructValueAndNameThrowsArgumentNullException() {
		int? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Argument.Is.NotNull( value, name ) );
	}

	[Fact]
	public void WithNullStructValueAndMessageThrowsArgumentNullException() {
		int? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ),
			() => Argument.Is.NotNull( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}