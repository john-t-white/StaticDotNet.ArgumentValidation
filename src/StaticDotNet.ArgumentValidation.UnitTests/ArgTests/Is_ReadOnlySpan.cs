#if NETCOREAPP3_1_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ArgTests;

public sealed class Is_ReadOnlySpan {

	[Fact]
	public void ReturnsCorrectly() {

		ReadOnlySpan<char> value = "Value";

		ReadOnlySpanArgInfo<char> result = Arg.Is( value );

		Assert.Equal( value.ToString(), result.Value.ToString() );
		Assert.Equal( nameof( value ), result.Name );
		Assert.Null( result.Message );
	}

	[Fact]
	public void WithNameAndMessageReturnsCorrectly() {

		ReadOnlySpan<char> value = "Value";
		string name = "Name";
		string message = "Message";

		ReadOnlySpanArgInfo<char> result = Arg.Is( value, name, message );

		Assert.Equal( value.ToString(), result.Value.ToString() );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}
}

#endif
