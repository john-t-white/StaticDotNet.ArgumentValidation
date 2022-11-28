using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_NotNullGreaterThan_Class {

	[Fact]
	public void WithValueGreaterThanComparisonValueReturnsCorrectly() {

		string value = "c";
		string comparisonValue = "b";

		string result = Arg.Is.NotNullGreaterThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData("b")]
	[InlineData("a")]
	public void WithValueNotGreaterThanComparisonValueThrowsArgumentOutOfRangeException( string value) {

		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullGreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullGreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string value = null!;
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Arg.Is.NotNullGreaterThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotGreaterThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string value = "b";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.NotNullGreaterThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotGreaterThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string value = "b";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Arg.Is.NotNullGreaterThan( value, comparisonValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "c";
		string comparisonValue = "b";
		IComparer<string> comparer = Comparer<string>.Default;

		string result = Arg.Is.NotNullGreaterThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "c";
		string comparisonValue = "b";
		IComparer<string> comparer = null!;

		string result = Arg.Is.NotNullGreaterThan( value, comparisonValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableValueGreaterThanComparisonValueReturnsCorrectly() {

		string? value = "c";
		string comparisonValue = "b";

		string? result = Arg.Is.NotNullGreaterThan( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "b" )]
	[InlineData( "a" )]
	public void WithNullableValueNotGreaterThanComparisonValueThrowsArgumentOutOfRangeException(string? value) {

		string comparisonValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullGreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than {comparisonValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullComparisonValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullGreaterThan( value, comparisonValue ) );

		string expectedMessage = $"Value must be greater than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueThrowsArgumentNullException() {

		string? value = null;
		string comparisonValue = "b";

		_ = Assert.Throws<ArgumentNullException>( nameof(value), () => Arg.Is.NotNullGreaterThan( value, comparisonValue ) );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanComparisonValueAndNameThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.NotNullGreaterThan( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotGreaterThanComparisonValueAndMessageThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string comparisonValue = "b";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullGreaterThan( value, comparisonValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
