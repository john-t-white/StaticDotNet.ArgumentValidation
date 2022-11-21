namespace StaticDotNet.ArgumentValidation;

public sealed class Argument {

	private Argument()
	{
	}

	public static readonly Argument Is = new();
}