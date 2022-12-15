using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.BooleanExtensionsTests;

public sealed class False {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<bool> argInfo = new( false, null, null );

		ArgInfo<bool> result = BooleanExtensions.False( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithTrueValueThrowsArgumentException() {

		bool argumentValue = true;
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<bool> argInfo = new( argumentValue, name, null );
			_ = BooleanExtensions.False( argInfo );
		} );

		string expectedMessage = "Value must be false.";
		Assert.StartsWith(expectedMessage, exception.Message );
	}

	[Fact]
	public void WithTrueValueAndMessageThrowsArgumentException() {

		bool argumentValue = true;
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<bool> argInfo = new( argumentValue, name, message );
			_ = BooleanExtensions.False( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
