using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.UnitTests.RegexExtensionsTests;

public sealed partial class Matches_Regex {

#if NET7_0_OR_GREATER
	[GeneratedRegex( @"\d" )]
	private static partial Regex DigitRegex();

#else

	private static Regex DigitRegex() => new( @"\d" );

#endif

	[Fact]
	public void ReturnsCorrectly() {

		string argumentValue = "1";
		Regex regex = DigitRegex();

		ArgInfo<string> argInfo = new( argumentValue, "Name", null );

		ArgInfo<string> result = argInfo.Matches( regex );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotMatchThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		Regex regex = DigitRegex();

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.Matches( regex );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must match the regex \"{regex}\".";

		Assert.StartsWith( expectedMessage, excetion.Message );
	}

	[Fact]
	public void WithNullRegexThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		Regex regex = null!;

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.Matches( regex );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must match the regex <null>.";

		Assert.StartsWith( expectedMessage, excetion.Message );
	}

	[Fact]
	public void WithValueNotMatchAndMessageThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		string message = "Message";
		Regex regex = DigitRegex();

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.Matches( regex );
		} );

		Assert.StartsWith( message, excetion.Message );
	}

	[Fact]
	public void WithOutMatchReturnsCorrectly() {

		string argumentValue = "1";
		Regex regex = DigitRegex();

		ArgInfo<string> argInfo = new( argumentValue, "Name", null );

		ArgInfo<string> result = argInfo.Matches( regex, out Match match );

		ArgInfoAssertions.Equal( argInfo, result );
		Assert.NotSame( Match.Empty, match );
	}

	[Fact]
	public void WithOutMatchWithValueNotMatchThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		Regex regex = DigitRegex();

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.Matches( regex, out Match _ );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must match the regex \"{regex}\".";

		Assert.StartsWith( expectedMessage, excetion.Message );
	}

	[Fact]
	public void WithOutMatchWithNullRegexThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		Regex regex = null!;

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.Matches( regex, out Match _ );
		} );

		string expectedMessage = $"Value \"{argumentValue}\" must match the regex <null>.";

		Assert.StartsWith( expectedMessage, excetion.Message );
	}

	[Fact]
	public void WithOutMatchWithValueNotMatchAndMessageThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		string message = "Message";
		Regex regex = DigitRegex();

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.Matches( regex, out Match _ );
		} );

		Assert.StartsWith( message, excetion.Message );
	}
}
