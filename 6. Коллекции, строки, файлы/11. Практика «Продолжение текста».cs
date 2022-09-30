using System.Collections.Generic;
using System.Text;

namespace TextAnalysis {
static class TextGeneratorTask
{

    public static string CreateText(string lstWrd,
                                    string lstWrd2,
                                    StringBuilder txt,
                                    Dictionary<string, string> words,
                                    int wordsCount)
    {
        for (int i = 0; i < wordsCount; i++) {
            var concat = lstWrd2 + " " + lstWrd;
            var isFound = false;
            if (words.ContainsKey(concat)) {
                txt.Append(" ");
                txt.Append(words[concat]);
                lstWrd2 = lstWrd;
                lstWrd = words[concat];
                isFound = true;
            } else if (words.ContainsKey(lstWrd)) {
                txt.Append(" ");
                txt.Append(words[lstWrd]);
                lstWrd2 = lstWrd;
                lstWrd = words[lstWrd];
                isFound = true;
            }
            if (!isFound)
                return txt.ToString();
        }
        return txt.ToString();
    }

    public static string ContinuePhrase(Dictionary<string, string> nextWords,
                                        string phraseBeginning,
                                        int wordsCount)
    {
        var txt = new StringBuilder(phraseBeginning);
        var wrds = phraseBeginning.Split(' ');
        var lstWrd = "";
        var lstWrd2 = "";
        if (wrds.Length == 0)
            return "";
        else if (wrds.Length == 1)
            lstWrd = wrds[0];
        else {
            lstWrd = wrds[wrds.Length - 1];
            lstWrd2 = wrds[wrds.Length - 2];
        }
        return CreateText(lstWrd, lstWrd2, txt, nextWords, wordsCount);
    }
}
}