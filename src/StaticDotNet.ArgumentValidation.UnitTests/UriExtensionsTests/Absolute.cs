using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.UriExtensionsTests;

public sealed class Absolute {

	[Fact]
	public void ReturnsCorrectly() {

		Uri argumentValue = new( "http://www.example.com/", UriKind.Absolute );
		ArgInfo<Uri> argInfo = new( argumentValue, null, null );

		ArgInfo<Uri> result = argInfo.Absolute();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithSchemeReturnsCorrectly() {

		string scheme = Uri.UriSchemeHttp;
		Uri argumentValue = new( "http://www.example.com/", UriKind.Absolute );
		ArgInfo<Uri> argInfo = new( argumentValue, null, null );

		ArgInfo<Uri> result = argInfo.Absolute( scheme );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotAbsoluteThrowsArgumentException() {

		Uri argumentValue = new( "relative", UriKind.Relative );
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Uri> argInfo = new( argumentValue, name, null );
			_ = argInfo.Absolute();
		} );

		string expectedMessage = $"\"{argumentValue}\" must be an absolute uri.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNotSchemeThrowsArgumentException() {

		string scheme = Uri.UriSchemeHttps;
		Uri argumentValue = new( "http://www.example.com/", UriKind.Absolute );
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Uri> argInfo = new( argumentValue, name, null );
			_ = argInfo.Absolute( scheme );
		} );

		string expectedMessage = $"\"{argumentValue}\" must be an absolute uri with scheme {scheme}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNotAbsoluteAndMessageThrowsArgumentException() {

		Uri argumentValue = new( "relative", UriKind.Relative );
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Uri> argInfo = new( argumentValue, name, message );
			_ = argInfo.Absolute();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
