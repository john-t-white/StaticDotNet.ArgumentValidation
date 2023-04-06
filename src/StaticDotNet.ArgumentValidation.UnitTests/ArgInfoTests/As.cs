using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.ArgInfoTests;

public sealed class As {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<object> argInfo = new( "Value", "Name", "Message" );

		ArgInfo<string> result = argInfo.As<string>();

		Assert.Same( argInfo.Value as string, result.Value );
		Assert.Equal( argInfo.Name, result.Name );
		Assert.Equal( argInfo.Message, result.Message );
	}

	[Fact]
	public void WithNotAssignableToThrowsArgumentException() {

		int argumentValue = 1;
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, null );
			_ = argInfo.As<string>();
		} );

		string expectedMessage = $"Value of type {argumentValue.GetType().FullName} must be assignable to {typeof( string ).FullName}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNotAssignableToAndMessageThrowsArgumentException() {

		object argumentValue = new();
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<object> argInfo = new( argumentValue, name, message );
			_ = argInfo.As<string>();
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
