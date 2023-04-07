namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class Contains {

	[Fact]
	public void ReturnsCorrectly() {

		string value = "B";

		IList<string> argumentValue = new[] { "A", "B", "C" };
		ArgInfo<IEnumerable<string>> argInfo = new( argumentValue, null, null );

		ArgInfo<IEnumerable<string>> result = EnumerableExtensions.Contains( argInfo, value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueAndEnumerableContainsNullReturnsCorrectly() {

		string? value = null;
		IEnumerable<string?> argumentValue = new List<string?>() { "a", null, "c" };

		ArgInfo<IEnumerable<string?>> argInfo = new( argumentValue, null, null );

		ArgInfo<IEnumerable<string?>> result = EnumerableExtensions.Contains( argInfo, value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEqualityComparerReturnsCorrectly() {

		string value = "b";
		IEqualityComparer<string> comparer = StringComparer.OrdinalIgnoreCase;

		IList<string> argumentValue = new[] { "A", "B", "C" };
		ArgInfo<IList<string>> argInfo = new( argumentValue, null, null );

		ArgInfo<IList<string>> result = EnumerableExtensions.Contains( argInfo, value, comparer );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNotContainsValueThrowsArgumentException() {

		IList<string> argumentValue = new[] { "A", "B", "C" };
		string name = "Name";
		string value = "D";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<IEnumerable<string>> argInfo = new( argumentValue, name, null );
			_ = EnumerableExtensions.Contains( argInfo, value );
		} );

		string expectedMessage = $"Value must contain \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentException() {

		IList<string> argumentValue = new[] { "A", "B", "C" };
		string name = "Name";
		string value = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<IEnumerable<string>> argInfo = new( argumentValue, name, null );
			_ = EnumerableExtensions.Contains( argInfo, value );
		} );

		string expectedMessage = "Value must contain <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		IList<string> argumentValue = new[] { "A", "B", "C" };
		string name = "Name";
		string message = "Message";
		string value = "D";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<IEnumerable<string>> argInfo = new( argumentValue, name, message );
			_ = EnumerableExtensions.Contains( argInfo, value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
