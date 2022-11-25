using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public partial class RegexExtensions_NotNullOrWhiteSpaceMatch_Regex {

#if NET7_0_OR_GREATER
	[GeneratedRegex(@"\d")]
	public static partial Regex TestRegex();
#else
	public static Regex TestRegex() => new( @"\d" );
#endif

	[Fact]
	public void WithValueReturnsCorrectly() {

		string? value = "1";
		Regex regex = TestRegex();

		string result = Argument.Is.NotNullOrWhiteSpaceMatch( value, regex );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotMatchThrowsArgumentException() {

		string value = "a";
		Regex regex = TestRegex();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, regex ) );

		string expectedMessage = $"Value must match the regex {regex}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string? value = null;
		Regex regex = TestRegex();

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, regex ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string? value = string.Empty;
		Regex regex = TestRegex();

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, regex ) );
	}

	[Fact]
	public void WithWhiteSpaceValueThrowsArgumentException() {

		string? value = " ";
		Regex regex = TestRegex();

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, regex ) );
	}

	[Fact]
	public void WithNullRegexThrowsArgumentException() {

		string value = "1";
		Regex regex = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, regex ) );

		string expectedMessage = $"Value must match the regex <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueAndOutMatchAndOutMatchReturnsCorrectly() {

		string? value = "1";
		Regex regex = TestRegex();

		string result = Argument.Is.NotNullOrWhiteSpaceMatch( value, regex, out Match match );

		Assert.Equal( value, result );
		Assert.NotNull( match );
	}

	[Fact]
	public void WithValueNotMatchAndOutMatchThrowsArgumentException() {

		string value = "a";
		Regex regex = TestRegex();

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, regex, out Match _ ) );

		string expectedMessage = $"Value must match the regex {regex}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndOutMatchThrowsArgumentNullException() {

		string? value = null;
		Regex regex = TestRegex();

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, regex, out Match _ ) );
	}

	[Fact]
	public void WithEmptyValueAndOutMatchThrowsArgumentException() {

		string? value = string.Empty;
		Regex regex = TestRegex();

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, regex, out Match _ ) );
	}

	[Fact]
	public void WithWhiteSpaceValueAndOutMatchThrowsArgumentException() {

		string? value = " ";
		Regex regex = TestRegex();

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, regex, out Match _ ) );
	}

	[Fact]
	public void WithNullPatternAndOutMatchThrowsArgumentException() {

		string value = "1";
		Regex regex = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Argument.Is.NotNullOrWhiteSpaceMatch( value, regex, out Match _ ) );

		string expectedMessage = $"Value must match the regex <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}
}
