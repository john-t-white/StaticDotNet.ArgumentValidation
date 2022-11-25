using NSubstitute;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StreamExtensions_NotNullWritable {

	[Fact]
	public void WithValueReturnsCorrectly() {
		MemoryStream value = new();

		MemoryStream result = Argument.Is.NotNullWriteable( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {
		Stream? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullWriteable( value ) );
	}

	[Fact]
	public void WithNonReadableValueThrowsArgumentException() {
		Stream? value = Substitute.For<Stream>();
		_ = value.CanWrite.Returns( false );

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullWriteable( value ) );

		string expectedMessage = "Value must be writable.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}
}