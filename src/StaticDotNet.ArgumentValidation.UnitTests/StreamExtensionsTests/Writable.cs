using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.StreamExtensionsTests;

public sealed class Writable {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<Stream> argInfo = new( new MemoryStream(), null, null );

		ArgInfo<Stream> result = argInfo.Writable();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotReadableThrowsArgumentException() {

		Stream argumentValue = Substitute.For<Stream>();
		_ = argumentValue.CanWrite.Returns( false );

		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<Stream> argInfo = new( argumentValue, name, null );
			_ = argInfo.Writable();
		} );

		string expectedMessage = "Value must be writable.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNotReadableAndMessageThrowsArgumentException() {

		Stream argumentValue = Substitute.For<Stream>();
		_ = argumentValue.CanWrite.Returns( false );

		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<Stream> argInfo = new( argumentValue, name, message );
			_ = argInfo.Writable();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
