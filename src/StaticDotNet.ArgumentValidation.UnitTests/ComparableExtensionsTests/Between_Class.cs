namespace StaticDotNet.ArgumentValidation.UnitTests.ComparableExtensionsTests;

public sealed class Between_Class {

	[Theory]
	[InlineData( "b" )]
	[InlineData( "c" )]
	[InlineData( "d" )]
	public void ReturnsCorrectly( string value ) {

		string minValue = "b";
		string maxValue = "d";

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = argInfo.Between( minValue, maxValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		string? value = null;
		string minValue = "b";
		string maxValue = "d";

		ArgInfo<string?> argInfo = new( value, null, null );

		ArgInfo<string?> result = argInfo.Between( minValue, maxValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "a" )]
	[InlineData( "e" )]
	public void WithValueNotBetweenThrowsArgumentOutOfRangeException( string value ) {

		string name = "Name";
		string minValue = "b";
		string maxValue = "d";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.Between( minValue, maxValue );
		} );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullMinValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string name = "Name";
		string minValue = null!;
		string maxValue = "d";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.Between( minValue, maxValue );
		} );

		string expectedMessage = $"Value must be between <null> and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullMaxValueThrowsArgumentOutOfRangeException() {

		string value = "a";
		string name = "Name";
		string minValue = "b";
		string maxValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.Between( minValue, maxValue );
		} );

		string expectedMessage = $"Value must be between {minValue} and <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotBetweenAndMessageThrowsArgumentOutOfRangeException() {

		string value = "a";
		string name = "Name";
		string message = "Message";
		string minValue = "b";
		string maxValue = "d";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.Between( minValue, maxValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
