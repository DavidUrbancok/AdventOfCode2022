using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

// ============================
// ========== PART 1 ==========
// ============================

Stack<string> path = new();
Dictionary<string, int> sizes = new();

foreach (var line in input)
{
    if (line == "$ cd ..")
    {
        path.Pop();
        continue;
    }
    
    if (line.StartsWith("$ cd"))
    {
        path.Push(string.Join(string.Empty, path) + line.Split(" ")[2]);
        continue;
    }
    
    if (Regex.Match(line, "\\d+").Success)
    {
        var fileSize = int.Parse(line.Split(" ")[0]);

        foreach (var directory in path)
        {
            sizes[directory] = sizes.GetValueOrDefault(directory) + fileSize;
        }
    }
}

Console.WriteLine(sizes.Values.Where(value => value <= 100_000).Sum());

// ============================
// ========== PART 2 ==========
// ============================

var sum = sizes.Values.Max();
var freeSpace = 70_000_000 - sum;

Console.WriteLine(sizes.Values.Where(size => size + freeSpace >= 30_000_000).Min());