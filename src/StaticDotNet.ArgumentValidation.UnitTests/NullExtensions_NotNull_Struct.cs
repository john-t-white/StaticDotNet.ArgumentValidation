namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class NullExtensions_NotNull_Struct {

	[Fact]
	public void WithNotNullValueReturnsCorrectly() {
		int? value = 1;

		int result = Argument.Is.NotNull( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		int? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNull( value ) );
	}

	[Fact]
	public void WithNullValueAndNameThrowsArgumentNullException() {
		int? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Argument.Is.NotNull( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException() {
		int? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ),
			() => Argument.Is.NotNull( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}