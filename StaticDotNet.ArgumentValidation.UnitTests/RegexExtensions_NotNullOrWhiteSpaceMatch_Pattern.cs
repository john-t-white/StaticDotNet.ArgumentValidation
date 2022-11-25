using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public partial class RegexExtensions_NotNullOrWhiteSpaceMatch_Pattern {

	[Fact]
	public void ReturnsCorrectly() {

		string value = "1";
		string pattern = @"\d";

		string result = Argument.Is.NotNullOrWhiteSpaceMatch( value, pattern );

		Assert.Equal( value, result );
	}
}
