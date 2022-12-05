using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EquatableExtensions_EqualTo_Object {

	[Fact]
	public void ReturnsCorrectly() {

		object value = new();
		object comparisonValue = value;

		ArgInfo<object> argInfo = new( value, null, null );

		ArgInfo<object> result = argInfo.EqualTo( comparisonValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEqualityComparerReturnsCorrectly() {

		object value = new();
		object comparisonValue = value;
		IEqualityComparer<object> comparer = EqualityComparer<object>.Default;

		ArgInfo<object> argInfo = new( value, null, null );

		ArgInfo<object> result = argInfo.EqualTo( comparisonValue, comparer );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		object? value = null;
		object comparisionValue = new();

		ArgInfo<object?> argInfo = new( value, null, null );

		ArgInfo<object?> result = argInfo.EqualTo( comparisionValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToThrowsArgumentException() {

		object value = new();
		string name = "Name";
		object comparisionValue = new();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<object> argInfo = new( value, name, null );
			_ = argInfo.EqualTo( comparisionValue );
		} );

		string expectedMessage = $"Value must be equal to {comparisionValue}";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotEqualToAndMessageThrowsArgumentException() {

		object value = new();
		string name = "Name";
		string message = "Message";
		object comparisionValue = new();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<object> argInfo = new( value, name, message );
			_ = argInfo.EqualTo( comparisionValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
