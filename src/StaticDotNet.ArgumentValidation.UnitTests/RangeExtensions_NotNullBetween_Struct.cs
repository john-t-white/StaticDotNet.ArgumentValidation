using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_NotNullBetween_Struct {

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	[InlineData( 4 )]
	public void WithValueLessThanComparisonValueReturnsCorrectly( int value ) {

		int minValue = 2;
		int maxValue = 4;

		int result = Arg.Is.NotNullBetween( value, minValue, maxValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 1 )]
	[InlineData( 5 )]
	public void WithValueNotBetweenMinValueAndMaxValueThrowsArgumentOutOfRangeException( int value ) {

		int minValue = 2;
		int maxValue = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotBetweenMinValueAndMaxValueAndNameThrowsArgumentOutOfRangeException() {

		int value = 1;
		int minValue = 2;
		int maxValue = 4;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.NotNullBetween( value, minValue, maxValue, name ) );
	}

	[Fact]
	public void WithValueNotBetweenMinValueAndMaxValueAndMessageThrowsArgumentOutOfRangeException() {

		int value = 1;
		int minValue = 2;
		int maxValue = 4;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int value = 2;
		int minValue = 2;
		int maxValue = 4;
		IComparer<int> comparer = Comparer<int>.Default;

		int result = Arg.Is.NotNullBetween( value, minValue, maxValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int value = 2;
		int minValue = 2;
		int maxValue = 4;
		IComparer<int> comparer = null!;

		int result = Arg.Is.NotNullBetween( value, minValue, maxValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	[InlineData( 4 )]
	public void WithNullableValueBetweenMinValueAndMaxValueReturnsCorrectly( int? value ) {

		int minValue = 2;
		int maxValue = 4;

		int? result = Arg.Is.NotNullBetween( value, minValue, maxValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 1 )]
	[InlineData( 5 )]
	public void WithNullableValueNotBetweenMinValueAndMaxValueThrowsArgumentOutOfRangeException( int? value ) {

		int minValue = 2;
		int maxValue = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueThrowsArgumentNullException() {

		int? value = null;
		int minValue = 2;
		int maxValue = 4;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue ) );
	}

	[Fact]
	public void WithNullableValueNotBetweenMinValueAndMaxValueAndNameThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int minValue = 2;
		int maxValue = 4;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.NotNullBetween( value, minValue, maxValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotBetweenMinValueAndMaxValueAndMessageThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int minValue = 2;
		int maxValue = 4;
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
