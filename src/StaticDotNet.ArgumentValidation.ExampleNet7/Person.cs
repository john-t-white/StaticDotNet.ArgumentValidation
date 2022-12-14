namespace StaticDotNet.ArgumentValidation.ExampleNet7;

public class Person {

	public Person( string firstName, string lastName, int age ) {

		FirstName = Arg.IsNotNull( firstName ).Value;
		LastName = Arg.IsNotNull( lastName ).Value;
		Age = Arg.Is( age ).GreaterThan( 0 ).Value;
	}

	public string FirstName { get; }

	public string LastName { get; }

	public int Age { get; }
}
