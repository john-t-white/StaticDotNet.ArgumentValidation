namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class Contains {

	[Fact]
	public void ReturnsCorrectly() {

		int value = 2;

		IEnumerable<int> argumentValue = new List<int>() { 1, 2, 3 };
		ArgInfo<IEnumerable<int>> argInfo = new( argumentValue, null, null );

		ArgInfo<IEnumerable<int>> result = argInfo.Contains( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueAndEnumerableContainsNullReturnsCorrectly() {

		string? value = null;
		IEnumerable<string?> argumentValue = new List<string?>() { "a", null, "c" };

		ArgInfo<IEnumerable<string?>> argInfo = new( argumentValue, null, null );

		ArgInfo<IEnumerable<string?>> result = argInfo.Contains( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEqualityComparerReturnsCorrectly() {

		string value = "b";
		IEqualityComparer<string> comparer = StringComparer.OrdinalIgnoreCase;

		IList<string> argumentValue = new[] { "A", "B", "C" };
		ArgInfo<IList<string>> argInfo = new( argumentValue, null, null );

		ArgInfo<IList<string>> result = argInfo.Contains( value, comparer );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotContainsValueThrowsArgumentException() {

		IEnumerable<int> argumentValue = new List<int>() { 1, 2, 3 };
		string name = "Name";
		int value = 4;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<IEnumerable<int>> argInfo = new( argumentValue, name, null );
			_ = argInfo.Contains( value );
		} );

		string expectedMessage = $"Value must contain {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentException() {

		IEnumerable<string> argumentValue = new List<string>() { "a", "b", "c" };
		string name = "Name";
		string value = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<IEnumerable<string>> argInfo = new( argumentValue, name, null );
			_ = argInfo.Contains( value );
		} );

		string expectedMessage = "Value must contain <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		IEnumerable<int> argumentValue = new List<int>() { 1, 2, 3 };
		string name = "Name";
		string message = "Message";
		int value = 4;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<IEnumerable<int>> argInfo = new( argumentValue, name, message );
			_ = argInfo.Contains( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
