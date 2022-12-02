namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EnumerableExtensions_NotEmpty_Array {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<Array> argInfo = new( new int[] { 1 }, null, null );

		ArgInfo<Array> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithSpecificArrayReturnsCorrectly() {

		ArgInfo<int[]> argInfo = new( new int[] { 1 }, null, null );

		ArgInfo<int[]> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithSpecificNullableArrayReturnsCorrectly() {

		ArgInfo<int?[]> argInfo = new( new int?[] { 1 }, null, null );

		ArgInfo<int?[]> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<Array?> argInfo = new( null, null, null );

		ArgInfo<Array?> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		Array value = Array.Empty<int>();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Array> argInfo = new( value, name, null );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		Array value = Array.Empty<int>();
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Array> argInfo = new( value, name, message );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
