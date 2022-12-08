using System.Collections;

namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public class EnumerableTestClass
		: IEnumerable {

	private readonly IEnumerable _enumerable;

	public EnumerableTestClass( IEnumerable enumerable ) {

		_enumerable = enumerable;
	}

	public IEnumerator GetEnumerator() => _enumerable.GetEnumerator();
}
