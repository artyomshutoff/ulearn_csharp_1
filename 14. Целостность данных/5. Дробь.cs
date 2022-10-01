public class Ratio
{
    public Ratio(int num, int den)
    {
        if (den <= 0)
            throw new ArgumentException();
        Numerator = num;
        Denominator = den;
        Value = num / (double) den;
    }

    public readonly int Numerator;   //числитель
    public readonly int Denominator; //знаменатель
    public readonly double Value; //значение дроби Numerator / Denominator
}