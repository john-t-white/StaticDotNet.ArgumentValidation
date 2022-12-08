using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public class EnumerableTestClass
		: IEnumerable {

	private readonly IEnumerable _enumerable;

	public EnumerableTestClass( IEnumerable enumerable ) {

		_enumerable = enumerable;
	}

	public IEnumerator GetEnumerator() => _enumerable.GetEnumerator();
}
