using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class EqualityExtensions_NotNullNotEqualTo_Struct {

	[Fact]
	public void WithValueNotEqualToComparisonValueReturnsCorrectly() {

		int? value = 1;
		int comparisonValue = 2;

		int result = Argument.Is.NotNullNotEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueEqualToComparisonValueThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullNotEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must not be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		int? value = null;
		int comparisonValue = 1;

		_ = Assert.Throws<ArgumentNullException>( nameof(value), () => Argument.Is.NotNullNotEqualTo( value, comparisonValue ) );
	}

	[Fact]
	public void WithValueEqualToComparisonValueAndNameThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 1;
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotNullNotEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueEqualToComparisonValueAndMessageThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 1;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof(value), () => Argument.Is.NotNullNotEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int? value = 1;
		int comparisonValue = 2;
		IEqualityComparer<int> comparer = EqualityComparer<int>.Default;

		int result = Argument.Is.NotNullNotEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int? value = 1;
		int comparisonValue = 2;
		IEqualityComparer<int> comparer = null!;

		int result = Argument.Is.NotNullNotEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}
}
