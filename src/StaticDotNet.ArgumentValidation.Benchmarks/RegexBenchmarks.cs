using Ardalis.GuardClauses;
using Dawn;
using JetBrains.Annotations;
using System.Text.RegularExpressions;

namespace StaticDotNet.ArgumentValidation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob( RuntimeMoniker.Net70 )]
public partial class RegexBenchmarks {

	[GeneratedRegex(@"\d")]
	private static partial Regex DigitRegex();

	public string value = "1";

	[Benchmark( Baseline = true )]
	public string Baseline() => DigitRegex().IsMatch( this.value ) ? this.value : throw new ArgumentException( "Message", nameof( this.value ) );

	[Benchmark]
	public string Argument_Is() => Argument.Is.Match( this.value, DigitRegex() );
}