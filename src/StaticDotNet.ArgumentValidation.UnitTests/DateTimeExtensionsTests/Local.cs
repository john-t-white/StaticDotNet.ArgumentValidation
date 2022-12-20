using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.DateTimeExtensionsTests;

public sealed class Local {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<DateTime> argInfo = new( new( 2000, DateTimeKind.Local ), null, null );

		ArgInfo<DateTime> result = DateTimeExtensions.Local( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotLocalThrowsArgumentException() {

		DateTime argumentValue = new( 2000, DateTimeKind.Unspecified );
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<DateTime> argInfo = new( argumentValue, name, null );
			_ = DateTimeExtensions.Local( argInfo );
		} );

		string expectedMessage = "Value must have DateTimeKind.Local.";
		Assert.StartsWith(expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNotLocalAndMessageThrowsArgumentException() {

		DateTime argumentValue = new( 2000, DateTimeKind.Unspecified );
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<DateTime> argInfo = new( argumentValue, name, message );
			_ = DateTimeExtensions.Local( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
