namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class NotEmpty {

    [Fact]
    public void ReturnsCorrectly() {

        ArgInfo<List<string>> argInfo = new( new() { "A" }, null, null );

        ArgInfo<List<string>> result = EnumerableExtensions.NotEmpty( argInfo );

        ArgInfoAssertions.Equal( argInfo, result );
    }

    [Fact]
    public void WithEmptyValueThrowsArgumentException() {

        List<string> argumentValue = new();
        string name = "Name";

        ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
            ArgInfo<List<string>> argInfo = new( argumentValue, name, null );
            _ = EnumerableExtensions.NotEmpty( argInfo );
        } );

        string expectedMessage = "Value cannot be empty.";

        Assert.StartsWith( expectedMessage, exception.Message );
    }

    [Fact]
    public void WithInvalidValueAndMessageThrowsArgumentException() {

        List<string> argumentValue = new();
        string name = "Name";
        string message = "Message";

        ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
            ArgInfo<List<string>> argInfo = new( argumentValue, name, message );
            _ = EnumerableExtensions.NotEmpty( argInfo );
        } );

        Assert.StartsWith( message, exception.Message );
    }
}
