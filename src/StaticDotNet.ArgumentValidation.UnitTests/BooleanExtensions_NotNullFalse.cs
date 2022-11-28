using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class BooleanExtensions_NotNullFalse {

	[Fact]
	public void WithNullableFalseValueReturnsCorrectly() {

		bool? value = false;

		bool? result = Arg.Is.NotNullFalse( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		bool? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullFalse( value ) );
	}

	[Fact]
	public void WithNullableTrueValueThrowsArgumentException() {

		bool? value = true;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullFalse( value ) );

		const string expectedMessage = "Value must be false.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableTrueValueAndNameThrowsArgumentException() {

		bool? value = true;
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.NotNullFalse( value, name ) );
	}

	[Fact]
	public void WithNullableTrueValueAndMessageThrowsArgumentException() {

		bool? value = true;
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullFalse( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
