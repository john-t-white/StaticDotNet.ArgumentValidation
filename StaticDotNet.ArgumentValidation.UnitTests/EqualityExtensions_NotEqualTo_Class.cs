using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class EqualityExtensions_NotEqualTo_Class {

	[Fact]
	public void WithValueNotEqualToComparisonValueReturnsCorrectly() {

		string value = "Value";
		string comparisonValue = "Not Value";

		string result = Argument.Is.NotEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueEqualToComparisonValueThrowsArgumentException() {

		string value = "Value";
		string comparisonValue = "Value";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must not be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueEqualToComparisonValueAndNameThrowsArgumentException() {

		string value = "Value";
		string comparisonValue = "Value";
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueEqualToComparisonValueAndMessageThrowsArgumentException() {

		string value = "Value";
		string comparisonValue = "Value";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof(value), () => Argument.Is.NotEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "Value";
		string comparisonValue = "Not Value";
		IEqualityComparer<string> comparer = EqualityComparer<string>.Default;

		string result = Argument.Is.NotEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "Value";
		string comparisonValue = "Not Value";
		IEqualityComparer<string> comparer = null!;

		string result = Argument.Is.NotEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueNotEqualToComparisonValueReturnsCorrectly() {

		string? value = "Value";
		string comparisonValue = "Not Value";

		string? result = Argument.Is.NotEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueEqualToComparisonValueThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Value";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must not be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		string? value = null;
		string comparisonValue = "Value";

		string? result = Argument.Is.NotEqualTo( value, comparisonValue );

		Assert.Null( result );
	}

	[Fact]
	public void WithNullableValueEqualToComparisonValueAndNameThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Value";
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueEqualToComparisonValueAndMessageThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Value";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
