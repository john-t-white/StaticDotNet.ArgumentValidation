using System.Reflection;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public class TypeExtensions_AssignableTo {

	[Fact]
	public void ReturnsCorrectly() {

		TypeInfo type = typeof( object ).GetTypeInfo();
		ArgInfo<TypeInfo> argInfo = new( typeof( string ).GetTypeInfo(), null, null );

		ArgInfo<TypeInfo> result = TypeExtensions.AssignableTo( argInfo, type );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		TypeInfo type = typeof( object ).GetTypeInfo();
		ArgInfo<TypeInfo?> argInfo = new( null, null, null );

		ArgInfo<TypeInfo?> result = TypeExtensions.AssignableTo( argInfo, type );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotAssignableToThrowsArgumentException() {

		TypeInfo type = typeof( string ).GetTypeInfo();
		TypeInfo? value = typeof( object ).GetTypeInfo();
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<TypeInfo> argInfo = new( value, name, null );
			_ = TypeExtensions.AssignableTo( argInfo, type );
		} );

		string expectedMessage = $"Value must be assignable to {type.FullName}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullTypeThrowsArgumentException() {

		TypeInfo type = null!;
		string name = "Name";
		TypeInfo? value = typeof( object ).GetTypeInfo();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<TypeInfo> argInfo = new( value, name, null );
			_ = TypeExtensions.AssignableTo( argInfo, type );
		} );

		string expectedMessage = "Value must be assignable to <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotAssignableToAndMessageThrowsArgumentException() {

		TypeInfo type = typeof( string ).GetTypeInfo();
		TypeInfo? value = typeof( object ).GetTypeInfo();
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<TypeInfo> argInfo = new( value, name, message );
			_ = TypeExtensions.AssignableTo( argInfo, type );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
