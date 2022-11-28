using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class EqualityExtensions_NotNullEqualTo_Class {

	[Fact]
	public void WithValueEqualToComparisonValueReturnsCorrectly() {

		string? value = "Value";
		string comparisonValue = "Value";

		string result = Arg.Is.NotNullEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Not Value";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string? value = null;
		string comparisonValue = "Value";

		_ = Assert.Throws<ArgumentNullException>( nameof(value), () => Arg.Is.NotNullEqualTo( value, comparisonValue ) );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueAndNameThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Not Value";
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.NotNullEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueAndMessageThrowsArgumentException() {

		string? value = "Value";
		string comparisonValue = "Not Value";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof(value), () => Arg.Is.NotNullEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string? value = "Value";
		string comparisonValue = "Value";
		IEqualityComparer<string> comparer = EqualityComparer<string>.Default;

		string result = Arg.Is.NotNullEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string? value = "Value";
		string comparisonValue = "Value";
		IEqualityComparer<string> comparer = null!;

		string result = Arg.Is.NotNullEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}
}
