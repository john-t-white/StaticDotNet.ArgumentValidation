#if NET7_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.DecimalExtensionsTests;

public sealed class ScaleEqualTo {

	[Fact]
	public void WithValueScaleEqualToScaleReturnsCorrectly() {

		byte scale = 2;

		ArgInfo<decimal> argInfo = new( 1.00m, null, null );

		ArgInfo<decimal> result = argInfo.ScaleEqualTo( scale );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueScaleLessThanScaleThrowsArgumentOutOfRangeException() {

		byte scale = 2;
		decimal argumentValue = 1.0m;
		string name = "Name";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<decimal> argInfo = new( argumentValue, name, null );
			_ = argInfo.ScaleEqualTo( scale );
		} );

		string expectedMessage = $"Value {argumentValue} must have a scale equal to {scale}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueScaleGreaterThanScaleThrowsArgumentOutOfRangeException() {

		byte scale = 2;
		decimal argumentValue = 1.000m;
		string name = "Name";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<decimal> argInfo = new( argumentValue, name, null );
			_ = argInfo.ScaleEqualTo( scale );
		} );

		string expectedMessage = $"Value {argumentValue} must have a scale equal to {scale}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		byte scale = 2;
		decimal argumentValue = 1.000m;
		string name = "Name";
		string message = "Message";

		ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( name, () => {
			ArgInfo<decimal> argInfo = new( argumentValue, name, message );
			_ = argInfo.ScaleEqualTo( scale );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
