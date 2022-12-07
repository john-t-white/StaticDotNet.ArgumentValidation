namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EnumerableExtensions_NotEmpty_StructArray {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<int[]> argInfo = new( new int[] { 1 }, null, null );

		ArgInfo<int[]> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullableArrayReturnsCorrectly() {

		ArgInfo<int?[]> argInfo = new( new int?[] { 1, null }, null, null );

		ArgInfo<int?[]> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

        ArgInfo<int[]?> argInfo = new( null, null, null );

        ArgInfo<int[]?> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		int[] value = Array.Empty<int>();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
            ArgInfo<int[]> argInfo = new( value, name, null );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		int[] value = Array.Empty<int>();
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
            ArgInfo<int[]> argInfo = new( value, name, message );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
