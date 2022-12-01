using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class ArgInfo_ctor {

	[Fact]
	public void InitializesCorrectly() {

		object value = new();
		string name = "Name";
		string message = "Message";

		ArgInfo<object> result = new( value, name, message );

		Assert.Same( value, result.Value );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}
}
