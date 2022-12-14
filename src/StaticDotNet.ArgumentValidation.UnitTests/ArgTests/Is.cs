namespace StaticDotNet.ArgumentValidation.UnitTests.ArgTests;

public sealed class Is {

	[Fact]
	public void ReturnsCorrectly() {

		int value = 1;

		ArgInfo<int> result = Arg.Is( value );

		Assert.Equal( value, result.Value );
		Assert.Equal( nameof( value ), result.Name );
		Assert.Null( result.Message );
	}

	[Fact]
	public void WithNameAndMessageReturnsCorrectly() {

		int value = 1;
		string name = "Name";
		string message = "Message";

		ArgInfo<int> result = Arg.Is( value, name, message );

		Assert.Equal( value, result.Value );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}
}
