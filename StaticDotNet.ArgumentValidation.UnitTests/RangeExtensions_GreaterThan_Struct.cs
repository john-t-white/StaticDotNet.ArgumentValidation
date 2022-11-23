using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_GreaterThan_Struct {

	[Fact]
	public void WithValueGreaterThanComparisonValueReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;

		int result = Argument.Is.GreaterThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData(2)]
	[InlineData(1)]
	public void WithValueNotGreaterThanComparisonValueThrowsArgumentOutOfRangeException( int value ) {

		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		int value = 1;
		int? comparisonValue = null;

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int value = 2;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.GreaterThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotGreaterThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int value = 2;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Argument.Is.GreaterThan( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;
		IComparer<int> comparer = Comparer<int>.Default;

		int result = Argument.Is.GreaterThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;
		IComparer<int> comparer = null!;

		int result = Argument.Is.GreaterThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueGreaterThanComparisonValueReturnsCorrectly() {

		int? value = 3;
		int comparisonValue = 2;

		int? result = Argument.Is.GreaterThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 2 )]
	[InlineData( 1 )]
	public void WithNullableValueNotGreaterThanComparisonValueThrowsArgumentOutOfRangeException(int? value) {

		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int? comparisonValue = null;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		int? value = null;
		int comparisonValue = 2;

		int? result = Argument.Is.GreaterThan( value, comparisonValue );

		Assert.Null( result );
	}


	[Fact]
	public void WithNullableValueNotGreaterThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.GreaterThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int? value = 2;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThan( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
