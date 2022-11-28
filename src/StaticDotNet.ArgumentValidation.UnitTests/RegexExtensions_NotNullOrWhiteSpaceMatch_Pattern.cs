using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public class RegexExtensions_NotNullOrWhiteSpaceMatch_Pattern {

	[Fact]
	public void WithValueReturnsCorrectly() {

		string? value = "1";
		string pattern = @"\d";

		string result = Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithValueNotMatchThrowsArgumentException() {

		string value = "a";
		string pattern = @"\d";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern ) );

		string expectedMessage = $"Value must match the regex {pattern}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueThrowsArgumentNullException() {

		string? value = null;
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern ) );
	}

	[Fact]
	public void WithEmptyValueThrowsArgumentException() {

		string? value = string.Empty;
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern ) );
	}

	[Fact]
	public void WithWhiteSpaceValueThrowsArgumentException() {

		string? value = " ";
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern ) );
	}

	[Fact]
	public void WithNullPatternThrowsArgumentException() {

		string value = "1";
		string pattern = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern ) );

		string expectedMessage = $"Value must match the regex <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotMatchAndNameThrowsArgumentException() {

		string value = "a";
		string pattern = @"\d";
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern, name ) );
	}

	[Fact]
	public void WithValueNotMatchAndMessageThrowsArgumentException() {

		string value = "a";
		string pattern = @"\d";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}

	[Fact]
	public void WithValueAndOutMatchAndOutMatchReturnsCorrectly() {

		string? value = "1";
		string pattern = @"\d";

		string result = Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match match );

		Assert.Equal( value, result );
		Assert.NotNull( match );
	}

	[Fact]
	public void WithValueNotMatchAndOutMatchThrowsArgumentException() {

		string value = "a";
		string pattern = @"\d";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _ ) );

		string expectedMessage = $"Value must match the regex {pattern}.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithNullValueAndOutMatchThrowsArgumentNullException() {

		string? value = null;
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentNullException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _ ) );
	}

	[Fact]
	public void WithEmptyValueAndOutMatchThrowsArgumentException() {

		string? value = string.Empty;
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _ ) );
	}

	[Fact]
	public void WithWhiteSpaceValueAndOutMatchThrowsArgumentException() {

		string? value = " ";
		string pattern = @"\d";

		_ = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _ ) );
	}

	[Fact]
	public void WithNullPatternAndOutMatchThrowsArgumentException() {

		string value = "1";
		string pattern = null!;

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _ ) );

		string expectedMessage = $"Value must match the regex <null>.";

		Assert.StartsWith( expectedMessage, exception.Message );
	}

	[Fact]
	public void WithValueNotMatchAndNameAndOutMatchThrowsArgumentException() {

		string value = "a";
		string pattern = @"\d";
		string name = "Name";

		_ = Assert.Throws<ArgumentException>( name, () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _, name ) );
	}

	[Fact]
	public void WithValueNotMatchAndMessageAndOutMatchThrowsArgumentException() {

		string value = "a";
		string pattern = @"\d";
		string message = "Message";

		ArgumentException exception = Assert.Throws<ArgumentException>( nameof( value ), () => Arg.Is.NotNullOrWhiteSpaceMatch( value, pattern, out Match _, message: message ) );

		Assert.StartsWith( message, exception.Message );
	}
}
