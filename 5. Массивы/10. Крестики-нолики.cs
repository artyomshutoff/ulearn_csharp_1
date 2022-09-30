public static GameResult GetGameResult(Mark[, ] field)
{
    bool crossWin = IsThreeInARow(field, Mark.Cross),
         circleWin = IsThreeInARow(field, Mark.Circle);
    return crossWin == circleWin ? GameResult.Draw
      : crossWin ? GameResult.CrossWin : GameResult.CircleWin;
}

public static bool
IsThreeInARow(Mark[, ] field, Mark mark)
{
    if (field[0, 0] == mark && field[0, 0] == field[1, 1] &&
        field[0, 0] == field[2, 2])
        return true;
    if (field[2, 0] == mark && field[2, 0] == field[1, 1] &&
        field[2, 0] == field[0, 2])
        return true;
    for (int i = 0; i < 3; i++) {
        if (field[i, 0] == mark && field[i, 0] == field[i, 1] &&
            field[i, 0] == field[i, 2])
            return true;
        if (field[0, i] == mark && field[0, i] == field[1, i] &&
            field[0, i] == field[2, i])
            return true;
    }
    return false;
}