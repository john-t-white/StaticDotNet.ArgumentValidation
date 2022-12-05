using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class ComparableExtensions_GreaterThanOrEqualTo_Class {

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	public void ReturnsCorrectly( string value ) {

		string comparisonValue = "b";

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = argInfo.GreaterThanOrEqualTo( comparisonValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		string? value = null;
		string comparisionValue = "b";

		ArgInfo<string?> argInfo = new( value, null, null );

		ArgInfo<string?> result = argInfo.GreaterThanOrEqualTo( comparisionValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToThrowsArgumentOutOfRangeException() {

		string value = "a";
		string name = "Name";
		string comparisionValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.GreaterThanOrEqualTo( comparisionValue );
		} );

		string expectedMessage = $"Value must be greater than or equal to {comparisionValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string name = "Name";
		string comparisionValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.GreaterThanOrEqualTo( comparisionValue );
		} );

		string expectedMessage = $"Value must be greater than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToAndMessageThrowsArgumentOutOfRangeException() {

		string value = "a";
		string name = "Name";
		string message = "Message";
		string comparisionValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.GreaterThanOrEqualTo( comparisionValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
