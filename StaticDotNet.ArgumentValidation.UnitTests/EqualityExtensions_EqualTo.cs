using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;
public sealed class EqualityExtensions_EqualTo {

	[Fact]
	public void WithStructValueReturnsCorrectly() {

		int value = 1;
		int comparisonValue = 1;

		int result = Argument.Is.EqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableStructValueReturnsCorrectly() {

		int? value = 1;
		int comparisonValue = 1;

		int? result = Argument.Is.EqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithClassValueReturnsCorrectly() {

		string value = "Value";
		string comparisonValue = "Value";

		string result = Argument.Is.EqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}

	[Fact]
	public void WithNullableClassValueReturnsCorrectly() {

		string? value = "Value";
		string comparisonValue = "Value";

		string result = Argument.Is.EqualTo( value, comparisonValue );

		Assert.Equal( value, result );
	}
}
