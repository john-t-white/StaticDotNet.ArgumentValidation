namespace StaticDotNet.ArgumentValidation.UnitTests.ArrayExtensionsTests;

public sealed class Length {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<string[]> argInfo = new( new[] { "A", "B", "C" }, null, null );
		int length = 3;

		ArgInfo<string[]> result = ArrayExtensions.Length( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthNotEqualToThrowsArgumentOutOfRangeException() {

		string[] argumentValue = new[] { "A", "B", "C" };
		string name = "Name";
		int length = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, null );
			_ = ArrayExtensions.Length( argInfo, length );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Length} must have a length equal to {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		string[] argumentValue = new[] { "A", "B", "C" };
		string name = "Name";
		string message = "Message";
		int length = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, message );
			_ = ArrayExtensions.Length( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
