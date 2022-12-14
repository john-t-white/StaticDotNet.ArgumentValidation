namespace StaticDotNet.ArgumentValidation.UnitTests.ObjectTests;

public sealed class Same {

	[Fact]
	public void ReturnsCorrectly() {

		object argumentValue = new();
		object value = argumentValue;

		ArgInfo<object> argInfo = new( argumentValue, null, null );

		ArgInfo<object> result = argInfo.Same( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotSameThrowsArgumentException() {

		object argumentValue = new();
		string name = "Name";
		object value = new();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<object> argInfo = new( argumentValue, name, null );
			_ = argInfo.Same( value );
		} );

		string expectedMessage = $"Value must be the same.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotSameAndMessageThrowsArgumentException() {

		object argumentValue = new();
		string name = "Name";
		string message = "Message";
		object value = new();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<object> argInfo = new( argumentValue, name, message );
			_ = argInfo.Same( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
