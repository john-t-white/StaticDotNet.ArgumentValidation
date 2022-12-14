using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.UnitTests.RegexExtensionsTests;

public sealed class Matches_Pattern {

	[Fact]
	public void ReturnsCorrectly() {

		string argumentValue = "1";
		string pattern = @"\d";

		ArgInfo<string> argInfo = new( argumentValue, "Name", null );

		ArgInfo<string> result = argInfo.Matches( pattern );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithOptionsAndMatchTimeOutReturnsCorrectly() {

		string argumentValue = "A";
		string pattern = "a";
		RegexOptions options = RegexOptions.IgnoreCase;
		var matchTimeout = TimeSpan.FromSeconds( 5 );

		ArgInfo<string> argInfo = new( argumentValue, null, null );

		ArgInfo<string> result = argInfo.Matches( pattern, options, matchTimeout );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotMatchThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		string pattern = @"\d";

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.Matches( pattern );
		} );

		string expectedMessage = $"Value must match the regex {pattern}.";

		Assert.StartsWith( expectedMessage, excetion.Message );
	}

	[Fact]
	public void WithValueNotMatchAndMessageThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		string message = "Message";
		string pattern = @"\d";

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.Matches( pattern );
		} );

		Assert.StartsWith( message, excetion.Message );
	}

	[Fact]
	public void WithOutMatchReturnsCorrectly() {

		string argumentValue = "1";
		string pattern = @"\d";

		ArgInfo<string> argInfo = new( argumentValue, "Name", null );

		ArgInfo<string> result = argInfo.Matches( pattern, out Match match );

		ArgInfoAssertions.Equal( argInfo, result );
		Assert.NotSame( Match.Empty, match );
	}

	[Fact]
	public void WithOutMatchWithOptionsAndMatchTimeOutReturnsCorrectly() {

		string argumentValue = "A";
		string pattern = "a";
		RegexOptions options = RegexOptions.IgnoreCase;
		var matchTimeout = TimeSpan.FromSeconds( 5 );

		ArgInfo<string> argInfo = new( argumentValue, null, null );

		ArgInfo<string> result = argInfo.Matches( pattern, out Match _, options, matchTimeout );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithOutMatchWithValueNotMatchThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		string pattern = @"\d";

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, null );
			_ = argInfo.Matches( pattern, out Match _ );
		} );

		string expectedMessage = $"Value must match the regex {pattern}.";

		Assert.StartsWith( expectedMessage, excetion.Message );
	}

	[Fact]
	public void WithOutMatchWithValueNotMatchAndMessageThrowsArgumentException() {

		string argumentValue = "a";
		string name = "Name";
		string message = "Message";
		string pattern = @"\d";

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( argumentValue, name, message );
			_ = argInfo.Matches( pattern, out Match _ );
		} );

		Assert.StartsWith( message, excetion.Message );
	}
}
