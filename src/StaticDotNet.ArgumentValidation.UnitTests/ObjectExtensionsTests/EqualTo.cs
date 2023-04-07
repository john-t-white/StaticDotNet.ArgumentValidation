namespace StaticDotNet.ArgumentValidation.UnitTests.ObjectTests;

public sealed class EqualTo {

	[Fact]
	public void ReturnsCorrectly() {

		int argumentValue = 1;
		int value = 1;

		ArgInfo<int> argInfo = new( argumentValue, null, null );

		ArgInfo<int> result = argInfo.EqualTo( value );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithEqualityComparerReturnsCorrectly() {

		int argumentValue = 1;
		int value = 1;
		IEqualityComparer<int> comparer = EqualityComparer<int>.Default;

		ArgInfo<int> argInfo = new( argumentValue, null, null );

		ArgInfo<int> result = argInfo.EqualTo( value, comparer );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotEqualToThrowsArgumentException() {

		int argumentValue = 2;
		string name = "Name";
		int value = 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, null );
			_ = argInfo.EqualTo( value );
		} );

		string expectedMessage = $"Value {argumentValue} must be equal to {value}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithStringNotEqualToThrowsArgumentException() {

		string argumentValue = "2";
		string name = "Name";
		string value = "1";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.EqualTo( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be equal to \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithCharNotEqualToThrowsArgumentException() {

		char argumentValue = '2';
		string name = "Name";
		char value = '1';

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = argInfo.EqualTo( value );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be equal to \"{value}\".";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotEqualToAndMessageThrowsArgumentException() {

		int argumentValue = 2;
		string name = "Name";
		string message = "Message";
		int value = 1;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<int> argInfo = new( argumentValue, name, message );
			_ = argInfo.EqualTo( value );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}
