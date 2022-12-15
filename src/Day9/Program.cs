var input = File.ReadAllLines("input.txt");

// ============================
// ========== PART 1 ==========
// ============================

ISet<Knot> visited = new HashSet<Knot>();

static void MoveHead(IList<Knot> rope, string direction)
{
    rope[0] = direction switch
    {
        "U" => rope[0] with { X = rope[0].X - 1 },
        "D" => rope[0] with { X = rope[0].X + 1 },
        "L" => rope[0] with { Y = rope[0].Y - 1 },
        "R" => rope[0] with { Y = rope[0].Y + 1 },
        _ => throw new InvalidOperationException(direction)
    };

    for (var i = 1; i < rope.Count; i++)
    {
        var xDistance = rope[i - 1].X - rope[i].X;
        var yDistance = rope[i - 1].Y - rope[i].Y;

        if (Math.Abs(xDistance) > 1 || Math.Abs(yDistance) > 1)
        {
            rope[i] = new Knot(
                rope[i].X + Math.Sign(xDistance),
                rope[i].Y + Math.Sign(yDistance)
            );
        }
    }
}

var rope = Enumerable.Repeat(new Knot(0, 0), 2).ToArray();
visited.Add(rope.Last());

foreach (var line in input)
{
    var parts = line.Split(' ');
    var dir = parts[0];
    var distance = int.Parse(parts[1]);

    for (var i = 0; i < distance; i++)
    {
        MoveHead(rope, dir);
        visited.Add(rope.Last());
    }
}

Console.WriteLine(visited.Count);


// ============================
// ========== PART 2 ==========
// ============================


visited.Clear();
rope = Enumerable.Repeat(new Knot(0, 0), 10).ToArray();
visited.Add(rope.Last());

foreach (var line in input)
{
    var parts = line.Split(' ');
    var dir = parts[0];
    var distance = int.Parse(parts[1]);

    for (var i = 0; i < distance; i++)
    {
        MoveHead(rope, dir);
        visited.Add(rope.Last());
    }
}

Console.WriteLine(visited.Count);

internal record struct Knot(int X, int Y);
