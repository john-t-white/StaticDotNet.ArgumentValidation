﻿#if NETCOREAPP3_1_OR_GREATER

using System.Globalization;

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanCharParsingExtensionsTests;

public sealed class ParseTimeSpan {

	[Fact]
	public void ReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3 );
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );

		ArgInfo<TimeSpan> result = ReadOnlySpanCharParsingExtensions.ParseTimeSpan( argInfo );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithProviderReturnsCorrectly() {

		TimeSpan expectedResult = new( 1, 2, 3 );
		ReadOnlySpanArgInfo<char> argInfo = new( expectedResult.ToString(), null, null );
		IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;

		ArgInfo<TimeSpan> result = ReadOnlySpanCharParsingExtensions.ParseTimeSpan( argInfo, provider );

		Assert.Equal( expectedResult, result.Value );
	}

	[Fact]
	public void WithInvalidValueThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, null );
			_ = ReadOnlySpanCharParsingExtensions.ParseTimeSpan( argInfo );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must be parsable to System.TimeSpan.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithInvalidValueAndMessageThrowsArgumentException() {

		string argumentValue = "Not valid";
		string name = "Name";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {

			ReadOnlySpanArgInfo<char> argInfo = new( argumentValue, name, message );
			_ = ReadOnlySpanCharParsingExtensions.ParseTimeSpan( argInfo );
		} );

		Assert.StartsWith( message, exception.Message );
	}
}

#endif
