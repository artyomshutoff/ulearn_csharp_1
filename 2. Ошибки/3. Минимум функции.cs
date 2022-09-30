private static string
GetMinX(int a, int b, int c)
{
    double y = 0;
    if (a > 0) {
        double x = -b / (2.0 * a);
        return (x).ToString();
    } else {
        if (a == 0 && b == 0) {
            double x = -b / (2.0 * a);
            return (x).ToString();
        } else {
            return ("Impossible");
        }
    }
}