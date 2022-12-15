namespace StaticDotNet.ArgumentValidation.UnitTests.ComparableExtensionsTests;

public sealed class Between {

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	[InlineData( 4 )]
	public void ReturnsCorrectly( int argumentValue ) {

		int minValue = 2;
		int maxValue = 4;

		ArgInfo<int> argInfo = new( argumentValue, null, null );

		ArgInfo<int> result = argInfo.Between( minValue, maxValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( 1 )]
	[InlineData( 5 )]
	public void WithValueNotBetweenThrowsArgumentOutOfRangeException( int argumentValue ) {

		string name = "Name";
		int minValue = 2;
		int maxValue = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, null );
			_ = argInfo.Between( minValue, maxValue );
		} );

		string expectedMessage = $"Value must be between {minValue} and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullMinValueThrowsArgumentOutOfRangeException() {

		string argumentValue = "1";
		string name = "Name";
		string minValue = null!;
		string maxValue = "4";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.Between( minValue, maxValue );
		} );

		string expectedMessage = $"Value must be between <null> and {maxValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullMaxValueThrowsArgumentOutOfRangeException() {

		string argumentValue = "1";
		string name = "Name";
		string minValue = "2";
		string maxValue = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.Between( minValue, maxValue );
		} );

		string expectedMessage = $"Value must be between {minValue} and <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotBetweenAndMessageThrowsArgumentOutOfRangeException() {

		int argumentValue = 1;
		string name = "Name";
		string message = "Message";
		int minValue = 2;
		int maxValue = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, message );
			_ = argInfo.Between( minValue, maxValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
