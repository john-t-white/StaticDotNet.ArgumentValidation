namespace StaticDotNet.ArgumentValidation.UnitTests.ArgInfoTests;

public sealed class Ctor {

	[Fact]
	public void InitializesCorrectly() {

		object value = new();
		string name = "Name";
		string message = "Message";

		ArgInfo<object> result = new( value, name, message );

		Assert.Same( value, result.Value );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}
}
