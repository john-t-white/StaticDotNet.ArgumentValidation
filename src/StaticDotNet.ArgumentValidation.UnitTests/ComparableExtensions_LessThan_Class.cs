using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class ComparableExtensions_LessThan_Class {

	[Fact]
	public void ReturnsCorrectly() {

		string value = "a";
		string comparisonValue = "b";

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = argInfo.LessThan( comparisonValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		string? value = null;
		string comparisionValue = "b";

		ArgInfo<string?> argInfo = new( value, null, null );

		ArgInfo<string?> result = argInfo.LessThan( comparisionValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	public void WithValueNotLessThanThrowsArgumentOutOfRangeException( string value ) {

		string name = "Name";
		string comparisionValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.LessThan( comparisionValue );
		} );

		string expectedMessage = $"Value must be less than {comparisionValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string name = "Name";
		string comparisionValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.LessThan( comparisionValue );
		} );

		string expectedMessage = $"Value must be less than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotLessThanAndMessageThrowsArgumentOutOfRangeException() {

		string value = "c";
		string name = "Name";
		string message = "Message";
		string comparisionValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.LessThan( comparisionValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
