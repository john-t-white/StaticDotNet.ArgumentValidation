using NSubstitute;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StreamExtensions_Readable {

	[Fact]
	public void WithValueReturnsCorrectly() {
		MemoryStream value = new();

		MemoryStream result = Argument.Is.Readable( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {
		Stream? value = null;

		Stream? result = Argument.Is.Readable( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithNonReadableValueThrowsArgumentException() {
		Stream? value = Substitute.For<Stream>();
		_ = value.CanRead.Returns( false );

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.Readable( value ) );

		string expectedMessage = "Value must be readable.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}
}