public class Vector
{
    public double X
    {
        get;
        set;
    }
    public double Y
    {
        get;
        set;
    }
    public double Length => Math.Sqrt(X * X + Y * Y);

    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1}) with length: {2}", X, Y, Length);
    }
}