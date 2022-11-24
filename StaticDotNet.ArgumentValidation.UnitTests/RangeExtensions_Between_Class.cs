using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class RangeExtensions_Between_Class {

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	[InlineData( "d" )]
	public void WithValueBeetweenMinValueAndMaxValueReturnsCorrectly(string value) {

		string minValue = "b";
		string maxValue = "d";

		string result = Argument.Is.Between( value, minValue, maxValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "a" )]
	[InlineData( "e" )]
	public void WithValueNotBetweenMinValueAndMaxValueThrowsArgumentOutOfRangeException(string value) {

		string minValue = "b";
		string maxValue = "d";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.Between( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullMinValueThrowsArgumentOutOfRangeException() {

		string value = "c";
		string minValue = null!;
		string maxValue = "d";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.Between( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between <null> and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullMaxValueThrowsArgumentOutOfRangeException() {

		string value = "c";
		string minValue = "a";
		string maxValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.Between( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotBeweenMinValueAndMaxValueAndNameThrowsArgumentOutOfRangeException() {

		string value = "a";
		string minValue = "b";
		string maxValue = "d";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.Between( value, minValue, maxValue, name ) );
	}

	[Fact]
	public void WithValueNotBetweenMinValueAndMaxValueAndMessageThrowsArgumentOutOfRangeException() {

		string value = "a";
		string minValue = "b";
		string maxValue = "d";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof(value), () => Argument.Is.Between( value, minValue, maxValue, message: message ) );

		Assert.StartsWith(message, exception.Message );
	}

	[Fact]
	public void WithValueAndComparerReturnsCorrectly() {

		string value = "b";
		string minValue = "b";
		string maxValue = "d";
		IComparer<string> comparer = Comparer<string>.Default;

		string result = Argument.Is.Between( value, minValue, maxValue, comparer );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueAndNullComparerReturnsCorrectly() {

		string value = "b";
		string minValue = "b";
		string maxValue = "d";
		IComparer<string> comparer = null!;

		string result = Argument.Is.Between( value, minValue, maxValue, comparer );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	[InlineData( "d" )]
	public void WithNullableValueBetweenMinValueAndMaxValueReturnsCorrectly(string? value) {

		string minValue = "b";
		string maxValue = "d";

		string? result = Argument.Is.Between( value, minValue, maxValue );

		Assert.Equal( value, result );
	}

	[Theory]
	[InlineData( "a" )]
	[InlineData( "e" )]
	public void WithNullableValueNotBetweenMinValueAndMaxValueThrowsArgumentOutOfRangeException(string? value) {

		string minValue = "b";
		string maxValue = "d";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.Between( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullMinValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string minValue = null!;
		string maxValue = "d";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.Between( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between <null> and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableValueAndNullMaxValueThrowsArgumentOutOfRangeException() {

		string? value = "b";
		string minValue = "a";
		string maxValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.Between( value, minValue, maxValue ) );

		string expectedMessage = $"Value must be between {minValue} and <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullableNullValueReturnsCorrectly() {

		string? value = null;
		string minValue = "b";
		string maxValue = "d";

		string? result = Argument.Is.Between( value, minValue, maxValue );

		Assert.Null( result );
	}

	[Fact]
	public void WithNullableValueNotBetweenMinValueAndMaxValueAndNameThrowsArgumentOutOfRangeException() {

		string? value = "a";
		string minValue = "b";
		string maxValue = "d";
		string name = "Name";

		_ = Assert.Throws<ArgumentOutOfRangeException>( name, () => Argument.Is.Between( value, minValue, maxValue, name ) );
	}

	[Fact]
	public void WithNullableValueNotBetweenMinValueAndMaxValueAndMessageThrowsArgumentOutOfRangeException() {

		string? value = "a";
		string minValue = "b";
		string maxValue = "d";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( nameof( value ), () => Argument.Is.Between( value, minValue, maxValue, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
