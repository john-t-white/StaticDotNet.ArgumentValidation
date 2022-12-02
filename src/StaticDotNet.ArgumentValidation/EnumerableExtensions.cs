using System;
using System.Collections;
using System.Text;
using System.Xml.Linq;

namespace StaticDotNet.ArgumentValidation;

public static class EnumerableExtensions {

	public static ref readonly ArgInfo<T> NotEmpty<T>( in this ArgInfo<T> argInfo )
		where T : IEnumerable? {

		switch( argInfo.Value ) {

			case null:
				return ref argInfo;

			case string value:
				if( value.Length > 0 ) {
					return ref argInfo;
				}

				break;

			case Array value:
				if( value.Length > 0 ) {
					return ref argInfo;
				}

				break;

			case IList value:
				if( value.Count > 0 ) {
					return ref argInfo;
				}

				break;

			case IDictionary value:
				if( value.Count > 0 ) {
					return ref argInfo;
				}

				break;

			case ICollection value:
				if( value.Count > 0 ) {
					return ref argInfo;
				}

				break;

			default:
				IEnumerator enumerator = argInfo.Value.GetEnumerator();
				if( enumerator.MoveNext() ) {

					( enumerator as IDisposable )?.Dispose();
					return ref argInfo;
				}

				break;
		}

		throw new ArgumentException( argInfo.Message ?? Constants.VALUE_CANNOT_BE_EMPTY, argInfo.Name );
	}
}
