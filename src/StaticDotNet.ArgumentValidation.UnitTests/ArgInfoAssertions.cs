namespace StaticDotNet.ArgumentValidation.UnitTests;

public static class ArgInfoAssertions {

	public static void Equal<T>( ArgInfo<T> expected, ArgInfo<T> actual )
		where T : notnull {

		Assert.Equal( expected.Value, actual.Value );
		Assert.Equal( expected.Name, actual.Name );
		Assert.Equal( expected.Message, actual.Message );
	}

#if NET6_0_OR_GREATER

	public static void Equal( ReadOnlySpanArgInfo<char> expected, ReadOnlySpanArgInfo<char> actual ) {

		Assert.True( expected.Value == actual.Value );
		Assert.Equal( expected.Name, actual.Name );
		Assert.Equal( expected.Message, actual.Message );
	}

	public static void Equal( SpanArgInfo<char> expected, SpanArgInfo<char> actual ) {

		Assert.True( expected.Value == actual.Value );
		Assert.Equal( expected.Name, actual.Name );
		Assert.Equal( expected.Message, actual.Message );
	}

#endif

}
