using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_NotNullLessThanOrEqualTo_Class {

	[Theory]
	[InlineData( "b" )]
	[InlineData( "a" )]
	public void WithValueLessThanOrEqualToComparisonValueReturnsCorrectly( string value ) {

		string comparisonValue = "b";

		string result = Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "c";
		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string value = null!;
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string value = "c";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string value = "c";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "a";
		string comparisonValue = "b";
		IComparer<string> comparer = Comparer<string>.Default;

		string result = Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "a";
		string comparisonValue = "b";
		IComparer<string> comparer = null!;

		string result = Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "b" )]
	[InlineData( "a" )]
	public void WithNullableValueLessThanOrEqualToComparisonValueReturnsCorrectly(string? value) {

		string comparisonValue = "b";

		string? result = Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueNotLessThanOrEqualToComparisonValueThrowsArgumentOutOfRangeException() {
		string? value = "c";
		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than or equal to {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueThrowsArgumentNullException() {

		string? value = null;
		string comparisonValue = "b";

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue ) );
	}

	[Fact]
	public void WithNullableValueNotLessThanOrEqualToComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string? value = "c";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotLessThanOrEqualToComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string? value = "c";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.NotNullLessThanOrEqualTo( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
