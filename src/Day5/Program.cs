using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

// ============================
// ========== PART 1 ==========
// ============================

string line;
var i = -1;

do
{
    ++i;
    line = input[i];
}
while (line[1] != '1');

var numberOfStacks = int.Parse(line[^1].ToString());
var stacks = new Stack<char>[numberOfStacks];

for (var j = 0; j < numberOfStacks; ++j)
{
    stacks[j] = new Stack<char>();
}

var stackLines = input.Take(i).Reverse().ToList();

foreach (var stackLine in stackLines)
{
    var currentStack = 0;

    foreach (var linePart in stackLine.Chunk(4))
    {
        var character = linePart[1];

        if (character is >= 'A' and <= 'Z')
        {
            stacks[currentStack].Push(character);
        }
        
        ++currentStack;
    }
}

var startPos = i + 2;

for (var index = startPos; index < input.Length; ++index)
{
    var currentLine = input[index];
    var parsedLine = currentLine.Split(' ');

    var quantity = int.Parse(parsedLine[1]);
    var sourceStack = int.Parse(parsedLine[3]) - 1;
    var targetStack = int.Parse(parsedLine[5]) - 1;

    for (var q = 0; q < quantity; ++q)
    {
        var charToMove = stacks[sourceStack].Pop();
        stacks[targetStack].Push(charToMove);
    }
}

Console.WriteLine(string.Join("", stacks.Select(stack => stack.Pop())));

// ============================
// ========== PART 2 ==========
// ============================

stackLines = input.Take(i).Reverse().ToList();

foreach (var stackLine in stackLines)
{
    var currentStack = 0;

    foreach (var linePart in stackLine.Chunk(4))
    {
        var character = linePart[1];

        if (character is >= 'A' and <= 'Z')
        {
            stacks[currentStack].Push(character);
        }

        ++currentStack;
    }
}


for (var index = startPos; index < input.Length; ++index)
{
    var currentLine = input[index];
    var parsedLine = currentLine.Split(' ');

    var quantity = int.Parse(parsedLine[1]);
    var sourceStack = int.Parse(parsedLine[3]) - 1;
    var targetStack = int.Parse(parsedLine[5]) - 1;

    var stack = new Stack<char>(quantity);

    for (var q = 0; q < quantity; ++q)
    {
        stack.Push(stacks[sourceStack].Pop());
    }

    for (var q = 0; q < quantity; ++q)
    {
        stacks[targetStack].Push(stack.Pop());
    }
}

Console.WriteLine(string.Join("", stacks.Select(stack => stack.Pop())));