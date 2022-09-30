using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RefactorMe {
class Draftsman
{
    private static float x, y;
    static Graphics graphics;

    public static void Initialize(Graphics newGraphics)
    {
        graphics = newGraphics;
        graphics.SmoothingMode = SmoothingMode.None;
        graphics.Clear(Color.Black);
    }

    public static void SetPosition(float x0, float y0)
    {
        x = x0;
        y = y0;
    }

    public static void MakeIt(Pen pen, double length, double angle)
    {
        //Делает шаг длиной length в направлении angle и рисует пройденную
        //траекторию
        var x1 = (float)(x + length * Math.Cos(angle));
        var y1 = (float)(y + length * Math.Sin(angle));
        graphics.DrawLine(pen, x, y, x1, y1);
        x = x1;
        y = y1;
    }

    public static void Change(double length, double angle)
    {
        x = (float)(x + length * Math.Cos(angle));
        y = (float)(y + length * Math.Sin(angle));
    }
}

public class ImpossibleSquare
{
    public static void MakeFront(int length, double angle)
    {
        Draftsman.MakeIt(Pens.Yellow, length * 0.375f, 0 + angle);
        Draftsman.MakeIt(
          Pens.Yellow, length * 0.04f * Math.Sqrt(2), Math.PI / 4 + angle);
        Draftsman.MakeIt(Pens.Yellow, length * 0.375f, Math.PI + angle);
        Draftsman.MakeIt(
          Pens.Yellow, length * 0.375f - length * 0.04f, Math.PI / 2 + angle);

        Draftsman.Change(length * 0.04f, -Math.PI + angle);
        Draftsman.Change(length * 0.04f * Math.Sqrt(2),
                         3 * Math.PI / 4 + angle);
    }

    public static void Draw(int width,
                            int height,
                            double rotationAngle,
                            Graphics graphics)
    {
        // rotationAngle пока не используется, но будет использоваться в будущем
        Draftsman.Initialize(graphics);

        var size = Math.Min(width, height);

        var diagonal_length = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
        var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) +
                 width / 2f;
        var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) +
                 height / 2f;

        Draftsman.SetPosition(x0, y0);

        //Рисуем 4 стороны
        MakeFront(size, 0);
        MakeFront(size, -Math.PI / 2);
        MakeFront(size, Math.PI);
        MakeFront(size, Math.PI / 2);
    }
}
}