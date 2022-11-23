using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_NotNullGreaterThanOrEqualTo_Class {

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	public void WithValueGreaterThanOrEqualToComparisonValueReturnsCorrectly( string value ) {

		string comparisonValue = "b";

		string result = Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string value = null!;
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "c";
		string comparisonValue = "b";
		IComparer<string> comparer = Comparer<string>.Default;

		string result = Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "c";
		string comparisonValue = "b";
		IComparer<string> comparer = null!;

		string result = Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	public void WithNullableValueGreaterThanOrEqualToComparisonValueReturnsCorrectly(string? value) {

		string comparisonValue = "b";

		string? result = Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {
		string? value = "a";
		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueThrowsArgumentNullException() {

		string? value = null;
		string comparisonValue = "b";

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue ) );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string? value = "a";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string? value = "a";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullGreaterThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
