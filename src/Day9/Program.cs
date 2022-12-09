var input = File.ReadAllLines("input.txt");

// ============================
// ========== PART 1 ==========
// ============================

var visited = new HashSet<Tuple>();

var snakeHead = new Point { X = 0, Y = 0 };
var snakeTail = new Point { X = 0, Y = 0 };


foreach (var line in input)
{
    var strings = line.Split(' ');
    var direction = strings[0];
    var amount = int.Parse(strings[1]);

    switch (direction)
    {
        case "U":
        {
            for (var i = 0; i < amount; i++)
            {
                snakeHead.Y++;
                ProcessMovement(snakeHead, snakeTail);
            }

            break;
        }
        case "D":
        {
            for (var i = 0; i < amount; i++)
            {
                snakeHead.Y--;
                ProcessMovement(snakeHead, snakeTail);
            }

            break;
        }
        case "L":
        {
            for (var i = 0; i < amount; i++)
            {
                snakeHead.X--;
                ProcessMovement(snakeHead, snakeTail);
            }

            break;
        }
        case "R":
        {
            for (var i = 0; i < amount; i++)
            {
                snakeHead.X++;
                ProcessMovement(snakeHead, snakeTail);
            }

            break;
        }
    }
}

Console.WriteLine(visited.Count);

static void HandleMovement(ref int point, int diff)
{
    if (diff < 0)
    {
        point--;
    }
    else
    {
        point++;
    }
}

void ProcessMovement(Point head, Point tail)
{
    var horizontalDiff = head.X - tail.X;
    var verticalDiff = head.Y - tail.Y;

    if (Math.Abs(horizontalDiff) == 2 && Math.Abs(verticalDiff) == 1
        || Math.Abs(horizontalDiff) == 1 && Math.Abs(verticalDiff) == 2)
    {
        HandleMovement(ref tail.X, horizontalDiff);
        HandleMovement(ref tail.Y, verticalDiff);
    }

    if (Math.Abs(horizontalDiff) == 2 && Math.Abs(verticalDiff) == 0)
    {
        HandleMovement(ref tail.X, horizontalDiff);
    }

    if (Math.Abs(horizontalDiff) == 0 && Math.Abs(verticalDiff) == 2)
    {
        HandleMovement(ref tail.Y, verticalDiff);
    }

    visited.Add(new Tuple(tail.X, tail.Y));
}

internal record Tuple(int X, int Y);

internal class Point
{
    internal int X;

    internal int Y;
}