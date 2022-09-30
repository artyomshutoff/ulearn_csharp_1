private static void
WriteTextWithBorder(string text)
{
    string border = "+";
    string line = "| " + text + " |";
    for (int i = 0; i < text.Length + 2; i++)
        border += ('-');
    border += '+';
    Console.WriteLine(border);
    Console.WriteLine(line);
    Console.WriteLine(border);
}
