using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.DateTimeExtensionsTests;

public sealed class Utc {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<DateTime> argInfo = new( new DateTime( 2000, DateTimeKind.Utc), null, null );

		ArgInfo<DateTime> result = DateTimeExtensions.Utc( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithFalseValueThrowsArgumentException() {

		DateTime argumentValue = new DateTime( 2000, DateTimeKind.Unspecified );
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<DateTime> argInfo = new( argumentValue, name, null );
			_ = DateTimeExtensions.Utc( argInfo );
		} );

		string expectedMessage = "Value must be UTC.";
		Assert.StartsWith(expectedMessage, exception.Message );
	}

	[Fact]
	public void WithFalseValueAndMessageThrowsArgumentException() {

		DateTime argumentValue = new DateTime( 2000, DateTimeKind.Unspecified );
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<DateTime> argInfo = new( argumentValue, name, message );
			_ = DateTimeExtensions.Utc( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
