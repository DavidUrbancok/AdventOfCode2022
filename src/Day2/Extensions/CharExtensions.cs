using Day2.Common;

namespace Day2.Extensions;

public static class CharExtensions
{
    public static int ToResult(this char input)
    {
        return input switch
        {
            'X' => Constants.LossPoints,
            'Y' => Constants.DrawPoints,
            'Z' => Constants.WinPoints,
            _ => throw new InvalidOperationException($"Invalid input '{input}'.")
        };
    } 
}