namespace StaticDotNet.ArgumentValidation.UnitTests;

public static class ArgInfoAssertions {

	public static void Equal<T>( ArgInfo<T> expected, ArgInfo<T> actual )
		where T : notnull {

		Assert.Equal( expected.Value, actual.Value );
		Assert.Equal( expected.Name, actual.Name );
		Assert.Equal( expected.Message, actual.Message );
	}
}
