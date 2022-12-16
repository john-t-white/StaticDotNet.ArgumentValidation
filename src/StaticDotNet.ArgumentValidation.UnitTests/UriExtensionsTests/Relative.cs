using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.UriExtensionsTests;

public sealed class Relative {

	[Fact]
	public void ReturnsCorrectly() {

		Uri argumentValue = new( "/relative", UriKind.Relative );
		ArgInfo<Uri> argInfo = new( argumentValue, null, null );

		ArgInfo<Uri> result = argInfo.Relative();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotRelativeThrowsArgumentException() {

		Uri argumentValue = new( "http://www.example.com/", UriKind.Absolute );
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Uri> argInfo = new( argumentValue, name, null );
			_ = argInfo.Relative();
		} );

		string expectedMessage = "Value must be relative.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNotRelativeAndMessageThrowsArgumentException() {

		Uri argumentValue = new( "http://www.example.com/", UriKind.Absolute );
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Uri> argInfo = new( argumentValue, name, message );
			_ = argInfo.Relative();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
