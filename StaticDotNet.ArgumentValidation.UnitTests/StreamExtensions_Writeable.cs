using NSubstitute;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StreamExtensions_Writeable {

	[Fact]
	public void WithValueReturnsCorrectly() {
		MemoryStream value = new();

		MemoryStream result = Argument.Is.Writeable( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {
		Stream? value = null;

		Stream? result = Argument.Is.Writeable( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithNonReadableValueThrowsArgumentException() {
		Stream? value = Substitute.For<Stream>();
		_ = value.CanWrite.Returns( false );

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.Writeable( value ) );

		string expectedMessage = "Value must be writable.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}
}