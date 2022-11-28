using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_NotNullBetween_Class {

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	[InlineData( "d" )]
	public void WithValueBetweenMinValueAndMaxValueReturnsCorrectly( string value ) {

		string minValue = "b";
		string maxValue = "d";

		string result = Arg.Is.NotNullBetween( value, minValue, maxValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "a" )]
	[InlineData( "e" )]
	public void WithValueNotBetweenMinValueAndMaxValueThrowsArgumentOutOfRangeException( string value ) {

		string minValue = "b";
		string maxValue = "d";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullMinValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string minValue = null!;
		string maxValue = "b";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between <null> and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullMaxValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string minValue = "b";
		string maxValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string value = null!;
		string comparisonValue = "b";
		string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( nameof(value), () => Arg.Is.NotNullBetween( value, comparisonValue, name ) );
	}

	[Fact]
	public void WithValueNotBetweenMinValueAndMaxValueAndNameThrowsArgumentOutOfRangeException() {

		string value = "a";
		string minValue = "b";
		string maxValue = "d";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.NotNullBetween( value, minValue, maxValue, name ) );
	}

	[Fact]
	public void WithValueNotBetweenMinValueAndMaxValueAndMessageThrowsArgumentOutOfRangeException() {

		string value = "a";
		string minValue = "b";
		string maxValue = "d";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "b";
		string minValue = "b";
		string maxValue = "d";
		IComparer<string> comparer = Comparer<string>.Default;

		string result = Arg.Is.NotNullBetween( value, minValue, maxValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "b";
		string minValue = "b";
		string maxValue = "d";
		IComparer<string> comparer = null!;

		string result = Arg.Is.NotNullBetween( value, minValue, maxValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	[InlineData( "d" )]
	public void WithNullableValueBetweenMinValueAndMaxValueReturnsCorrectly(string? value) {

		string minValue = "b";
		string maxValue = "d";

		string? result = Arg.Is.NotNullBetween( value, minValue, maxValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "a" )]
	[InlineData( "e" )]
	public void WithNullableValueNoBetweenMinValueAndMaxValueThrowsArgumentOutOfRangeException( string? value ) {

		string minValue = "b";
		string maxValue = "d";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullMinValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string minValue = null!;
		string maxValue = "d";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between <null> and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullMaxValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string minValue = "b";
		string maxValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueThrowsArgumentNullException() {

		string? value = null;
		string minValue = "b";
		string maxValue = "d";

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue ) );
	}

	[Fact]
	public void WithNullableValueNotBetweenMinValueAndMaxValueAndNameThrowsArgumentOutOfRangeException() {

		string? value = "a";
		string minValue = "b";
		string maxValue = "d";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Arg.Is.NotNullBetween( value, minValue, maxValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotBetweenMinValueAndMaxValueAndMessageThrowsArgumentOutOfRangeException() {

		string? value = "a";
		string minValue = "b";
		string maxValue = "d";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Arg.Is.NotNullBetween( value, minValue, maxValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
