namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class Argument_Object_NotNull {

	[Fact]
	public void WithNotNullValueReturnsCorrectly()
	{
		object value = new();

		object result = Argument.Is.NotNull( value );

		Assert.Same( value, result );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException()
	{
		object? value = null;

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNull( value ) );
	}
	
	[Fact]
	public void WithNullValueAndNameThrowsArgumentNullException()
	{
		object? value = null;
		const string name = "Name";

		_ = Assert.Throws<ArgumentNullException>( name, () => Argument.Is.NotNull( value, name ) );
	}

	[Fact]
	public void WithNullValueAndMessageThrowsArgumentNullException()
	{
		object? value = null;
		const string message = "Message";

		ArgumentNullException exception = Assert.Throws<ArgumentNullException>( nameof( value ),
			() => Argument.Is.NotNull( value, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}