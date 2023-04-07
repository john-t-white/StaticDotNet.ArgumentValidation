namespace StaticDotNet.ArgumentValidation.UnitTests.ArrayExtensionsTests;

public sealed class Contains {

	[Fact]
	public void ReturnsCorrectly() {

		string value = "B";

		string[] argumentValue = new[] { "A", "B", "C" };
		ArgInfo<string[]> argInfo = new( argumentValue, null, null );

		ArgInfo<string[]> result = ArrayExtensions.Contains( argInfo, value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueAndEnumerableContainsNullReturnsCorrectly() {

		string? value = null;
		string?[] argumentValue = new[] { "a", null, "c" };

		ArgInfo<string?[]> argInfo = new( argumentValue, null, null );

		ArgInfo<string?[]> result = ArrayExtensions.Contains( argInfo, value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEqualityComparerReturnsCorrectly() {

		string value = "b";
		IEqualityComparer<string> comparer = StringComparer.OrdinalIgnoreCase;

		string[] argumentValue = new[] { "A", "B", "C" };
		ArgInfo<string[]> argInfo = new( argumentValue, null, null );

		ArgInfo<string[]> result = ArrayExtensions.Contains( argInfo, value, comparer );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void NotContainsValueThrowsArgumentException() {

		int[] argumentValue = new[] { 1, 2, 3 };
		string name = "Name";
		int value = 4;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<int[]> argInfo = new( argumentValue, name, null );
			_ = ArrayExtensions.Contains( argInfo, value );
		} );

		string expectedMessage = $"Value must contain {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void NotContainsStringThrowsArgumentException() {

		string[] argumentValue = new[] { "A", "B", "C" };
		string name = "Name";
		string value = "D";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, null );
			_ = ArrayExtensions.Contains( argInfo, value );
		} );

		string expectedMessage = $"Value must contain \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void NotContainsCharThrowsArgumentException() {

		char[] argumentValue = new[] { 'A', 'B', 'C' };
		string name = "Name";
		char value = 'D';

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char[]> argInfo = new( argumentValue, name, null );
			_ = ArrayExtensions.Contains( argInfo, value );
		} );

		string expectedMessage = $"Value must contain \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentException() {

		string[] argumentValue = new[] { "A", "B", "C" };
		string name = "Name";
		string value = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, null );
			_ = ArrayExtensions.Contains( argInfo, value );
		} );

		string expectedMessage = "Value must contain <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string[] argumentValue = new[] { "A", "B", "C" };
		string name = "Name";
		string message = "Message";
		string value = "D";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string[]> argInfo = new( argumentValue, name, message );
			_ = ArrayExtensions.Contains( argInfo, value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
