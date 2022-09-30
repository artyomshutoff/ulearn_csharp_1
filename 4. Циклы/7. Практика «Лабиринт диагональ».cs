
namespace Mazes {
public static class DiagonalMazeTask
{
    public static void MakeHorizontalMove(Robot robot, int width, Direction dir)
    {
        for (int k = 0; k < width; ++k)
            robot.MoveTo(dir);
    }
    public static void MakeVerticalMove(Robot robot, int height, Direction dir)
    {
        for (int k = 0; k < height; ++k)
            robot.MoveTo(dir);
    }

    public static void GoRightDown(Robot robot, int width, int height)
    {
        for (int k = 0; k < height - 2; ++k) {
            MakeVerticalMove(robot, width / (height - 1), Direction.Right);
            if (k != (height - 3))
                MakeHorizontalMove(robot, 1, Direction.Down);
        }
    }
    public static void GoDownRight(Robot robot, int width, int height)
    {
        for (int k = 0; k < width - 2; ++k) {
            MakeVerticalMove(robot, (height - 3) / (width - 2), Direction.Down);
            if (k != (width - 3))
                MakeHorizontalMove(robot, 1, Direction.Right);
        }
    }
    public static void MoveOut(Robot robot, int width, int height)
    {
        if (width > height)
            GoRightDown(robot, width, height);
        else
            GoDownRight(robot, width, height);
    }
}
}