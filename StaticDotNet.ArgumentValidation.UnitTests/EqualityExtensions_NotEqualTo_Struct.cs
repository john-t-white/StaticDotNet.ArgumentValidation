using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class EqualityExtensions_NotEqualTo_Struct {

	[Fact]
	public void WithValueNotEqualToComparisonValueReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 2;

		int result = Argument.Is.NotEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueEqualToComparisonValueThrowsArgumentException() {

		int value = 1;
		int comparisonValue = 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must not be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueEqualToComparisonValueAndNameThrowsArgumentException() {

		int value = 1;
		int comparisonValue = 1;
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueEqualToComparisonValueAndMessageThrowsArgumentException() {

		int value = 1;
		int comparisonValue = 1;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof(value), () => Argument.Is.NotEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 2;
		IEqualityComparer<int> comparer = EqualityComparer<int>.Default;

		int result = Argument.Is.NotEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 2;
		IEqualityComparer<int> comparer = null!;

		int result = Argument.Is.NotEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueEqualToComparisonValueReturnsCorrectly() {

		int? value = 1;
		int comparisonValue = 2;

		int? result = Argument.Is.NotEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueEqualToComparisonValueThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must not be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentException() {

		int? value = 1;
		int? comparisonValue = null;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must not be equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		int? value = null;
		int comparisonValue = 1;

		int? result = Argument.Is.NotEqualTo( value, comparisonValue );

		Assert.Null( result );
	}

	[Fact]
	public void WithNullableValueEqualToComparisonValueAndNameThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 1;
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueEqualToComparisonValueAndMessageThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 1;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
