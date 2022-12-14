namespace StaticDotNet.ArgumentValidation.UnitTests.ArgTests;

public sealed class Is {

	[Fact]
	public void ReturnsCorrectly() {

		object value = new();

		ArgInfo<object> result = Arg.Is( value );

		Assert.Same( value, result.Value );
		Assert.Equal( nameof( value ), result.Name );
		Assert.Null( result.Message );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		object value = null!;

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is( value ) );

		string expectedMessage = "Value is unexpectedly null. Please use Arg.IsNotNull.";

		Assert.StartsWith(expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNameAndMessageReturnsCorrectly() {

		object value = new();
		string name = "Name";
		string message = "Message";

		ArgInfo<object> result = Arg.Is( value, name, message );

		Assert.Same( value, result.Value );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}
}
