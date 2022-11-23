using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_GreaterThan_Class {

	[Fact]
	public void WithValueGreaterThanComparisonValueReturnsCorrectly() {

		string value = "c";
		string comparisonValue = "b";

		string result = Argument.Is.GreaterThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData("b")]
	[InlineData("a")]
	public void WithValueNotGreaterThanComparisonValueThrowsArgumentOutOfRangeException( string value) {

		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string value = "b";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.GreaterThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotGreaterThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string value = "b";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Argument.Is.GreaterThan( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "c";
		string comparisonValue = "b";
		IComparer<string> comparer = Comparer<string>.Default;

		string result = Argument.Is.GreaterThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "c";
		string comparisonValue = "b";
		IComparer<string> comparer = null!;

		string result = Argument.Is.GreaterThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueGreaterThanComparisonValueReturnsCorrectly() {

		string? value = "c";
		string comparisonValue = "b";

		string? result = Argument.Is.GreaterThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "b" )]
	[InlineData( "a" )]
	public void WithNullableValueNotGreaterThanComparisonValueThrowsArgumentOutOfRangeException(string? value) {

		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		string? value = null;
		string comparisonValue = "b";

		string? result = Argument.Is.GreaterThan( value, comparisonValue );

		Assert.Null( result );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.GreaterThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.GreaterThan( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
