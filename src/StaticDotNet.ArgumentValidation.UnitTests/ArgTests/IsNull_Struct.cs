namespace StaticDotNet.ArgumentValidation.UnitTests.ArgTests;

public sealed class IsNull_Struct {

	[Fact]
	public void ReturnsCorrectly() {

		int? value = null;

		int? result = Arg.IsNull( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithNonNullValueThrowsArgumentException() {

		int? value = 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.IsNull( value ) );

		string expectedMessage = "Value must be null.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNonNullValueAndNameThrowsArgumentException() {

		int? value = 1;
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.IsNull( value, name ) );
	}

	[Fact]
	public void WithNonNullValueAndMessageThrowsArgumentException() {

		int? value = 1;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.IsNull( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithNonNullableValueThrowsArgumentException() {

		int value = 1;

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.IsNull( value ) );
	}
}
