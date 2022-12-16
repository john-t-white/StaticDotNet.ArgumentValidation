using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.StreamExtensionsTests;

public sealed class Readable {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<Stream> argInfo = new( new MemoryStream(), null, null );

		ArgInfo<Stream> result = argInfo.Readable();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotReadableThrowsArgumentException() {

		Stream argumentValue = Substitute.For<Stream>();
		_ = argumentValue.CanRead.Returns( false );

		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<Stream> argInfo = new( argumentValue, name, null );
			_ = argInfo.Readable();
		} );

		string expectedMessage = "Value must be readable.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNotReadableAndMessageThrowsArgumentException() {

		Stream argumentValue = Substitute.For<Stream>();
		_ = argumentValue.CanRead.Returns( false );

		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<Stream> argInfo = new( argumentValue, name, message );
			_ = argInfo.Readable();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
