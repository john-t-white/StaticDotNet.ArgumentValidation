using System.Collections.ObjectModel;

namespace StaticDotNet.ArgumentValidation.UnitTests.EnumerableExtensionsTests;

public sealed class GetLength {

	[Fact]
	public void StringValueReturnsCorrectly() {

		string value = "12345";
		int maxEnumeratorIterations = 0;

		int result = EnumerableExtensions.GetLength( value, maxEnumeratorIterations );

		Assert.Equal( value.Length, result );
	}

	[Fact]
	public void ArrayValueReturnsCorrectly() {

		Array value = new int[] { 1, 2, 3 };
		int maxEnumeratorIterations = 0;

		int result = EnumerableExtensions.GetLength( value, maxEnumeratorIterations );

		Assert.Equal( value.Length, result );
	}

	[Fact]
	public void ClassArrayValueReturnsCorrectly() {

		object[] value = new object[] { new(), new(), new() };
		int maxEnumeratorIterations = 0;

		int result = EnumerableExtensions.GetLength( value, maxEnumeratorIterations );

		Assert.Equal( value.Length, result );
	}

	[Fact]
	public void StructArrayValueReturnsCorrectly() {

		int[] value = new int[] { 1, 2, 3 };
		int maxEnumeratorIterations = 0;

		int result = EnumerableExtensions.GetLength( value, maxEnumeratorIterations );

		Assert.Equal( value.Length, result );
	}

	[Fact]
	public void IListValueReturnsCorrectly() {

		IList<int> value = new List<int>() { 1, 2, 3 };
		int maxEnumeratorIterations = 0;

		int result = EnumerableExtensions.GetLength( value, maxEnumeratorIterations );

		Assert.Equal( value.Count, result );
	}

	[Fact]
	public void IDictionaryValueReturnsCorrectly() {

		IDictionary<string, object> value = new Dictionary<string, object>() {
			{ "1", new() },
			{ "2", new() },
			{ "3", new() }
		};
		int maxEnumeratorIterations = 0;

		int result = EnumerableExtensions.GetLength( value, maxEnumeratorIterations );

		Assert.Equal( value.Count, result );
	}

	[Fact]
	public void ICollectionValueReturnsCorrectly() {

		ICollection<int> value = new Collection<int>() { 1, 2, 3 };
		int maxEnumeratorIterations = 0;

		int result = EnumerableExtensions.GetLength( value, maxEnumeratorIterations );

		Assert.Equal( value.Count, result );
	}

	[Fact]
	public void IReadOnlyCollectionValueReturnsCorrectly() {

		IReadOnlyCollection<int> value = ( new List<int>() { 1, 2, 3 } ).AsReadOnly();
		int maxEnumeratorIterations = 0;

		int result = EnumerableExtensions.GetLength( value, maxEnumeratorIterations );

		Assert.Equal( value.Count, result );
	}

	[Fact]
	public void IEnumerableReturnsCorrectly() {

		int[] enumerable = new int[] { 1, 2, 3 };
		EnumerableTestClass value = new( enumerable );
		int maxEnumeratorIterations = enumerable.Length;

		int result = EnumerableExtensions.GetLength( value, maxEnumeratorIterations );

		Assert.Equal( enumerable.Length, result );
	}

	[Fact]
	public void EnumeratorExceedsMaxEnumeratorIterationsReturnsCorrectly() {

		int[] enumerable = new int[] { 1, 2, 3 };
		EnumerableTestClass value = new( enumerable );
		int maxEnumeratorIterations = 1;

		int result = EnumerableExtensions.GetLength( value, maxEnumeratorIterations );

		Assert.Equal( maxEnumeratorIterations, result );
	}
}
