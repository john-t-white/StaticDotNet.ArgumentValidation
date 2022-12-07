namespace StaticDotNet.ArgumentValidation.UnitTests.ComparableExtensionsTests;

public sealed class Between_Struct {

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	[InlineData( 4 )]
	public void ReturnsCorrectly( int value ) {

		int minValue = 2;
		int maxValue = 4;

		ArgInfo<int> argInfo = new( value, null, null );

		ArgInfo<int> result = argInfo.Between( minValue, maxValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int? value = null;
		int minValue = 2;
		int maxValue = 4;

		ArgInfo<int?> argInfo = new( value, null, null );

		ArgInfo<int?> result = argInfo.Between( minValue, maxValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( 1 )]
	[InlineData( 5 )]
	public void WithValueNotBetweenThrowsArgumentOutOfRangeException( int value ) {

		string name = "Name";
		int minValue = 2;
		int maxValue = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, null );
			_ = argInfo.Between( minValue, maxValue );
		} );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotBetweenAndMessageThrowsArgumentOutOfRangeException() {

		int value = 1;
		string name = "Name";
		string message = "Message";
		int minValue = 2;
		int maxValue = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, message );
			_ = argInfo.Between( minValue, maxValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
