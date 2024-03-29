﻿namespace StaticDotNet.ArgumentValidation;

internal static class ArgumentNullExceptionFactory {

	internal static ArgumentNullException Create( string? name, string? message )
		=> message is null ? new ArgumentNullException( name ) : new ArgumentNullException( name, message );
}
