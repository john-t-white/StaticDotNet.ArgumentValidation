namespace StaticDotNet.ArgumentValidation.UnitTests.ComparableExtensionsTests;

public sealed class LessThan {

	[Fact]
	public void ReturnsCorrectly() {

		int argumentValue = 1;
		int value = 2;

		ArgInfo<int> argInfo = new( argumentValue, null, null );

		ArgInfo<int> result = argInfo.LessThan( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Theory]
	[InlineData( 2 )]
	[InlineData( 3 )]
	public void WithValueNotLessThanThrowsArgumentOutOfRangeException( int argumentValue ) {

		string name = "Name";
		int value = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, null );
			_ = argInfo.LessThan( value );
		} );

		string expectedMessage = $"Value {argumentValue} must be less than {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Theory]
	[InlineData( "2" )]
	[InlineData( "3" )]
	public void WithStringNotLessThanThrowsArgumentOutOfRangeException( string argumentValue ) {

		string name = "Name";
		string value ="2";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.LessThan( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be less than \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Theory]
	[InlineData( '2' )]
	[InlineData( '3' )]
	public void WithCharNotLessThanThrowsArgumentOutOfRangeException( char argumentValue ) {

		string name = "Name";
		char value = '2';

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.LessThan( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be less than \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentOutOfRangeException() {

		string argumentValue = "1";
		string name = "Name";
		string value = null!;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.LessThan( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be less than <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotValueLessThanAndMessageThrowsArgumentOutOfRangeException() {

		int argumentValue = 3;
		string name = "Name";
		string message = "Message";
		int value = 2;

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, message );
			_ = argInfo.LessThan( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
