public static void
Print(params Object[] array)
{
    for (var i = 0; i < array.Length; i++) {
        if (i > 0)
            Console.Write(", ");
        Console.Write(array.GetValue(i));
    }
    Console.WriteLine();
}