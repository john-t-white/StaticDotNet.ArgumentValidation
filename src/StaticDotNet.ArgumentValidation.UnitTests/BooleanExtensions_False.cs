using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class BooleanExtensions_False {

	[Fact]
	public void WithFalseValueReturnsCorrectly() {

		bool value = false;

		bool result = Arg.Is.False( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithTrueValueThrowsArgumentException() {

		bool value = true;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.False( value ) );

		const string expectedMessage = "Value must be false.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithTrueValueAndNameThrowsArgumentException() {

		bool value = true;
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.False( value, name ) );
	}

	[Fact]
	public void WithTrueValueAndMessageThrowsArgumentException() {

		bool value = true;
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.False( value, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithNullableFalseValueReturnsCorrectly() {

		bool? value = false;

		bool? result = Arg.Is.False( value );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		bool? value = null;

		bool? result = Arg.Is.False( value );

		Assert.Null( result );
	}

	[Fact]
	public void WithNullableTrueValueThrowsArgumentException() {

		bool? value = true;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.False( value ) );

		const string expectedMessage = "Value must be false.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableTrueValueAndNameThrowsArgumentException() {

		bool? value = true;
		const string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.False( value, name ) );
	}

	[Fact]
	public void WithNullableTrueValueAndMessageThrowsArgumentException() {

		bool? value = true;
		const string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.False( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
