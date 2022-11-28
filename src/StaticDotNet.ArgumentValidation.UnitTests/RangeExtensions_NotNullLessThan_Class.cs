using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_NotNullLessThan_Class {

	[Fact]
	public void WithValueLessThanComparisonValueReturnsCorrectly() {

		string value = "a";
		string comparisonValue = "b";

		string result = Arg.Is.NotNullLessThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData("b")]
	[InlineData("c")]
	public void WithValueNotLessThanComparisonValueThrowsArgumentOutOfRangeException( string value) {

		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullLessThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullLessThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string value = null!;
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Arg.Is.NotNullLessThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotLessThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string value = "b";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.NotNullLessThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotLessThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string value = "b";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Arg.Is.NotNullLessThan( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "a";
		string comparisonValue = "b";
		IComparer<string> comparer = Comparer<string>.Default;

		string result = Arg.Is.NotNullLessThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "a";
		string comparisonValue = "b";
		IComparer<string> comparer = null!;

		string result = Arg.Is.NotNullLessThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueLessThanComparisonValueReturnsCorrectly() {

		string? value = "a";
		string comparisonValue = "b";

		string? result = Arg.Is.NotNullLessThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	public void WithNullableValueNotLessThanComparisonValueThrowsArgumentOutOfRangeException(string? value) {

		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullLessThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullLessThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be less than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueThrowsArgumentNullException() {

		string? value = null;
		string comparisonValue = "b";

		_ = Assert.Throws<ArgumentNullException>( nameof(value), () => Arg.Is.NotNullLessThan( value, comparisonValue ) );
	}

	[Fact]
	public void WithNullableValueNotLessThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.NotNullLessThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotLessThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullLessThan( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
