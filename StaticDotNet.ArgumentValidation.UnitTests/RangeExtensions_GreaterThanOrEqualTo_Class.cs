using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_GreaterThanOrEqualTo_Class {

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	public void WithValueGreaterThanOrEqualToComparisonValueReturnsCorrectly(string value) {

		string comparisonValue = "b";

		string result = Argument.Is.GreaterThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotGreaterThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "b";
		string comparisonValue = "b";
		IComparer<string> comparer = Comparer<string>.Default;

		string result = Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "b";
		string comparisonValue = "b";
		IComparer<string> comparer = null!;

		string result = Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	public void WithNullableValueGreaterThanOrEqualToComparisonValueReturnsCorrectly(string? value) {

		string comparisonValue = "b";

		string? result = Argument.Is.GreaterThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		string? value = "a";
		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		string? value = null;
		string comparisonValue = "b";

		string? result = Argument.Is.GreaterThanOrEqualTo( value, comparisonValue );

		Assert.Null( result );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string? value = "a";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string? value = "a";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
