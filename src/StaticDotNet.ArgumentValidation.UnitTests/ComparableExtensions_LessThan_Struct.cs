namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class ComparableExtensions_LessThan_Struct {

	[Fact]
	public void ReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 2;

		ArgInfo<int> argInfo = new( value, null, null );

		ArgInfo<int> result = argInfo.LessThan( comparisonValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int? value = null;
		int comparisionValue = 2;

		ArgInfo<int?> argInfo = new( value, null, null );

		ArgInfo<int?> result = argInfo.LessThan( comparisionValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void WithValueNotLessThanThrowsArgumentOutOfRangeException( int value ) {

		string name = "Name";
		int comparisionValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, null );
			_ = argInfo.LessThan( comparisionValue );
		} );

		string expectedMessage = $"Value must be less than {comparisionValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotValueLessThanAndMessageThrowsArgumentOutOfRangeException() {

		int value = 3;
		string name = "Name";
		string message = "Message";
		int comparisionValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, message );
			_ = argInfo.LessThan( comparisionValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
