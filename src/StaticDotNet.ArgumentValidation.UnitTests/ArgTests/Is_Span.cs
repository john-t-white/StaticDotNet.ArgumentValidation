#if NET6_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ArgTests;

public sealed class Is_Span {

	[Fact]
	public void ReturnsCorrectly() {

		Span<char> value = new( "Value".ToCharArray() );

		SpanArgInfo<char> result = Arg.Is( value );

		Assert.Equal( value.ToString(), result.Value.ToString() );
		Assert.Equal( nameof( value ), result.Name );
		Assert.Null( result.Message );
	}

	[Fact]
	public void WithNameAndMessageReturnsCorrectly() {

		Span<char> value = new( "Value".ToCharArray() );
		string name = "Name";
		string message = "Message";

		SpanArgInfo<char> result = Arg.Is( value, name, message );

		Assert.Equal( value.ToString(), result.Value.ToString() );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}
}

#endif
