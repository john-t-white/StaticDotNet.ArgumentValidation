using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_NotNullGreaterThanOrEqualTo_Struct {

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void WithValueGreaterThanOrEqualToComparisonValueReturnsCorrectly(int value) {

		int comparisonValue = 2;

		int result = Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		int value = 1;
		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int value = 1;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int value = 1;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;
		IComparer<int> comparer = Comparer<int>.Default;

		int result = Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;
		IComparer<int> comparer = null!;

		int result = Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void WithNullableValueGreaterThanOrEqualToComparisonValueReturnsCorrectly(int? value) {

		int comparisonValue = 2;

		int? result = Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanComparisonValueThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int comparisonValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		int? value = null;
		int comparisonValue = 2;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue ) );
	}


	[Fact]
	public void WithNullableValueNotGreaterOrEqualToThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		int? value = 1;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
