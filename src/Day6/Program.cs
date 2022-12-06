var input = File.ReadAllLines("input.txt").First();

// ============================
// ========== PART 1 ==========
// ============================

var queue = new Queue<char>();

for (var i = 0; i < 3; ++i)
{
    queue.Enqueue(input[i]);
}

var numberOfReads = 3;

for (var i = 3; i < input.Length; ++i)
{
    queue.Enqueue(input[i]);
    numberOfReads++;

    var set = new HashSet<char>(queue.ToArray());

    if (set.Count == 4)
    {
        Console.WriteLine(numberOfReads);
        break;
    }
    _ = queue.Dequeue();
}

// ============================
// ========== PART 1 ==========
// ============================

queue = new Queue<char>();

for (var i = 0; i < 13; ++i)
{
    queue.Enqueue(input[i]);
}

numberOfReads = 13;

for (var i = 13; i < input.Length; ++i)
{
    queue.Enqueue(input[i]);
    numberOfReads++;

    var set = new HashSet<char>(queue.ToArray());

    if (set.Count == 14)
    {
        Console.WriteLine(numberOfReads);
        break;
    }
    _ = queue.Dequeue();
}