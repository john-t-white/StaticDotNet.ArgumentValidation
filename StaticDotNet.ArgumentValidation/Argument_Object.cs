namespace StaticDotNet.ArgumentValidation;

public static class Argument_Object {

	public static T NotNull<T>( this Argument _,
								[NotNull] T? value,
								[CallerArgumentExpression( "value" )] string? name = null,
								string? message = null )
	{
		if (value != null) return value;

		ArgumentNullException exception = message == null
			? new ArgumentNullException( name )
			: new ArgumentNullException( name, message );

		throw exception;
	}

	public static T? Null<T>( this Argument _,
							  T? value,
							  [CallerArgumentExpression( "value" )] string? name = null,
							  string? message = null ) =>
		value != null ? throw new ArgumentException( message ?? "Value must be null.", name ) : value;
}