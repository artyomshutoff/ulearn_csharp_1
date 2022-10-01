public class ClockwiseComparer : IComparer
{
    public int Compare(object a, object b) =>
      GetPhase((Point) a).CompareTo(GetPhase((Point) b));
    private double GetPhase(Point point) => Math.Atan2(-point.Y, -point.X);
}