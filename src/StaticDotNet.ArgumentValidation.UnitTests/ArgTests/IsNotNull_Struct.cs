namespace StaticDotNet.ArgumentValidation.UnitTests.ArgTests;

public sealed class IsNotNull_Struct {

	[Fact]
	public void ReturnsCorrectly() {

		int? value = 1;

		ArgInfo<int> result = Arg.IsNotNull( value );

		Assert.Equal( value.Value, result.Value );
		Assert.Equal( nameof( value ), result.Name );
		Assert.Null( result.Message );
	}

	[Fact]
	public void WithNameAndMessageReturnsCorrectly() {

		int? value = 1;
		string name = "Name";
		string message = "Message";

		ArgInfo<int> result = Arg.IsNotNull( value, name, message );

		Assert.Equal( value.Value, result.Value );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		int? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.IsNotNull( value ) );
	}

	[Fact]
	public void WithNullValueAndNameReturnsCorrectly() {

		int? value = null;
		string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Arg.IsNotNull( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageReturnsCorrectly() {

		int? value = null;
		string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.IsNotNull( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
