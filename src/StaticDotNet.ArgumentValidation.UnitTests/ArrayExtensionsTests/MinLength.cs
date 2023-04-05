namespace StaticDotNet.ArgumentValidation.UnitTests.ArrayExtensionsTests;

public sealed class MinLength {

	[Theory]
	[InlineData( "A", "B" )]
	[InlineData( "A", "B", "C" )]
	public void ReturnsCorrectly( params string[] argumentValue ) {

		int length = 2;

		ArgInfo<string[]> argInfo = new( argumentValue, null, null );

		ArgInfo<string[]> result = ArrayExtensions.MinLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLessThanMinLengthThrowsArgumentOutOfRangeException() {

		string[] argumentValue = new[] { "A" };
		string name = "Name";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, null );
			_ = ArrayExtensions.MinLength( argInfo, length );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Length} is below the minimum length of {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string[] argumentValue = new[] { "A" };
		string name = "Name";
		string message = "Message";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, message );
			_ = ArrayExtensions.MinLength( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
