﻿var input = File.ReadAllLines("input.txt");

// ============================
// ========== PART 1 ==========
// ============================

var length = input.Length;

var visibleTrees = 4 * (length - 1);

for (var i = 1; i < length - 1; i++)
{
    for (var j = 1; j < length - 1; j++)
    {
        var y = j;

        var row = input[i].ToArray();
        var column = input.Select(line => line[y]).ToArray();

        var leftRow = row[..j];
        var rightRow = row[(j + 1)..];
        var upColumn = column[..i];
        var downColumn = column[(i + 1)..];

        var currentNumber = input[i][j];

        var visibleFromLeft = leftRow.All(treeHeight => treeHeight < currentNumber);
        var visibleFromRight = rightRow.All(treeHeight => treeHeight < currentNumber);
        var visibleFromTop = upColumn.All(treeHeight => treeHeight < currentNumber);
        var visibleFromBottom = downColumn.All(treeHeight => treeHeight < currentNumber);

        if (visibleFromLeft || visibleFromRight || visibleFromTop || visibleFromBottom)
        {
            ++visibleTrees;
        }
    }
}

Console.WriteLine(visibleTrees);