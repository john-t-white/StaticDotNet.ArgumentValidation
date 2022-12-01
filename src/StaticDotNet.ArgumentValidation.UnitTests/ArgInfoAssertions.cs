﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDotNet.ArgumentValidation.UnitTests;

public static class ArgInfoAssertions {

	public static void Equal<T>( ArgInfo<T> expected, ArgInfo<T> actual )
		where T : class? {

		Assert.Same( expected.Value, actual.Value );
		Assert.Equal( expected.Name, actual.Name );
		Assert.Equal( expected.Message, actual.Message );
	}
}