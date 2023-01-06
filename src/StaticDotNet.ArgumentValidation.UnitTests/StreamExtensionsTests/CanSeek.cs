using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.StreamExtensionsTests;

public sealed class CanSeek {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<Stream> argInfo = new( new MemoryStream(), null, null );

		ArgInfo<Stream> result = argInfo.CanSeek();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotReadableThrowsArgumentException() {

		Stream argumentValue = Substitute.For<Stream>();
		_ = argumentValue.CanSeek.Returns( false );

		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<Stream> argInfo = new( argumentValue, name, null );
			_ = argInfo.CanSeek();
		} );

		string expectedMessage = "Value must be seekable.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNotReadableAndMessageThrowsArgumentException() {

		Stream argumentValue = Substitute.For<Stream>();
		_ = argumentValue.CanSeek.Returns( false );

		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<Stream> argInfo = new( argumentValue, name, message );
			_ = argInfo.CanSeek();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
