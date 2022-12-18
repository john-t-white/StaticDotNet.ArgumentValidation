#if NET6_0_OR_GREATER

namespace StaticDotNet.ArgumentValidation.UnitTests.ReadOnlySpanArgInfoTests;

public sealed class Ctor {

	[Fact]
	public void InitializesCorrectly() {

		string value = "Value";
		string name = "Name";
		string message = "Message";

		ReadOnlySpanArgInfo<char> result = new( value, name, message );

		Assert.Equal( value, result.Value.ToString() );
		Assert.Equal( name, result.Name );
		Assert.Equal( message, result.Message );
	}
}

#endif
