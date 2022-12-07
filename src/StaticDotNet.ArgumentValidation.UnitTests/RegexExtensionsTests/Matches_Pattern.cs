using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.UnitTests.RegexExtensionsTests;

public sealed class Matches_Pattern {

	[Fact]
	public void ReturnsCorrectly() {

		string value = "1";
		string pattern = @"\d";

		ArgInfo<string> argInfo = new( value, "Name", null );

		ArgInfo<string> result = argInfo.Matches( pattern );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithNullValueReturnsCorrectly() {

		string? value = null;
		string pattern = @"/d";

		ArgInfo<string?> argInfo = new( value, null, null );

		ArgInfo<string?> result = argInfo.Matches( pattern );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithOptionsAndMatchTimeOutReturnsCorrectly() {

		string value = "A";
		string pattern = "a";
		RegexOptions options = RegexOptions.IgnoreCase;
		var matchTimeout = TimeSpan.FromSeconds( 5 );

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = argInfo.Matches( pattern, options, matchTimeout );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithValueNotMatchThrowsArgumentException() {

		string value = "a";
		string name = "Name";
		string pattern = @"\d";

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.Matches( pattern );
		} );

		string expectedMessage = $"Value must match the regex {pattern}.";

		Assert.StartsWith( expectedMessage, excetion.Message );
	}

	[Fact]
	public void WithValueNotMatchAndMessageThrowsArgumentException() {

		string value = "a";
		string name = "Name";
		string message = "Message";
		string pattern = @"\d";

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.Matches( pattern );
		} );

		Assert.StartsWith( message, excetion.Message );
	}

	[Fact]
	public void WithOutMatchReturnsCorrectly() {

		string value = "1";
		string pattern = @"\d";

		ArgInfo<string> argInfo = new( value, "Name", null );

		ArgInfo<string> result = argInfo.Matches( pattern, out Match match );

		ArgInfoAssertions.Equal( argInfo, result );
		Assert.NotSame( Match.Empty, match );
	}

	[Fact]
	public void WithOutMatchWithNullValueReturnsCorrectly() {

		string? value = null;
		string pattern = @"/d";

		ArgInfo<string?> argInfo = new( value, null, null );

		ArgInfo<string?> result = argInfo.Matches( pattern, out Match match );

		ArgInfoAssertions.Equal( argInfo, result );
		Assert.Same( Match.Empty, match );
	}

	[Fact]
	public void WithOutMatchWithOptionsAndMatchTimeOutReturnsCorrectly() {

		string value = "A";
		string pattern = "a";
		RegexOptions options = RegexOptions.IgnoreCase;
		var matchTimeout = TimeSpan.FromSeconds( 5 );

		ArgInfo<string> argInfo = new( value, null, null );

		ArgInfo<string> result = argInfo.Matches( pattern, out Match _, options, matchTimeout );

		ArgInfoAssertions.Equal( argInfo, result );
	}

	[Fact]
	public void WithOutMatchWithValueNotMatchThrowsArgumentException() {

		string value = "a";
		string name = "Name";
		string pattern = @"\d";

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, null );
			_ = argInfo.Matches( pattern, out Match _ );
		} );

		string expectedMessage = $"Value must match the regex {pattern}.";

		Assert.StartsWith( expectedMessage, excetion.Message );
	}

	[Fact]
	public void WithOutMatchWithValueNotMatchAndMessageThrowsArgumentException() {

		string value = "a";
		string name = "Name";
		string message = "Message";
		string pattern = @"\d";

		ArgumentException excetion = Assert.Throws<ArgumentException>( name, () => {
			ArgInfo<string> argInfo = new( value, name, message );
			_ = argInfo.Matches( pattern, out Match _ );
		} );

		Assert.StartsWith( message, excetion.Message );
	}
}
