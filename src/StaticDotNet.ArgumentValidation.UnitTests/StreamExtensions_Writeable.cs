using NSubstitute;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StreamExtensions_Writeable {

	[Fact]
	public void WithValueReturnsCorrectly() {
		MemoryStream value = new();

		MemoryStream result = Arg.Is.Writeable( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {
		Stream? value = null;

		Stream? result = Arg.Is.Writeable( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithNonWriteableValueThrowsArgumentException() {
		Stream? value = Substitute.For<Stream>();
		_ = value.CanWrite.Returns( false );

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.Writeable( value ) );

		string expectedMessage = "Value must be writable.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNonRWriteValueAndNameThrowsArgumentException() {
		Stream? value = Substitute.For<Stream>();
		_ = value.CanWrite.Returns( false );

		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.Writeable( value, name ) );
	}

	[Fact]
	public void WithNonWritableValueAndMessageThrowsArgumentException() {
		Stream? value = Substitute.For<Stream>();
		_ = value.CanRead.Returns( false );

		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.Writeable( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}