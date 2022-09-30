using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis {
static class SentencesParserTask
{
    public static List<List<string>> ParseSentences(string text)
    {
        var sentencesList = new List<List<string>>();
        var sentence = new List<string>();

        var textDelimetrs = new[]{ '.', '!', '?', ';', ':', '(', ')' };
        var sentenceDelimeters =
          text.Where(x => x != '\'' && !char.IsLetter(x)).Distinct().ToArray();

        var sentences = text.Split(textDelimetrs);
        foreach (var item in sentences) {
            sentence = item.Split(sentenceDelimeters)
                         .Where(x => x != string.Empty)
                         .Select(x => x.ToLower())
                         .ToList();
            if (sentence.Count != 0)
                sentencesList.Add(sentence);
        }
        return sentencesList;
    }
}
}