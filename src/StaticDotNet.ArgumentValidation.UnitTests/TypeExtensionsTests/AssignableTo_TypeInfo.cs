using System;
using System.Reflection;

namespace StaticDotNet.ArgumentValidation.UnitTests.TypeExtensionsTests;

public class AssignableTo_TypeInfo {

	[Fact]
	public void WithGenericTypeParamReturnsCorrectly() {

		ArgInfo<TypeInfo> argInfo = new( typeof( string ).GetTypeInfo(), null, null );

		ArgInfo<TypeInfo> result = argInfo.AssignableTo<object>();

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void GenericTypeParamNotAssignableToThrowsArgumentException() {

		TypeInfo argumentValue = typeof( object ).GetTypeInfo();
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<TypeInfo> argInfo = new( argumentValue, name, null );
			_ = argInfo.AssignableTo<string>();
		} );

		string expectedMessage = $"Value {argumentValue.FullName} must be assignable to {typeof(string).FullName}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void GenericTypeParamNotAssignableToAndMessageThrowsArgumentException() {

		TypeInfo argumentValue = typeof( object ).GetTypeInfo();
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<TypeInfo> argInfo = new( argumentValue, name, message );
			_ = argInfo.AssignableTo<string>();
		} );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithValueReturnsCorrectly() {

		ArgInfo<TypeInfo> argInfo = new( typeof( string ).GetTypeInfo(), null, null );
		Type type = typeof( object );

		ArgInfo<TypeInfo> result = argInfo.AssignableTo( type );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotAssignableToThrowsArgumentException() {

		TypeInfo argumentValue = typeof( object ).GetTypeInfo();
		string name = "Name";
		Type type = typeof( string );

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<TypeInfo> argInfo = new( argumentValue, name, null );
			_ = argInfo.AssignableTo( type );
		} );

		string expectedMessage = $"Value {argumentValue.FullName} must be assignable to {type.FullName}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndNullTypeThrowsArgumentException() {

		TypeInfo argumentValue = typeof( object ).GetTypeInfo();
		string name = "Name";
		Type type = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<TypeInfo> argInfo = new( argumentValue, name, null );
			_ = argInfo.AssignableTo( type );
		} );

		string expectedMessage = $"Value {argumentValue.FullName} must be assignable to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotAssignableToAndMessageThrowsArgumentException() {

		TypeInfo argumentValue = typeof( object ).GetTypeInfo();
		string name = "Name";
		string message = "Message";
		Type type = typeof( string );

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<TypeInfo> argInfo = new( argumentValue, name, message );
			_ = argInfo.AssignableTo( type );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
