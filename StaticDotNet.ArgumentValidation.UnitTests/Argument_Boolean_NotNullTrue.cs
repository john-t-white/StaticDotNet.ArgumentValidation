using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class Argument_Boolean_NotNullTrue {

	[Fact]
	public void WithTrueValueReturnsCorrectly() {

		bool? value = true;

		bool? result = Argument.Is.NotNullTrue( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		bool? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullTrue( value ) );
	}

	[Fact]
	public void WithNullableFalseValueThrowsArgumentException() {

		bool? value = false;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullTrue( value ) );

		const string expectedMessage = "Value must be true.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableFalseValueAndNameThrowsArgumentException() {

		bool? value = false;
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotNullTrue( value, name ) );
	}

	[Fact]
	public void WithNullableFalseValueAndMessageThrowsArgumentException() {

		bool? value = false;
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullTrue( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
