using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EquatableExtensions_EqualTo_Struct {

	[Fact]
	public void ReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 1;

		ArgInfo<int> argInfo = new( value, null, null );

		ArgInfo<int> result = argInfo.EqualTo( comparisonValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEqualityComparerReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 1;
		IEqualityComparer<int> comparer = EqualityComparer<int>.Default;

		ArgInfo<int> argInfo = new( value, null, null );

		ArgInfo<int> result = argInfo.EqualTo( comparisonValue, comparer );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int? value = null;
		int comparisionValue = 1;

		ArgInfo<int?> argInfo = new( value, null, null );

		ArgInfo<int?> result = argInfo.EqualTo( comparisionValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToThrowsArgumentException() {

		int value = 2;
		string name = "Name";
		int comparisionValue = 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, null );
			_ = argInfo.EqualTo( comparisionValue );
		} );

		string expectedMessage = $"Value must be equal to {comparisionValue}";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotEqualToAndMessageThrowsArgumentException() {

		int value = 2;
		string name = "Name";
		string message = "Message";
		int comparisionValue = 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, message );
			_ = argInfo.EqualTo( comparisionValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
