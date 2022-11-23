using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class EqualityExtensions_NotNullNotEqualTo_Class {

	[Fact]
	public void WithValueNotEqualToComparisonValueReturnsCorrectly() {

		string? value = "Value";
		string comparisonValue = "Not Value";

		string result = Argument.Is.NotNullNotEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueEqualToComparisonValueThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Value";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullNotEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must not be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string? value = null;
		string comparisonValue = "Value";

		_ = Assert.Throws<ArgumentNullException>( nameof(value), () => Argument.Is.NotNullNotEqualTo( value, comparisonValue ) );
	}
	[Fact]
	public void WithValueEqualToComparisonValueAndNameThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Value";
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotNullNotEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueEqualToComparisonValueAndMessageThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Value";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof(value), () => Argument.Is.NotNullNotEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string? value = "Value";
		string comparisonValue = "Not Value";
		IEqualityComparer<string> comparer = EqualityComparer<string>.Default;

		string result = Argument.Is.NotNullNotEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string? value = "Value";
		string comparisonValue = "Not Value";
		IEqualityComparer<string> comparer = null!;

		string result = Argument.Is.NotNullNotEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}
}
