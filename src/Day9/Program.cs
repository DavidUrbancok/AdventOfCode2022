var input = File.ReadAllLines("input.txt");

// ============================
// ========== PART 1 ==========
// ============================

var visited = new HashSet<StackTuple>();

var hX = 0;
var hY = 0;
var tX = 0;
var tY = 0;


foreach (var line in input)
{
    var strings = line.Split(' ');
    var direction = strings[0];
    var amount = int.Parse(strings[1]);

    int horizontalDiff;
    int verticalDiff;

    switch (direction)
    {
        case "U":
        {
            for (var i = 0; i < amount; i++)
            {
                hY++;

                horizontalDiff = hX - tX;
                verticalDiff = hY - tY;

                if (Math.Abs(horizontalDiff) == 2 && Math.Abs(verticalDiff) == 1
                    || Math.Abs(horizontalDiff) == 1 && Math.Abs(verticalDiff) == 2)
                {
                    if (horizontalDiff < 0)
                    {
                        tX--;
                    }
                    else
                    {
                        tX++;
                    }

                    if (verticalDiff < 0)
                    {
                        tY--;
                    }
                    else
                    {
                        tY++;
                    }
                }

                if (Math.Abs(horizontalDiff) == 2 && Math.Abs(verticalDiff) == 0)
                {
                    if (horizontalDiff < 0)
                    {
                        tX--;
                    }
                    else
                    {
                        tX++;
                    }
                }

                if (Math.Abs(horizontalDiff) == 0 && Math.Abs(verticalDiff) == 2)
                {
                    if (verticalDiff < 0)
                    {
                        tY--;
                    }
                    else
                    {
                        tY++;
                    }
                }

                visited.Add(new StackTuple(tX, tY));
            }

            break;
        }
        case "D":
        {
            for (var i = 0; i < amount; i++)
            {
                hY--;

                horizontalDiff = hX - tX;
                verticalDiff = hY - tY;

                if (Math.Abs(horizontalDiff) == 2 && Math.Abs(verticalDiff) == 1
                    || Math.Abs(horizontalDiff) == 1 && Math.Abs(verticalDiff) == 2)
                {
                    if (horizontalDiff < 0)
                    {
                        tX--;
                    }
                    else
                    {
                        tX++;
                    }

                    if (verticalDiff < 0)
                    {
                        tY--;
                    }
                    else
                    {
                        tY++;
                    }
                }

                if (Math.Abs(horizontalDiff) == 2 && Math.Abs(verticalDiff) == 0)
                {
                    if (horizontalDiff < 0)
                    {
                        tX--;
                    }
                    else
                    {
                        tX++;
                    }
                }

                if (Math.Abs(horizontalDiff) == 0 && Math.Abs(verticalDiff) == 2)
                {
                    if (verticalDiff < 0)
                    {
                        tY--;
                    }
                    else
                    {
                        tY++;
                    }
                }

                visited.Add(new StackTuple(tX, tY));
            }

            break;
        }
        case "L":
        {
            for (var i = 0; i < amount; i++)
            {
                hX--;

                horizontalDiff = hX - tX;
                verticalDiff = hY - tY;

                if (Math.Abs(horizontalDiff) == 2 && Math.Abs(verticalDiff) == 1
                    || Math.Abs(horizontalDiff) == 1 && Math.Abs(verticalDiff) == 2)
                {
                    if (horizontalDiff < 0)
                    {
                        tX--;
                    }
                    else
                    {
                        tX++;
                    }

                    if (verticalDiff < 0)
                    {
                        tY--;
                    }
                    else
                    {
                        tY++;
                    }
                }

                if (Math.Abs(horizontalDiff) == 2 && Math.Abs(verticalDiff) == 0)
                {
                    if (horizontalDiff < 0)
                    {
                        tX--;
                    }
                    else
                    {
                        tX++;
                    }
                }

                if (Math.Abs(horizontalDiff) == 0 && Math.Abs(verticalDiff) == 2)
                {
                    if (verticalDiff < 0)
                    {
                        tY--;
                    }
                    else
                    {
                        tY++;
                    }
                }

                visited.Add(new StackTuple(tX, tY));

            }

            break;
        }
        case "R":
        {
            for (var i = 0; i < amount; i++)
            {
                hX++;

                horizontalDiff = hX - tX;
                verticalDiff = hY - tY;

                if (Math.Abs(horizontalDiff) == 2 && Math.Abs(verticalDiff) == 1
                    || Math.Abs(horizontalDiff) == 1 && Math.Abs(verticalDiff) == 2)
                {
                    if (horizontalDiff < 0)
                    {
                        tX--;
                    }
                    else
                    {
                        tX++;
                    }

                    if (verticalDiff < 0)
                    {
                        tY--;
                    }
                    else
                    {
                        tY++;
                    }
                }

                if (Math.Abs(horizontalDiff) == 2 && Math.Abs(verticalDiff) == 0)
                {
                    if (horizontalDiff < 0)
                    {
                        tX--;
                    }
                    else
                    {
                        tX++;
                    }
                }

                if (Math.Abs(horizontalDiff) == 0 && Math.Abs(verticalDiff) == 2)
                {
                    if (verticalDiff < 0)
                    {
                        tY--;
                    }
                    else
                    {
                        tY++;
                    }
                }

                visited.Add(new StackTuple(tX, tY));
            }

            break;
        }
    }
}

Console.WriteLine(visited.Count);

internal record StackTuple(int X, int Y);