namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class MinLength {

	[Theory]
	[InlineData( "A", "B" )]
	[InlineData( "A", "B", "C" )]
	public void ReturnsCorrectly( params string[] argumentValue ) {

		int length = 2;

		ArgInfo<List<string>> argInfo = new( new( argumentValue ), null, null );

		ArgInfo<List<string>> result = EnumerableExtensions.MinLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "A", "B" )]
	[InlineData( "A", "B", "C" )]
	public void IEnumerableReturnsCorrectly( params string[] argumentValue ) {

		EnumerableTestClass enumerableValue = new( argumentValue );
		ArgInfo<EnumerableTestClass> argInfo = new( enumerableValue, null, null );
		int length = 2;

		ArgInfo<EnumerableTestClass> result = EnumerableExtensions.MinLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLessThanMinLengthThrowsArgumentOutOfRangeException() {

		List<string> argumentValue = new() { "A" };
		string name = "Name";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<List<string>> argInfo = new( argumentValue, name, null );
			_ = EnumerableExtensions.MinLength( argInfo, length );
		} );

		string expectedMessage = $"Value with a length of {argumentValue.Count} is below the minimum length of {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		List<string> argumentValue = new() { "A" };
		string name = "Name";
		string message = "Message";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<List<string>> argInfo = new( argumentValue, name, message );
			_ = EnumerableExtensions.MinLength( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
