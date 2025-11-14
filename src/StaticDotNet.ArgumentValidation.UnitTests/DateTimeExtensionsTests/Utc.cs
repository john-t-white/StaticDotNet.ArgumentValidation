namespace StaticDotNet.ArgumentValidation.UnitTests.DateTimeExtensionsTests;

public sealed class Utc {

    [Fact]
    public void ReturnsCorrectly() {

        ArgInfo<DateTime> argInfo = new( new( 2000, DateTimeKind.Utc ), null, null );

        ArgInfo<DateTime> result = DateTimeExtensions.Utc( argInfo );

        ArgInfoAssertions.Equal( argInfo, result );
    }

    [Fact]
    public void WithNotUtcThrowsArgumentException() {

        DateTime argumentValue = new( 2000, DateTimeKind.Unspecified );
        string name = "Name";

        ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
            ArgInfo<DateTime> argInfo = new( argumentValue, name, null );
            _ = DateTimeExtensions.Utc( argInfo );
        } );

        string expectedMessage = "Value must have DateTimeKind.Utc.";
        Assert.StartsWith( expectedMessage, exception.Message );
    }

    [Fact]
    public void WithNotUtcAndMessageThrowsArgumentException() {

        DateTime argumentValue = new( 2000, DateTimeKind.Unspecified );
        string name = "Name";
        string message = "Message";

        ArgumentException exception = Assert.Throws<ArgumentException>( name, () => {
            ArgInfo<DateTime> argInfo = new( argumentValue, name, message );
            _ = DateTimeExtensions.Utc( argInfo );
        } );

        Assert.StartsWith( message, exception.Message );
    }
}
