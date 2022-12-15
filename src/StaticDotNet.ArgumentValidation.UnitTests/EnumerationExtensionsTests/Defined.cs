using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerationExtensionsTests;

public sealed class Defined {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<StubEnum> argInfo = new( StubEnum.Value1, null, null );

		ArgInfo<StubEnum> result = argInfo.Defined();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotDefinedThrowsArgumentException() {

		StubEnum value = ( StubEnum )10;
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<StubEnum> argInfo = new( value, name, null );
			_ = argInfo.Defined();
		} );

		string expectedMessage = "Value is not defined.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNotDefinedAndMessageThrowsArgumentException() {

		StubEnum value = ( StubEnum )10;
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<StubEnum> argInfo = new( value, name, message );
			_ = argInfo.Defined();
		} );

		Assert.StartsWith( message, exception.Message );
	}

	public enum StubEnum {
		Value1,
		Value2,
		Value3
	}
}
