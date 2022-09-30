private static Dictionary<string, List<string>>
OptimizeContacts(List<string> contacts)
{
    var dictionary = new Dictionary<string, List<string>>();
    string[] firstSplitHalf = new string[contacts.Count];

    for (int i = 0; i < contacts.Count; i++) {
        firstSplitHalf[i] = contacts [i]
                              .Split(':')[0];

        if (firstSplitHalf[i].Length >= 2)
            firstSplitHalf[i] = firstSplitHalf [i]
                                  .Substring(0, 2);
        if (firstSplitHalf[i].Length == 0)
            firstSplitHalf[i] = ":";

        if (!dictionary.ContainsKey(firstSplitHalf[i]))
            dictionary[firstSplitHalf[i]] = new List<string>();

        if (firstSplitHalf[i].Length >= 2)
            dictionary[firstSplitHalf[i]].Add(contacts[i]);
        else if (firstSplitHalf[i].Length == 1)
            dictionary[firstSplitHalf[i]].Add(contacts[i]);
        else if (firstSplitHalf[i].Length == 0)
            dictionary[firstSplitHalf[i]].Add(contacts[i]);
    }
    return dictionary;
}