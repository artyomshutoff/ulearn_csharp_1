[TestCase("text", new[] {"text"})]
[TestCase("hello world", new[] {"hello", "world"})]
[TestCase("\'a\'\'b\'", new[] {"a", "b"})]
[TestCase(@"""QF\""""", new[] {@"QF"""})]
[TestCase("hello  world", new[] {"hello", "world"})]
[TestCase("\'hello  world\'", new[] {"hello  world"})]
[TestCase(@"""\\b""", new[] {@"\b"})]
[TestCase(@"""\\""", new[] {@"\"})]
[TestCase(@" ", new string[0])]
[TestCase(@"""a", new[] {@"a"})]
[TestCase(@"''", new[] {@""})]
[TestCase(@"""a 'b' 'c' d""", new[] {@"a 'b' 'c' d",})]
[TestCase(@"'a ""b"" ""c"" d'", new[] {@"a ""b"" ""c"" d",})]
[TestCase(@"a""b""f", new[] {"a","b","f"})]
[TestCase(@"""text ", new[] {"text "})]
[TestCase(@"'\'' ", new[] {"'"})]

public static void RunTests(string input, string[] expectedOutput)
{
Test(input, expectedOutput);
}