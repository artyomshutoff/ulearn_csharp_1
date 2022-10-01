static IComparable MiddleOfThree (IComparable a, IComparable b, IComparable c)
{
	return new[] {a, b, c}.OrderBy(x => x).ToArray()[1];
}