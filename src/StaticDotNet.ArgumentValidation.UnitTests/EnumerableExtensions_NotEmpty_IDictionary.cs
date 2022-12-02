﻿namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EnumerableExtensions_NotEmpty_IDicionary {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<IDictionary<string, int>> argInfo = new( new Dictionary<string, int>() { { "Key", 1 } }, null, null );

		ArgInfo<IDictionary<string, int>> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<IDictionary<string, int>?> argInfo = new( null, null, null );

		ArgInfo<IDictionary<string, int>?> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		IDictionary<string, int> value = new Dictionary<string, int>();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<IDictionary<string, int>> argInfo = new( value, name, null );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		IDictionary<string, int> value = new Dictionary<string, int>();
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<IDictionary<string, int>> argInfo = new( value, name, message );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
