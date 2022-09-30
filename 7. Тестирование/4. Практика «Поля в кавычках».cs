using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TableParser {
[TestFixture]
public class QuotedFieldTaskTests
{
[TestCase("''", 0, "", 2)]
[TestCase("'b'", 0, "b", 3)]
[TestCase(@"some_text ""QF \"""" other text", 10, @"QF """, 7)]
[TestCase(@"""r 't' 'y' u""", 0, "r 't' 'y' u", 13)]
[TestCase("'vbn ef", 0, "vbn ef", 7)]
[TestCase(@"""\\""", 0, @"\", 4)]
[TestCase(@"'""1"" ""2"" ""3""'", 0, @"""1"" ""2"" ""3""", 13)]
[TestCase("\'h\'\'j\'", 0, "h", 3)]

public void Test(string line, int startIndex, string expectedValue, int expectedLength)
{
        var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
        Assert.AreEqual(actualToken,
                        new Token(expectedValue, startIndex, expectedLength));
}
}

class QuotedFieldTask
{
    private static int CharHandler(char quote,
                                   char[] charArray,
                                   bool isSlashed,
                                   List<char> result,
                                   int startIndex)
    {
        var length = 1;
        for (int i = startIndex + 1; i < charArray.Length; i++) {
            length++; //если имеется слэш, значит уже прочитали символ
            if (isSlashed) {
                isSlashed = false;
                continue;
            }
            var symbol = charArray[i];
            if (symbol == quote)
                break;
            if (symbol == '\\') {
                result.Add(charArray[i + 1]);
                isSlashed = true;
                continue;
            }
            if (symbol != quote)
                result.Add(symbol);
        }
        return length;
    }

    public static Token ReadQuotedField(string line, int startIndex)
    {
        var rslt = new List<char>();
        var quote = line[startIndex];
        var charArr = line.ToCharArray();
        var isSlash = false;

        var length = CharHandler(quote, charArr, isSlash, rslt, startIndex);
        return new Token(string.Join("", rslt), startIndex, length);
    }
}
}
