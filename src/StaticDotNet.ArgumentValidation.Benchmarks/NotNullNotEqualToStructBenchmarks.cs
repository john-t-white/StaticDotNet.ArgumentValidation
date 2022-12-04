﻿using Dawn;
using EnsureThat;
using System.Globalization;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public class NotNullNotEqualToStructBenchmarks {

	public int? value = 1;
	public int comparisonValue = 2;

	[Benchmark( Baseline = true )]
	public int Baseline()
		=> this.value is null
			? throw new ArgumentNullException( nameof( this.value ) )
			: this.value.Value != this.comparisonValue ? this.value.Value : throw new ArgumentException( string.Format( CultureInfo.InvariantCulture, "Value must be equal to {0}.", this.comparisonValue ), nameof( this.value ) );

	//[Benchmark]
	//public int Arg_Is() => Arg.Is.NotNullNotEqualTo( this.value, this.comparisonValue );

	[Benchmark]
	public int Dawn_Guard() => Dawn.Guard.Argument( this.value ).NotNull().NotEqual( this.comparisonValue );

	[Benchmark]
	public int Ensure_That() {
		EnsureThat.Ensure.That( this.value, nameof( this.value ) ).IsNotNull();
		EnsureThat.Ensure.That( this.value!.Value, nameof( this.value ) ).IsNot( this.comparisonValue );

		return this.value.Value;
	}
}