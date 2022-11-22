namespace StaticDotNet.ArgumentValidation;

public static class Argument_Boolean {

	private const string VALUE_MUST_BE_TRUE = "Value must be true.";
	private const string VALUE_MUST_BE_FALSE = "Value must be false.";

	public static bool True( this Argument _, bool value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value != true ? throw new ArgumentException( message ?? VALUE_MUST_BE_TRUE, name ) : true;

	[return: NotNullIfNotNull( nameof( value ) )]
	public static bool? True( this Argument _, bool? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value.HasValue && value != true ? throw new ArgumentException( message ?? VALUE_MUST_BE_TRUE, name ) : value;

	public static bool NotNullTrue( this Argument argument, [NotNull] bool? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.True( argument.NotNull( value, name, message ), name, message );

	public static bool False( this Argument _, bool value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value != false ? throw new ArgumentException( message ?? VALUE_MUST_BE_FALSE, name ) : true;

	[return: NotNullIfNotNull( nameof( value ) )]
	public static bool? False( this Argument _, bool? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> value.HasValue && value != false ? throw new ArgumentException( message ?? VALUE_MUST_BE_FALSE, name ) : value;

	public static bool NotNullFalse( this Argument argument, [NotNull] bool? value, [CallerArgumentExpression( nameof( value ) )] string? name = null, string? message = null )
		=> argument.False( argument.NotNull( value, name, message ), name, message );
}