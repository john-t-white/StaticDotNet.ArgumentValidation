using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringConversionExtensionsTests;

public sealed class ToGuid {

	[Fact]
	public void ReturnsCorrectly() {

		var expectedResult = Guid.NewGuid();
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<Guid> result = StringConversionExtensions.ToGuid( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToGuid( argInfo );
		} );

		string expectedMessage = "Value must be a guid.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToGuid( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}

#if NET7_0_OR_GREATER

[Fact]
	public void WithFormatReturnsCorrectly() {

		var expectedResult = Guid.NewGuid();
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = CultureInfo.InvariantCulture;

		ArgInfo<Guid> result = StringConversionExtensions.ToGuid( argInfo, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithFormatAndInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		IFormatProvider provider = CultureInfo.InvariantCulture;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToGuid( argInfo, provider );
		} );

		string expectedMessage = "Value must be a guid.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithFormatAndInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		IFormatProvider provider = CultureInfo.InvariantCulture;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToGuid( argInfo, provider );
		} );

		Assert.StartsWith( message, exception.Message );
	}

#endif
}
