using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser {
[TestFixture]
public class FieldParserTaskTests
{
    public static void Test(string input, string[] expectedResult)
    {
        var actualResult = FieldsParserTask.ParseLine(input);
        Assert.AreEqual(expectedResult.Length, actualResult.Count);
        for (int i = 0; i < expectedResult.Length; ++i) {
            Assert.AreEqual(expectedResult[i], actualResult[i].Value);
        }
    }

[TestCase("hello", new[] { "hello" })]
[TestCase("\'c\'\'d\'", new[] { "c", "d" })]
[TestCase("hello world", new[] { "hello", "world" })]
[TestCase("\'hello world\'", new[] { "hello world" })]
[TestCase(@"""\\h""", new[] { @"\h" })]
[TestCase(@"c""b""f", new[] { "c", "b", "f" })]
[TestCase(@"""\\""", new[] { @"\" })]
[TestCase(@" ", new string[0])]
[TestCase(@"""a", new[] { @"a" })]
[TestCase(@"''", new[] { @"" })]
[TestCase("hello world", new[] { "hello", "world" })]
[TestCase(@"'a ""b"" ""c"" d'", new[] { @"a ""b"" ""c"" d", })]
[TestCase(@"""text ", new[] { "text " })]
[TestCase(@"'\'' ", new[] { "'" })]
[TestCase(@"""QF\""""", new[] { @"QF""" })]
[TestCase(@"""a 'j' 'u' d""", new[] { @"a 'j' 'u' d", })]

public static void RunTests(string input, string[] expectedOutput)
{
            Test(input, expectedOutput);
}
}

public class FieldsParserTask
{
        private static Token ReadField(string line, int startIndex)
        {
            var result = new List<char>();
            var charArray = line.ToCharArray();
            var length = 0;
            for (int i = startIndex; i < charArray.Length; i++) {
                var symbol = charArray[i];
                if (symbol != ' ' && symbol != '"' && symbol != '\'') {
                    result.Add(symbol);
                    length++;
                } else
                    break;
            }
            return new Token(string.Join("", result), startIndex, length);
        }

        public static List<Token> ParseLine(string line)
        {
            var tokens = new List<Token>();
            var charArray = line.ToCharArray();
            for (int i = 0; i < line.Length; i++) {
                var symbol = charArray[i];
                if (symbol == '"' || symbol == '\'') {
                    Token token = QuotedFieldTask.ReadQuotedField(line, i);
                    tokens.Add(token);
                    i = token.GetIndexNextToToken() - 1;
                    continue;
                }
                if (symbol != ' ') {
                    Token token = ReadField(line, i);
                    tokens.Add(token);
                    i = token.GetIndexNextToToken() - 1;
                    continue;
                }
            }
            return tokens;
        }
}
}