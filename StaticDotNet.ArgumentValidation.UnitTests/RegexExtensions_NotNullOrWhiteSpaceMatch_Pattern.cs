using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public class RegexExtensions_NotNullOrWhiteSpaceMatch_Pattern {

	[Fact]
	public void WithValueReturnsCorrectly() {

		string? value = "1";
		string pattern = @"\d";

		string result = Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotMatchThrowsArgumentException() {

		string value = "a";
		string pattern = @"\d";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern ) );

		string expectedMessage = $"Value must match the regex {pattern}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string? value = null;
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string? value = string.Empty;
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern ) );
	}

	[Fact]
	public void WithWhiteSpaceValueThrowsArgumentException() {

		string? value = " ";
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern ) );
	}

	[Fact]
	public void WithNullPatternThrowsArgumentException() {

		string value = "1";
		string pattern = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern ) );

		string expectedMessage = $"Value must match the regex <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndOutMatchAndOutMatchReturnsCorrectly() {

		string? value = "1";
		string pattern = @"\d";

		string result = Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match match );

		Assert.Equal( value, result );
		Assert.NotNull( match );
	}

	[Fact]
	public void WithValueNotMatchAndOutMatchThrowsArgumentException() {

		string value = "a";
		string pattern = @"\d";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _ ) );

		string expectedMessage = $"Value must match the regex {pattern}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndOutMatchThrowsArgumentNullException() {

		string? value = null;
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _ ) );
	}

	[Fact]
	public void WithEmptyValueAndOutMatchThrowsArgumentException() {

		string? value = string.Empty;
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _ ) );
	}

	[Fact]
	public void WithWhiteSpaceValueAndOutMatchThrowsArgumentException() {

		string? value = " ";
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _ ) );
	}

	[Fact]
	public void WithNullPatternAndOutMatchThrowsArgumentException() {

		string value = "1";
		string pattern = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _ ) );

		string expectedMessage = $"Value must match the regex <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}
}
