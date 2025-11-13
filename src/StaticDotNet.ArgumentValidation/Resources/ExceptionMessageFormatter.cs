using StaticDotNet.ArgumentValidation.Infrastructure;
using System.Globalization;
using System.Text;

namespace StaticDotNet.ArgumentValidation.Resources;

internal static class ExceptionMessageFormatter {

#if( NETSTANDARD2_0 || NETSTANDARD2_1 )

	internal static string Format<TArg1>( string format, TArg1? arg1 )
		=> string.Format( CultureInfo.InvariantCulture, format, Stringify.Value( arg1 ) );

	internal static string Format<TArg1, TArg2>( string format, TArg1? arg1, TArg2? arg2 )
		=> string.Format( CultureInfo.InvariantCulture, format, Stringify.Value( arg1 ), Stringify.Value( arg2 ) );

	internal static string Format<TArg1, TArg2, TArg3>( string format, TArg1? arg1, TArg2? arg2, TArg3? arg3 )
		=> string.Format( CultureInfo.InvariantCulture, format, Stringify.Value( arg1 ), Stringify.Value( arg2 ), Stringify.Value( arg3 ) );

	internal static string Format<TArg1, TArg2, TArg3, TArg4>( string format, TArg1? arg1, TArg2? arg2, TArg3? arg3, TArg4? arg4 )
		=> string.Format( CultureInfo.InvariantCulture, format, Stringify.Value( arg1 ), Stringify.Value( arg2 ), Stringify.Value( arg3 ), Stringify.Value( arg4 ) );

#else

#if NET8_0
	private static readonly object _lockObject = new();
#else
	private static readonly Lock _lockObject = new();
#endif
	private static readonly Dictionary<string, CompositeFormat> _compositeFormats = [];

	private static CompositeFormat GetCompositeFormat( string format ) {
		if( !ExceptionMessageFormatter._compositeFormats.TryGetValue( format, out CompositeFormat? compositeFormat ) ) {
			lock( ExceptionMessageFormatter._lockObject ) {
				if( !ExceptionMessageFormatter._compositeFormats.TryGetValue( format, out compositeFormat ) ) {
					compositeFormat = CompositeFormat.Parse( format );
					ExceptionMessageFormatter._compositeFormats.Add( format, compositeFormat );
				}
			}
		}

		return compositeFormat;
	}

	internal static string Format<TArg1>( string format, TArg1? arg1 )
		=> string.Format( CultureInfo.InvariantCulture, ExceptionMessageFormatter.GetCompositeFormat( format ), Stringify.Value( arg1 ) );

	internal static string Format<TArg1, TArg2>( string format, TArg1? arg1, TArg2? arg2 )
		=> string.Format( CultureInfo.InvariantCulture, ExceptionMessageFormatter.GetCompositeFormat( format ), Stringify.Value( arg1 ), Stringify.Value( arg2 ) );

	internal static string Format<TArg1, TArg2, TArg3>( string format, TArg1? arg1, TArg2? arg2, TArg3? arg3 )
		=> string.Format( CultureInfo.InvariantCulture, ExceptionMessageFormatter.GetCompositeFormat( format ), Stringify.Value( arg1 ), Stringify.Value( arg2 ), Stringify.Value( arg3 ) );

	internal static string Format<TArg1, TArg2, TArg3, TArg4>( string format, TArg1? arg1, TArg2? arg2, TArg3? arg3, TArg4? arg4 )
		=> string.Format( CultureInfo.InvariantCulture, ExceptionMessageFormatter.GetCompositeFormat( format ), Stringify.Value( arg1 ), Stringify.Value( arg2 ), Stringify.Value( arg3 ), Stringify.Value( arg4 ) );

#endif
}
