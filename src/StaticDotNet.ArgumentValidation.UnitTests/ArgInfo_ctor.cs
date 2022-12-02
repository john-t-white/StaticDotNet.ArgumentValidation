namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class ArgInfo_ctor {

	[Fact]
	public void InitializesCorrectly() {

		object value = new();
		string name = "Name";
		string message = "Message";

		ArgInfo<object> result = new( value, name, message );

		Assert.Same( value, result.Value );
		Assert.Null( result.ValueAsString );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}

	[Fact]
	public void WithStringNameInitializesCorrectly() {

		string value = "Value";
		string name = "Name";
		string message = "Message";

		ArgInfo<object> result = new( value, name, message );

		Assert.Same( value, result.Value );
		Assert.Equal( result.Value, result.ValueAsString );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}
}
