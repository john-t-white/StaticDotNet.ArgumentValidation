namespace StaticDotNet.ArgumentValidation.UnitTests.ObjectTests;

public sealed class NotSame {

	[Fact]
	public void ReturnsCorrectly() {

		object argumentValue = new();
		object value = new();

		ArgInfo<object> argInfo = new( argumentValue, null, null );

		ArgInfo<object> result = argInfo.NotSame( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotSameThrowsArgumentException() {

		object argumentValue = new();
		string name = "Name";
		object value = argumentValue;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<object> argInfo = new( argumentValue, name, null );
			_ = argInfo.NotSame( value );
		} );

		string expectedMessage = $"Value must not be the same.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotSameAndMessageThrowsArgumentException() {

		object argumentValue = new();
		string name = "Name";
		string message = "Message";
		object value = argumentValue;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<object> argInfo = new( argumentValue, name, message );
			_ = argInfo.NotSame( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
