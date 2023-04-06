namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class LengthBetween {

	[Theory]
	[InlineData( "A", "B" )]
	[InlineData( "A", "B", "C" )]
	[InlineData( "A", "B", "C", "D" )]
	public void ReturnsCorrectly( params string[] argumentValue ) {

		ArgInfo<List<string>> argInfo = new( new( argumentValue ), null, null );
		int minLength = 2;
		int maxLength = 4;

		ArgInfo<List<string>> result = EnumerableExtensions.LengthBetween( argInfo, minLength, maxLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "A", "B" )]
	[InlineData( "A", "B", "C" )]
	[InlineData( "A", "B", "C", "D" )]
	public void IEnumerableReturnsCorrectly( params string[] argumentValue ) {

		EnumerableTestClass enumerableValue = new( argumentValue );
		ArgInfo<EnumerableTestClass> argInfo = new( enumerableValue, null, null );
		int minLength = 2;
		int maxLength = 4;

		ArgInfo<EnumerableTestClass> result = EnumerableExtensions.LengthBetween( argInfo, minLength, maxLength );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "A" )]
	[InlineData( "A", "B", "C", "D", "E" )]
	public void WithValueLengthNotBetweenThrowsArgumentOutOfRangeException( params string[] argumentValue ) {

		string name = "Name";
		int minLength = 2;
		int maxLength = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<List<string>> argInfo = new( new( argumentValue ), name, null );
			_ = EnumerableExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Length} must have a length between {minLength} and {maxLength}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		List<string> argumentValue = new() { "A" };
		string name = "Name";
		string message = "Message";
		int minLength = 2;
		int maxLength = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<List<string>> argInfo = new( argumentValue, name, message );
			_ = EnumerableExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
