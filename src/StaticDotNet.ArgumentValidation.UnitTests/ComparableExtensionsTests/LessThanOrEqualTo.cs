﻿namespace StaticDotNet.ArgumentValidation.UnitTests.ComparableExtensionsTests;

public sealed class LessThanOrEqualTo {

	[Theory]
	[InlineData( 1 )]
	[InlineData( 2 )]
	public void ReturnsCorrectly( int argumentValue ) {

		int value = 2;

		ArgInfo<int> argInfo = new( argumentValue, null, null );

		ArgInfo<int> result = argInfo.LessThanOrEqualTo( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToThrowsArgumentOutOfRangeException() {

		int argumentValue = 3;
		string name = "Name";
		int value = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, null );
			_ = argInfo.LessThanOrEqualTo( value );
		} );

		string expectedMessage = $"Value {argumentValue} must be less than or equal to {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithStringNotLessThanOrEqualToThrowsArgumentOutOfRangeException() {

		string argumentValue = "3";
		string name = "Name";
		string value = "2";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.LessThanOrEqualTo( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be less than or equal to \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithCharNotLessThanOrEqualToThrowsArgumentOutOfRangeException() {

		char argumentValue = '3';
		string name = "Name";
		char value = '2';

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.LessThanOrEqualTo( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be less than or equal to \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentOutOfRangeException() {

		string argumentValue = "1";
		string name = "Name";
		string value = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.LessThanOrEqualTo( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be less than or equal to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotLessThanOrEqualToToAndMessageThrowsArgumentOutOfRangeException() {

		int argumentValue = 3;
		string name = "Name";
		string message = "Message";
		int value = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, message );
			_ = argInfo.LessThanOrEqualTo( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
