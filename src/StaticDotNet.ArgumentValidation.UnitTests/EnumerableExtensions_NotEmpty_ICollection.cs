using System.Collections.ObjectModel;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class EnumerableExtensions_NotEmpty_ICollection {

	[Fact]
	public void ReturnsCorrectly() {

		ArgInfo<ICollection<object>> argInfo = new( new Collection<object>() { new() }, null, null );

		ArgInfo<ICollection<object>> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		ArgInfo<ICollection<object>?> argInfo = new( null, null, null );

		ArgInfo<ICollection<object>?> result = EnumerableExtensions.NotEmpty( argInfo );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string name = "Name";
		ICollection<object> value = new Collection<object>();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<ICollection<object>> argInfo = new( value, name, null );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		string expectedMessage = "Value cannot be empty.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string name = "Name";
		ICollection<object> value = new Collection<object>();
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<ICollection<object>> argInfo = new( value, name, message );
			_ = EnumerableExtensions.NotEmpty( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
