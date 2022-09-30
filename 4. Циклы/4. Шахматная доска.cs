private static void
WriteBoard(int size)

{
    string strng = ".";
    for (int i = 1; i <= size; i++) {
        string str = "";
        if (size % 2 == 0 && i % 2 == 0)
            strng = "#";
        if (size % 2 == 0 && i % 2 != 0)
            strng = ".";
        for (int j = 0; j < size; j++) {
            if (strng == ".") {
                str = str + "#";
                strng = "#";
            } else {
                str = str + ".";
                strng = ".";
            }
        }
        Console.WriteLine(str);
    }
    Console.WriteLine("");
}