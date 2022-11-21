namespace StaticDotNet.ArgumentValidation.UnitTests;

public class Argument_Is
{
	[Fact]
	public void ReturnsSameInstance()
	{
		Argument result1 = Argument.Is;
		Argument result2 = Argument.Is;

		Assert.Same( result1, result2 );
	}
}