using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed partial class RegexExtensions_Matches_Regex {

#if NET7_0_OR_GREATER
	[GeneratedRegex( @"\d" )]
	private static partial Regex DigitRegex();

#else

	private static Regex DigitRegex() => new( @"\d" );

#endif

	[Fact]
	public void ReturnsCorrectly() {

		string value = "1";
		Regex regex = DigitRegex();

		ArgInfo<string> argInfo = new( value, "Name", null );

		ArgInfo<string> result = argInfo.Matches( regex );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		string? value = null;
		Regex regex = DigitRegex();

		ArgInfo<string?> argInfo = new( value, null, null );

		ArgInfo<string?> result = argInfo.Matches( regex );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotMatchThrowsArgumentException() {

		string value = "a";
		string name = "Name";
		Regex regex = DigitRegex();

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.Matches( DigitRegex() );
		} );

		string expectedMessage = $"Value must match the regex {regex}.";

		Assert.StartsWith( expectedMessage, excetion.Message );
	}

	[Fact]
	public void WithValueNotMatchAndMessageThrowsArgumentException() {

		string value = "a";
		string name = "Name";
		string message = "Message";
		Regex regex = DigitRegex();

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.Matches( regex );
		} );

		Assert.StartsWith( message, excetion.Message );
	}

	[Fact]
	public void WithOutMatchReturnsCorrectly() {

		string value = "1";
		Regex regex = DigitRegex();

		ArgInfo<string> argInfo = new( value, "Name", null );

		ArgInfo<string> result = argInfo.Matches( regex, out Match match );

		ArgInfoAssertions.Equal( argInfo, result );
		Assert.NotSame( Match.Empty, match );
	}

	[Fact]
	public void WithOutMatchWithNullValueReturnsCorrectly() {

		string? value = null;
		Regex regex = DigitRegex();

		ArgInfo<string?> argInfo = new( value, null, null );

		ArgInfo<string?> result = argInfo.Matches( regex, out Match match );

		ArgInfoAssertions.Equal( argInfo, result );
		Assert.Same( Match.Empty, match );
	}

	[Fact]
	public void WithOutMatchWithValueNotMatchThrowsArgumentException() {

		string value = "a";
		string name = "Name";
		Regex regex = DigitRegex();

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.Matches( regex, out Match _ );
		} );

		string expectedMessage = $"Value must match the regex {regex}.";

		Assert.StartsWith( expectedMessage, excetion.Message );
	}

	[Fact]
	public void WithOutMatchWithValueNotMatchAndMessageThrowsArgumentException() {

		string value = "a";
		string name = "Name";
		string message = "Message";
		Regex regex = DigitRegex();

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.Matches( regex, out Match _ );
		} );

		Assert.StartsWith( message, excetion.Message );
	}
}
