using NSubstitute;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StreamExtensions_Readable {

	[Fact]
	public void WithValueReturnsCorrectly() {
		MemoryStream value = new();

		MemoryStream result = Arg.Is.Readable( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {
		Stream? value = null;

		Stream? result = Arg.Is.Readable( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithNonReadableValueThrowsArgumentException() {
		Stream? value = Substitute.For<Stream>();
		_ = value.CanRead.Returns( false );

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.Readable( value ) );

		string expectedMessage = "Value must be readable.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNonReadableValueAndNameThrowsArgumentException() {
		Stream? value = Substitute.For<Stream>();
		_ = value.CanRead.Returns( false );

		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.Readable( value, name ) );
	}

	[Fact]
	public void WithNonReadableValueAndMessageThrowsArgumentException() {
		Stream? value = Substitute.For<Stream>();
		_ = value.CanRead.Returns( false );

		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.Readable( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}