namespace StaticDotNet.ArgumentValidation.UnitTests.TypeExtensionsTests;

public class AssignableTo_Type {

	[Fact]
	public void ReturnsCorrectly() {

		Type type = typeof( object );
		ArgInfo<Type> argInfo = new( typeof( string ), null, null );

		ArgInfo<Type> result = argInfo.AssignableTo( type );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		Type type = typeof( object );
		ArgInfo<Type?> argInfo = new( null, null, null );

		ArgInfo<Type?> result = argInfo.AssignableTo( type );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotAssignableToThrowsArgumentException() {

		Type type = typeof( string );
		Type? value = typeof( object );
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Type> argInfo = new( value, name, null );
			_ = argInfo.AssignableTo( type );
		} );

		string expectedMessage = $"Value must be assignable to {type.FullName}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullTypeThrowsArgumentException() {

		Type type = null!;
		Type? value = typeof( object );
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Type> argInfo = new( value, name, null );
			_ = argInfo.AssignableTo( type );
		} );

		string expectedMessage = "Value must be assignable to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotAssignableToAndMessageThrowsArgumentException() {

		Type type = typeof( string );
		Type? value = typeof( object );
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Type> argInfo = new( value, name, message );
			_ = argInfo.AssignableTo( type );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
