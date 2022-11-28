namespace StaticDotNet.ArgumentValidation.UnitTests;

public sealed class Arg_Is {

	[Fact]
	public void ReturnsSameInstance() {
		Arg result1 = Arg.Is;
		Arg result2 = Arg.Is;

		Assert.Same( result1, result2 );
	}
}