namespace StaticDotNet.ArgumentValidation.UnitTests.ComparableExtensionsTests;

public sealed class GreaterThan {

	[Fact]
	public void ReturnsCorrectly() {

		int value = 2;

		ArgInfo<int> argInfo = new( 3, null, null );

		ArgInfo<int> result = argInfo.GreaterThan( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( 1 )]
	[InlineData( 2 )]
	public void WithValueNotGreaterThanThrowsArgumentOutOfRangeException( int argumentValue ) {

		string name = "Name";
		int value = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, null );
			_ = argInfo.GreaterThan( value );
		} );

		string expectedMessage = $"Value {argumentValue} must be greater than {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Theory]
	[InlineData( "1" )]
	[InlineData( "2" )]
	public void WithStringNotGreaterThanThrowsArgumentOutOfRangeException( string argumentValue ) {

		string name = "Name";
		string value = "2";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.GreaterThan( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be greater than \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Theory]
	[InlineData( '1' )]
	[InlineData( '2' )]
	public void WithCharNotGreaterThanThrowsArgumentOutOfRangeException( char argumentValue ) {

		string name = "Name";
		char value = '2';

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.GreaterThan( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be greater than \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentOutOfRangeException() {

		string argumentValue = "1";
		string name = "Name";
		string value = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.GreaterThan( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be greater than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotGreaterThanToAndMessageThrowsArgumentOutOfRangeException() {

		int argumentValue = 1;
		string name = "Name";
		string message = "Message";
		int value = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, message );
			_ = argInfo.GreaterThan( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
