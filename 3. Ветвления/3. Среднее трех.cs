public static int
MiddleOf(int a, int b, int c)
{
    if (a < b) {
        if (b < c) {
            return b;
        } else if (a > c) {
            return a;
        } else
            return c;
    } else if (a > b) {
        if (a < c) {
            return a;
        } else if (b > c) {
            return b;
        } else
            return c;
    } else
        return a;
}