using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class StringExtensions_LengthBetween {

	[Theory]
	[InlineData("12")]
	[InlineData("123")]
	[InlineData("1234")]
	public void ReturnsCorrectly( string value) {

		ArgInfo<string> argInfo = new( value, null, null );
		int minLength = 2;
		int maxLength = 4;

		ArgInfo<string> result = StringExtensions.LengthBetween( argInfo, minLength, maxLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<string?> argInfo = new( null, null, null );
		int minLength = 2;
		int maxLength = 4;

		ArgInfo<string?> result = StringExtensions.LengthBetween( argInfo, minLength, maxLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "1" )]
	[InlineData( "12345" )]
	public void WithValueLengthNotBetweenThrowsArgumentOutOfRangeException( string value) {

		string name = "Name";
		int minLength = 2;
		int maxLength = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = StringExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		string expectedMessage = $"Value must have a length between {minLength} and {maxLength}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string name = "Name";
		string value = "1";
		string message = "Message";
		int minLength = 2;
		int maxLength = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = StringExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
