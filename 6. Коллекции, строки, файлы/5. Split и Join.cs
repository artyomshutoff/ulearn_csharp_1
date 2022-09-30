public static string
ReplaceIncorrectSeparators(string text)
{
    return text.Replace(" ", "\t")
      .Replace(",", "")
      .Replace(";", "")
      .Replace("-", "")
      .Replace(":", "")
      .Replace("\t\t", "\t");
}