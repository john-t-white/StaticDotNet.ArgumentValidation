using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class ComparableExtensions_GreaterThanOrEqualTo_Struct {

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void ReturnsCorrectly( int value) {

		int comparisonValue = 2;

		ArgInfo<int> argInfo = new( value, null, null );

		ArgInfo<int> result = argInfo.GreaterThanOrEqualTo( comparisonValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int? value = null;
		int comparisionValue = 2;

		ArgInfo<int?> argInfo = new( value, null, null );

		ArgInfo<int?> result = argInfo.GreaterThanOrEqualTo( comparisionValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToThrowsArgumentOutOfRangeException() {

		int value = 1;
		string name = "Name";
		int comparisionValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, null );
			_ = argInfo.GreaterThanOrEqualTo( comparisionValue );
		} );

		string expectedMessage = $"Value must be greater than or equal to {comparisionValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToToAndMessageThrowsArgumentOutOfRangeException() {

		int value = 1;
		string name = "Name";
		string message = "Message";
		int comparisionValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, message );
			_ = argInfo.GreaterThanOrEqualTo( comparisionValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
