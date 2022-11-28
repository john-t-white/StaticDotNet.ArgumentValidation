using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_NotNullGreaterThan_Struct {

	[Fact]
	public void WithValueGreaterThanComparisonValueReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;

		int result = Arg.Is.NotNullGreaterThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData(2)]
	[InlineData(1)]
	public void WithValueNotGreaterThanComparisonValueThrowsArgumentOutOfRangeException( int value ) {

		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullGreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int value = 2;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.NotNullGreaterThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotGreaterThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int value = 2;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Arg.Is.NotNullGreaterThan( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;
		IComparer<int> comparer = Comparer<int>.Default;

		int result = Arg.Is.NotNullGreaterThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;
		IComparer<int> comparer = null!;

		int result = Arg.Is.NotNullGreaterThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueGreaterThanComparisonValueReturnsCorrectly() {

		int? value = 3;
		int comparisonValue = 2;

		int? result = Arg.Is.NotNullGreaterThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 2 )]
	[InlineData( 1 )]
	public void WithNullableValueNotGreaterThanComparisonValueThrowsArgumentOutOfRangeException(int? value) {

		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullGreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		int? value = null;
		int comparisonValue = 2;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullGreaterThan( value, comparisonValue ) );
	}


	[Fact]
	public void WithNullableValueNotGreaterThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.NotNullGreaterThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int? value = 2;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullGreaterThan( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
