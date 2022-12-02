using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EnumerableExtensions_NotEmpty_String {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string> argInfo = new( "Value", null, null );

		ArgInfo<string> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithWhiteSpaceValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( " ", null, null );

		ArgInfo<string?> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		string value = string.Empty;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string value = string.Empty;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
