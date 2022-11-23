using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class EqualityExtensions_EqualTo_Struct {

	[Fact]
	public void WithValueEqualToComparisonValueReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 1;

		int result = Argument.Is.EqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotToComparisonValueThrowsArgumentException() {

		int value = 1;
		int comparisonValue = 2;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.EqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotToComparisonValueAndNameThrowsArgumentException() {

		int value = 1;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.EqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotToComparisonValueAndMessageThrowsArgumentException() {

		int value = 1;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof(value), () => Argument.Is.EqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 1;
		IEqualityComparer<int> comparer = EqualityComparer<int>.Default;

		int result = Argument.Is.EqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 1;
		IEqualityComparer<int> comparer = null!;

		int result = Argument.Is.EqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueToComparisonValueReturnsCorrectly() {

		int? value = 1;
		int comparisonValue = 1;

		int? result = Argument.Is.EqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueNotToComparisonValueThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 2;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.EqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		int? value = null;
		int comparisonValue = 1;

		int? result = Argument.Is.EqualTo( value, comparisonValue );

		Assert.Null( result );
	}

	[Fact]
	public void WithNullableValueNotToComparisonValueAndNameThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.EqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotToComparisonValueAndMessageThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.EqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
