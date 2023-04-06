using System;

namespace StaticDotNet.ArgumentValidation.UnitTests.TypeExtensionsTests;

public class AssignableTo_Type {

	[Fact]
	public void WithGenericTypeParamReturnsCorrectly() {

		ArgInfo<Type> argInfo = new( typeof( string ), null, null );

		ArgInfo<Type> result = argInfo.AssignableTo<object>();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithGenericTypeNotAssignableToThrowsArgumentException() {

		Type argumentValue = typeof( object );
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Type> argInfo = new( argumentValue, name, null );
			_ = argInfo.AssignableTo<string>();
		} );

		string expectedMessage = $"Value {argumentValue.FullName} must be assignable to {typeof(string).FullName}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithGenericTypeNotAssignableToAndMessageThrowsArgumentException() {

		Type argumentValue = typeof( object );
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Type> argInfo = new( argumentValue, name, message );
			_ = argInfo.AssignableTo<string>();
		} );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithValueReturnsCorrectly() {

		Type type = typeof( object );
		ArgInfo<Type> argInfo = new( typeof( string ), null, null );

		ArgInfo<Type> result = argInfo.AssignableTo( type );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotAssignableToThrowsArgumentException() {

		Type argumentValue = typeof( object );
		string name = "Name";
		Type type = typeof( string );

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Type> argInfo = new( argumentValue, name, null );
			_ = argInfo.AssignableTo( type );
		} );

		string expectedMessage = $"Value {argumentValue.FullName} must be assignable to {type.FullName}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullTypeThrowsArgumentException() {

		Type argumentValue = typeof( object );
		string name = "Name";
		Type type = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Type> argInfo = new( argumentValue, name, null );
			_ = argInfo.AssignableTo( type );
		} );

		string expectedMessage = $"Value {argumentValue.FullName} must be assignable to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotAssignableToAndMessageThrowsArgumentException() {

		Type argumentValue = typeof( object );
		string name = "Name";
		string message = "Message";
		Type type = typeof( string );

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<Type> argInfo = new( argumentValue, name, message );
			_ = argInfo.AssignableTo( type );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
