public static int[] GetBenfordStatistics(string text)
{
    var statistics = new int[10];
    foreach (var dic in text.Split(' '))
        if (char.IsDigit(dic[0]))
            statistics[dic[0] - '0']++;
    return statistics;
}