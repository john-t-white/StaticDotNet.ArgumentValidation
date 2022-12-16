using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.StringConversionExtensionsTests;

public sealed class ToUri {

	[Fact]
	public void WithUriKindReturnsCorrectly() {

		UriKind uriKind = UriKind.Absolute;
		Uri expectedResult = new("http://www.example.com/", uriKind );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<Uri> result = StringConversionExtensions.ToUri( argInfo, uriKind );

		Assert.Equal( expectedResult.OriginalString, result.Value.OriginalString );
	}

	[Fact]
	public void WithUriAndInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		UriKind uriKind = UriKind.Absolute;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToUri( argInfo, uriKind );
		} );

		string expectedMessage = "Value must be a uri.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithUriAndInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		UriKind uriKind = UriKind.Absolute;

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToUri( argInfo, uriKind );
		} );

		Assert.StartsWith( message, exception.Message );
	}

#if NET6_0_OR_GREATER

	[Fact]
	public void WithUriCreationOptionsReturnsCorrectly() {

		UriCreationOptions creationOptions = new();
		Uri expectedResult = new( "http://www.example.com/", creationOptions );
		ArgInfo<string> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<Uri> result = StringConversionExtensions.ToUri( argInfo, creationOptions );

		Assert.Equal( expectedResult.OriginalString, result.Value.OriginalString );
	}

	[Fact]
	public void WithUriCreationOptionsAndInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		UriCreationOptions creationOptions = new();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = StringConversionExtensions.ToUri( argInfo, creationOptions );
		} );

		string expectedMessage = "Value must be a uri.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithUriCreationOptionsAndInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";
		UriCreationOptions creationOptions = new();

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = StringConversionExtensions.ToUri( argInfo, creationOptions );
		} );

		Assert.StartsWith( message, exception.Message );
	}

#endif

}
