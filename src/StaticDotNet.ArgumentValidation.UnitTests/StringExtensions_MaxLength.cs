using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StringExtensions_MaxLength {

	[Theory]
	[InlineData(5)]
	[InlineData(6)]
	public void ReturnsCorrectly( int maxLength) {

		ArgInfo<string> argInfo = new( "Value", null, null );

		ArgInfo<string> result = StringExtensions.MaxLength( argInfo, maxLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );

		ArgInfo<string?> result = StringExtensions.MaxLength( argInfo, 0 );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		int maxLength = value.Length - 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = StringExtensions.MaxLength( argInfo, maxLength );
		} );

		string expectedMessage = $"Value cannot have a length greater than {maxLength}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		string value = "Value";
		string message = "Message";
		int maxLength = value.Length - 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = StringExtensions.MaxLength( argInfo, maxLength );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
