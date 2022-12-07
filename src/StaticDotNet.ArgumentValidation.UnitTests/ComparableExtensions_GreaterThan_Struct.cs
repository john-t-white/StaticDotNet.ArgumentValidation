namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class ComparableExtensions_GreaterThan_Struct {

	[Fact]
	public void ReturnsCorrectly() {

		int value = 3;
		int comparisonValue = 2;

		ArgInfo<int> argInfo = new( value, null, null );

		ArgInfo<int> result = argInfo.GreaterThan( comparisonValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		int? value = null;
		int comparisionValue = 2;

		ArgInfo<int?> argInfo = new( value, null, null );

		ArgInfo<int?> result = argInfo.GreaterThan( comparisionValue );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( 1 )]
	[InlineData( 2 )]
	public void WithValueNotGreaterThanThrowsArgumentOutOfRangeException( int value ) {

		string name = "Name";
		int comparisionValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, null );
			_ = argInfo.GreaterThan( comparisionValue );
		} );

		string expectedMessage = $"Value must be greater than {comparisionValue}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanToAndMessageThrowsArgumentOutOfRangeException() {

		int value = 1;
		string name = "Name";
		string message = "Message";
		int comparisionValue = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( value, name, message );
			_ = argInfo.GreaterThan( comparisionValue );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
