namespace Day2.Common;

internal static class ChoiceHelper
{
    internal static int DetermineWinner(Choice opponentChoice, Choice myChoice)
    {
        if (opponentChoice == myChoice)
        {
            return Constants.DrawPoints;
        }

        return opponentChoice switch
        {
            Choice.Rock => myChoice == Choice.Paper
                ? Constants.WinPoints // Paper winning, me winning
                : Constants.LossPoints, // Rock winning, me losing
            Choice.Paper => myChoice == Choice.Rock
                ? Constants.LossPoints // Paper winning, me losing
                : Constants.WinPoints, // Scissors winning, me winning
            Choice.Scissors => myChoice == Choice.Rock
                ? Constants.WinPoints // Rock winning, me winning
                : Constants.LossPoints, // Scissors winning, me losing
            _ => throw new InvalidOperationException("Invalid state")
        };
    }

    internal static Choice GetChoiceToPlay(Choice opponentPlayed, int iPlayed)
    {
        if (iPlayed == Constants.DrawPoints)
        {
            return opponentPlayed;
        }

        return opponentPlayed switch
        {
            Choice.Rock => iPlayed == Constants.WinPoints
                ? Choice.Paper
                : Choice.Scissors,
            Choice.Paper => iPlayed == Constants.WinPoints
                ? Choice.Scissors
                : Choice.Rock,
            Choice.Scissors => iPlayed == Constants.WinPoints
                ? Choice.Rock
                : Choice.Paper,
            _ => throw new InvalidOperationException("Invalid state")
        };
    }
}