namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class MaxLength {

	[Theory]
	[InlineData( "A" )]
	[InlineData( "A", "B" )]
	public void ReturnsCorrectly( params string[] argumentValue ) {

		int length = 2;

		ArgInfo<List<string>> argInfo = new( new( argumentValue ), null, null );

		ArgInfo<List<string>> result = EnumerableExtensions.MaxLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( "A" )]
	[InlineData( "A", "B" )]
	public void IEnumerableReturnsCorrectly( params string[] argumentValue ) {

		EnumerableTestClass enumerableValue = new( argumentValue );
		ArgInfo<EnumerableTestClass> argInfo = new( enumerableValue, null, null );
		int length = 2;

		ArgInfo<EnumerableTestClass> result = EnumerableExtensions.MaxLength( argInfo, length );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueLengthLargerThanMaxThrowsArgumentOutOfRangeException() {

		List<string> argumentValue = new() { "A", "B", "C" };
		string name = "Name";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<List<string>> argInfo = new( argumentValue, name, null );
			_ = EnumerableExtensions.MaxLength( argInfo, length );
		} );

		string expectedMessage = $"Value cannot have a length greater than {length}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentOutOfRangeException() {

		List<string> argumentValue = new() { "A", "B", "C" };
		string name = "Name";
		string message = "Message";
		int length = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<List<string>> argInfo = new( argumentValue, name, message );
			_ = EnumerableExtensions.MaxLength( argInfo, length );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
