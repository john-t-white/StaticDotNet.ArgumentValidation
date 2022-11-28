using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_Between_Struct {

	[Theory]
	[InlineData( 1 )]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void WithValueBetweenMinValueAndMaxValueReturnsCorrectly(int value) {

		int minValue = 1;
		int maxValue = 3;

		int result = Arg.Is.Between( value, minValue, maxValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData(0)]
	[InlineData(4)]
	public void WithValueNotGreaterThanComparisonValueThrowsArgumentOutOfRangeException( int value ) {

		int minValue = 1;
		int maxValue = 3;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.Between( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotBetweenMinValueAndMaxValueAndNameThrowsArgumentOutOfRangeException() {

		int value = 0;
		int minValue = 1;
		int maxValue = 3;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.Between( value, minValue, maxValue, name ) );
	}

	[Fact]
	public void WithValueNotBetweenMinValueAndMaxValueAndMessageThrowsArgumentOutOfRangeException() {

		int value = 0;
		int minValue = 1;
		int maxValue = 3;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Arg.Is.Between( value, minValue, maxValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int value = 3;
		int minValue = 1;
		int maxValue = 3;
		IComparer<int> comparer = Comparer<int>.Default;

		int result = Arg.Is.Between( value, minValue, maxValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int value = 3;
		int minValue = 1;
		int maxValue = 3;
		IComparer<int> comparer = null!;

		int result = Arg.Is.Between( value, minValue, maxValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 1 )]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void WithNullableValueBetweenMinValueAndMaxValueReturnsCorrectly(int? value) {

		int minValue = 1;
		int maxValue = 3;

		int? result = Arg.Is.Between( value, minValue, maxValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 0 )]
	[InlineData( 4 )]
	public void WithNullableValueNotBetweenThrowsArgumentOutOfRangeException(int? value) {

		int minValue = 1;
		int maxValue = 3;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.Between( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		int? value = null;
		int minValue = 1;
		int maxValue = 3;

		int? result = Arg.Is.Between( value, minValue, maxValue );

		Assert.Null( result );
	}


	[Fact]
	public void WithNullableValueNotBetweenMinValueAndMaxValueAndNameThrowsArgumentOutOfRangeException() {

		int? value = 0;
		int minValue = 1;
		int maxValue = 3;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.Between( value, minValue, maxValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotBetterThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int? value = 0;
		int minValue = 1;
		int maxValue = 3;
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.Between( value, minValue, maxValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
