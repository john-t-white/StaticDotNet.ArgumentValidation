namespace StaticDotNet.ArgumentValidation.UnitTests.ArrayExtensionsTests;

public sealed class LengthBetween {

	[Theory]
	[InlineData( "A", "B" )]
	[InlineData( "A", "B", "C" )]
	[InlineData( "A", "B", "C", "D" )]
	public void ReturnsCorrectly( params string[] argumentValue ) {

		ArgInfo<string[]> argInfo = new( argumentValue, null, null );
		int minLength = 2;
		int maxLength = 4;

		ArgInfo<string[]> result = ArrayExtensions.LengthBetween( argInfo, minLength, maxLength );

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
			ArgInfo<string[]> argInfo = new( argumentValue, name, null );
			_ = ArrayExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Length} must have a length between {minLength} and {maxLength}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string[] argumentValue = new[] { "A" };
		string name = "Name";
		string message = "Message";
		int minLength = 2;
		int maxLength = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, message );
			_ = ArrayExtensions.LengthBetween( argInfo, minLength, maxLength );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
