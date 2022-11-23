using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class EqualityExtensions_NotNullEqualTo_Struct {

	[Fact]
	public void WithValueEqualToComparisonValueReturnsCorrectly() {

		int? value = 1;
		int comparisonValue = 1;

		int result = Argument.Is.NotNullEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 2;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		int? value = null;
		int comparisonValue = 1;

		_ = Assert.Throws<ArgumentNullException>( nameof(value), () => Argument.Is.NotNullEqualTo( value, comparisonValue ) );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueAndNameThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 2;
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Argument.Is.NotNullEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotEqualToComparisonValueAndMessageThrowsArgumentException() {

		int? value = 1;
		int comparisonValue = 2;
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof(value), () => Argument.Is.NotNullEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		int? value = 1;
		int comparisonValue = 1;
		IEqualityComparer<int> comparer = EqualityComparer<int>.Default;

		int result = Argument.Is.NotNullEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		int? value = 1;
		int comparisonValue = 1;
		IEqualityComparer<int> comparer = null!;

		int result = Argument.Is.NotNullEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}
}
