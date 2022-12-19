namespace StaticDotNet.ArgumentValidation.UnitTests;

public static class ArgInfoAssertions {

	public static void Equal<T>( ArgInfo<T> expected, ArgInfo<T> actual )
		where T : notnull {

		Assert.Equal( expected.Value, actual.Value );
		Assert.Equal( expected.Name, actual.Name );
		Assert.Equal( expected.Message, actual.Message );
	}

#if NETCOREAPP3_1_OR_GREATER

	public static void Equal<T>( ReadOnlySpanArgInfo<T> expected, ReadOnlySpanArgInfo<T> actual ) {

		Assert.True( expected.Value == actual.Value );
		Assert.Equal( expected.Name, actual.Name );
		Assert.Equal( expected.Message, actual.Message );
	}

	public static void Equal<T>( SpanArgInfo<T> expected, SpanArgInfo<T> actual ) {

		Assert.True( expected.Value == actual.Value );
		Assert.Equal( expected.Name, actual.Name );
		Assert.Equal( expected.Message, actual.Message );
	}

#endif

}
