using Day2.Common;

namespace Day2.Extensions;

internal static class EnumExtensions
{
    internal static Choice ToChoice(this char input)
    {
        return input switch
        {
            'A' or 'X' => Choice.Rock,
            'B' or 'Y' => Choice.Paper,
            'C' or 'Z' => Choice.Scissors,
            _ => throw new InvalidOperationException($"Invalid choice '{input}'.")
        };
    }
}