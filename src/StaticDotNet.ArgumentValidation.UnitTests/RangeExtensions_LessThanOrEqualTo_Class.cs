using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_LesshanOrEqualTo_Class {

	[Theory]
	[InlineData( "b" )]
	[InlineData( "a" )]
	public void WithValueLessThanOrEqualToComparisonValueReturnsCorrectly(string value) {

		string comparisonValue = "b";

		string result = Arg.Is.LessThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "c";
		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.LessThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.LessThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string value = "c";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.LessThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotLessThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string value = "c";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Arg.Is.LessThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "b";
		string comparisonValue = "b";
		IComparer<string> comparer = Comparer<string>.Default;

		string result = Arg.Is.LessThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "b";
		string comparisonValue = "b";
		IComparer<string> comparer = null!;

		string result = Arg.Is.LessThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "b" )]
	[InlineData( "a" )]
	public void WithNullableValueLessThanOrEqualToComparisonValueReturnsCorrectly(string? value) {

		string comparisonValue = "b";

		string? result = Arg.Is.LessThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueNotLessThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		string? value = "c";
		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.LessThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.LessThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		string? value = null;
		string comparisonValue = "b";

		string? result = Arg.Is.LessThanOrEqualTo( value, comparisonValue );

		Assert.Null( result );
	}

	[Fact]
	public void WithNullableValueNotLessThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string? value = "c";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.LessThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotLessThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string? value = "c";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.LessThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
