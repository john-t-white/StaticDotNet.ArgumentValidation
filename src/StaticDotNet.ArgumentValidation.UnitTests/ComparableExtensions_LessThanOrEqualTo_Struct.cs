using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class ComparableExtensions_LessThanOrEqualTo_Struct {

	[Theory]
	[InlineData( 1 )]
	[InlineData( 2 )]
	public void ReturnsCorrectly( int value) {

		int comparisonValue = 2;

		ArgInfo<int> argInfo = new( value, null, null );

		ArgInfo<int> result = argInfo.LessThanOrEqualTo( comparisonValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int? value = null;
		int comparisionValue = 2;

		ArgInfo<int?> argInfo = new( value, null, null );

		ArgInfo<int?> result = argInfo.LessThanOrEqualTo( comparisionValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToThrowsArgumentOutOfRangeException() {

		int value = 3;
		string name = "Name";
		int comparisionValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, null );
			_ = argInfo.LessThanOrEqualTo( comparisionValue );
		} );

		string expectedMessage = $"Value must be less than or equal to {comparisionValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToToAndMessageThrowsArgumentOutOfRangeException() {

		int value = 3;
		string name = "Name";
		string message = "Message";
		int comparisionValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, message );
			_ = argInfo.LessThanOrEqualTo( comparisionValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
