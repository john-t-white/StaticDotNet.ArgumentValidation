using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class Argument_Boolean_NotNullFalse {

	[Fact]
	public void WithNullableFalseValueReturnsCorrectly() {

		bool? value = false;

		bool? result = Argument.Is.NotNullFalse( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		bool? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullFalse( value ) );
	}

	[Fact]
	public void WithNullableTrueValueThrowsArgumentException() {

		bool? value = true;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullFalse( value ) );

		const string expectedMessage = "Value must be false.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableTrueValueAndNameThrowsArgumentException() {

		bool? value = true;
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotNullFalse( value, name ) );
	}

	[Fact]
	public void WithNullableTrueValueAndMessageThrowsArgumentException() {

		bool? value = true;
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullFalse( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
