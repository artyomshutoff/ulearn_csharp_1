using System.Collections.Generic;

namespace TextAnalysis {
static class FrequencyAnalysisTask
{
    public static Dictionary<string, string> GetMostFrequentNextWords(
      List<List<string>> text)
    {
        var result = new Dictionary<string, string>();
        //...

        // 1.Разбить исходное предложение на список биграмм
        // 2.Разбить исходное предложение на список триграмм
        // 3.Сделать эти разбиения для каждого предложения в тексте, а после
        // объеденить эти списки.

        // НЕОБХОДИМО СОЗДАТЬ ОТДЕЛЬНЫЙ МЕТОД КОТОРЫЙ СОЗДАЕТ НЕСКОЛЬКО ЛИСТОВ
        // ДЛЯ РАЗНЫХ Н-ГАРММ

        List<List<string>> nGramms =
          new List<List<string>>(); // конечный список n-рамм

        List<string> biGramm = new List<string>();
        List<string> threeGramm = new List<string>();

#region Создаём список биграмм и триграмм
        foreach (var sentens in text) {
            if (sentens.Count > 2) {
                for (int i = 0; i < sentens.Count - 2; i++) {
                    threeGramm = threeGrammSend(
                      sentens[i], sentens[i + 1], sentens[i + 2]);

                    nGramms.Add(threeGramm);
                }
            }
            if (sentens.Count > 1) {
                for (int i = 0; i < sentens.Count - 1; i++) {
                    biGramm = biGrammSend(sentens[i], sentens[i + 1]);

                    nGramms.Add(biGramm);
                }
            }
        }
#endregion

        Dictionary<string, Dictionary<string, int>> FrequencyNgramms =
          new Dictionary<string, Dictionary<string, int>>();

#region Создаем словарь с началами биграмм и триграмм и частотой их продолжений
        foreach (var item in nGramms) {
            if (item.Count == 2) {
                if (!FrequencyNgramms.ContainsKey(item[0])) {
                    FrequencyNgramms[item[0]] = new Dictionary<string, int>();

                    if (!FrequencyNgramms[item[0]].ContainsKey(item[1]))
                        FrequencyNgramms[item[0]][item[1]] = 0;

                    FrequencyNgramms[item[0]][item[1]]++;
                } else {
                    if (!FrequencyNgramms[item[0]].ContainsKey(item[1])) {
                        FrequencyNgramms[item[0]][item[1]] = 0;
                    }

                    FrequencyNgramms[item[0]][item[1]]++;
                }
            }

            if (item.Count == 3) {
                string key = item[0] + " " + item[1];

                if (!FrequencyNgramms.ContainsKey(key)) {
                    FrequencyNgramms[key] = new Dictionary<string, int>();

                    if (!FrequencyNgramms [key]
                           .ContainsKey(item[2]))
                        FrequencyNgramms [key]
                        [item[2]] = 0;

                    FrequencyNgramms [key]
                    [item[2]]++;
                } else {
                    if (!FrequencyNgramms [key]
                           .ContainsKey(item[2])) {
                        FrequencyNgramms [key]
                        [item[2]] = 0;
                    }

                    FrequencyNgramms [key]
                    [item[2]]++;
                }
            }
        }
#endregion

        foreach (var item in FrequencyNgramms) {
            if (!result.ContainsKey(item.Key)) {
                // int count = item.Value.Count;
                string maxFrequencyKeyEnd = "";

                int maxFrequencyValue = 0;
                int comparet = 0;

                foreach (var some in item.Value) {
                    if (maxFrequencyValue == some.Value) {
                        comparet =
                          string.CompareOrdinal(maxFrequencyKeyEnd, some.Key);

                        if (comparet == 0)
                            break;

                        maxFrequencyKeyEnd =
                          comparet < 0 ? maxFrequencyKeyEnd : some.Key;
                    }
                    if (maxFrequencyValue < some.Value) {
                        maxFrequencyValue =
                          some.Value; // Реализовать метод Ordinal
                        maxFrequencyKeyEnd = some.Key;
                        // string.CompareOrdinal
                    }
                }

                result[item.Key] = maxFrequencyKeyEnd;
            }
        }

        return result;
    }

    public static List<string> biGrammSend(string str1, string str2)
    {
        List<string> Ngramm = new List<string>();

        Ngramm.Add(str1);
        Ngramm.Add(str2);

        return Ngramm;
    }

    public static List<string> threeGrammSend(string str1,
                                              string str2,
                                              string str3)
    {
        List<string> Ngramm = new List<string>();

        Ngramm.Add(str1);
        Ngramm.Add(str2);
        Ngramm.Add(str3);

        return Ngramm;
    }
}
}