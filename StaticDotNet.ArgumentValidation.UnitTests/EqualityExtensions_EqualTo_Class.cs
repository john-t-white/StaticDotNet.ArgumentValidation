using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class EqualityExtensions_EqualTo_Class {

	[Fact]
	public void WithValueEqualToComparisonValueReturnsCorrectly() {

		string value = "Value";
		string comparisonValue = "Value";

		string result = Argument.Is.EqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueThrowsArgumentException() {

		string value = "Value";
		string comparisonValue = "Not Value";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.EqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueAndNameThrowsArgumentException() {

		string value = "Value";
		string comparisonValue = "Not Value";
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.EqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueAndMessageThrowsArgumentException() {

		string value = "Value";
		string comparisonValue = "Not Value";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof(value), () => Argument.Is.EqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "Value";
		string comparisonValue = "Value";
		IEqualityComparer<string> comparer = EqualityComparer<string>.Default;

		string result = Argument.Is.EqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "Value";
		string comparisonValue = "Value";
		IEqualityComparer<string> comparer = null!;

		string result = Argument.Is.EqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueEqualToComparisonValueReturnsCorrectly() {

		string? value = "Value";
		string comparisonValue = "Value";

		string? result = Argument.Is.EqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueNotEqualToComparisonValueThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Not Value";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.EqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		string? value = null;
		string comparisonValue = "Value";

		string? result = Argument.Is.EqualTo( value, comparisonValue );

		Assert.Null( result );
	}

	[Fact]
	public void WithNullableValueNotEqualToComparisonValueAndNameThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Not Value";
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.EqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotEqualToComparisonValueAndMessageThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Not Value";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.EqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
