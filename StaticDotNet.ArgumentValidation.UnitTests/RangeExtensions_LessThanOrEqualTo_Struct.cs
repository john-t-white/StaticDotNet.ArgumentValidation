using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_LessThanOrEqualTo_Struct {

	[Theory]
	[InlineData( 2 )]
	[InlineData( 1 )]
	public void WithValueLessThanOrEqualToComparisonValueReturnsCorrectly(int value) {

		int comparisonValue = 2;

		int result = Argument.Is.LessThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		int value = 3;
		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.LessThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int value = 3;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.LessThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int value = 3;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Argument.Is.LessThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 2;
		IComparer<int> comparer = Comparer<int>.Default;

		int result = Argument.Is.LessThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 2;
		IComparer<int> comparer = null!;

		int result = Argument.Is.LessThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 2 )]
	[InlineData( 1 )]
	public void WithNullableValueLessThanOrEqualToComparisonValueReturnsCorrectly(int? value) {

		int comparisonValue = 2;

		int? result = Argument.Is.LessThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueNotLessThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		int? value = 3;
		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.LessThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		int? value = null;
		int comparisonValue = 2;

		int? result = Argument.Is.LessThanOrEqualTo( value, comparisonValue );

		Assert.Null( result );
	}


	[Fact]
	public void WithNullableValueNotLessThanOrEqualComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int? value = 3;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.LessThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotLessThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int? value = 3;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.LessThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
