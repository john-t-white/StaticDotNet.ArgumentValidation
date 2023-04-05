namespace StaticDotNet.ArgumentValidation.UnitTests.ArrayExtensionsTests;

public sealed class MaxLength {

	[Theory]
	[InlineData( "A" )]
	[InlineData( "A", "B" )]
	public void ReturnsCorrectly( params string[] argumentValue ) {

		int length = 2;

		ArgInfo<string[]> argInfo = new( argumentValue, null, null );

		ArgInfo<string[]> result = ArrayExtensions.MaxLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLargerThanMaxThrowsArgumentOutOfRangeException() {

		string[] argumentValue = new[] { "A", "B", "C" };
		string name = "Name";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, null );
			_ = ArrayExtensions.MaxLength( argInfo, length );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Length} exceeds the maximum length of {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string[] argumentValue = new[] { "A", "B", "C" };
		string name = "Name";
		string message = "Message";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, message );
			_ = ArrayExtensions.MaxLength( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
