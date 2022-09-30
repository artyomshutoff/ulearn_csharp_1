namespace Mazes {
public static class EmptyMazeTask
{
    // Horizontal shift
    public static void MakeHorizontalMove(Robot robot, int width, Direction dir)
    {
        for (int i = 0; i < width - 3; ++i)
            robot.MoveTo(dir);
    }

    // Vertical shift
    public static void MakeVerticalMove(Robot robot, int height, Direction dir)
    {
        for (int i = 0; i < height - 3; ++i)
            robot.MoveTo(dir);
    }

    public static void MoveOut(Robot robot, int width, int height)
    {
        MakeHorizontalMove(robot, width, Direction.Right);
        MakeVerticalMove(robot, height, Direction.Down);
    }
}
}