namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class Length {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<List<string>> argInfo = new( new() { "A", "B", "C" }, null, null );
		int length = 3;

		ArgInfo<List<string>> result = EnumerableExtensions.Length( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void IEnumerableReturnsCorrectly() {

		EnumerableTestClass argumentValue = new( "123".ToCharArray() );
		ArgInfo<EnumerableTestClass> argInfo = new( argumentValue, null, null );
		int length = 3;

		ArgInfo<EnumerableTestClass> result = EnumerableExtensions.Length( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthNotEqualToThrowsArgumentOutOfRangeException() {

		List<string> argumentValue = new() { "A", "B", "C" };
		string name = "Name";
		int length = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<List<string>> argInfo = new( argumentValue, name, null );
			_ = EnumerableExtensions.Length( argInfo, length );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Count} must have a length equal to {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		List<string> argumentValue = new() { "A", "B", "C" };
		string name = "Name";
		string message = "Message";
		int length = 4;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<List<string>> argInfo = new( argumentValue, name, message );
			_ = EnumerableExtensions.Length( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
