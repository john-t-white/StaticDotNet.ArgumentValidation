using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.BooleanExtensionsTests;

public sealed class True {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<bool> argInfo = new( true, null, null );

		ArgInfo<bool> result = BooleanExtensions.True( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithFalseValueThrowsArgumentException() {

		bool argumentValue = false;
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<bool> argInfo = new( argumentValue, name, null );
			_ = BooleanExtensions.True( argInfo );
		} );

		string expectedMessage = "Value must be true.";
		Assert.StartsWith(expectedMessage, exception.Message );
	}

	[Fact]
	public void WithFalseValueAndMessageThrowsArgumentException() {

		bool argumentValue = false;
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<bool> argInfo = new( argumentValue, name, message );
			_ = BooleanExtensions.True( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
