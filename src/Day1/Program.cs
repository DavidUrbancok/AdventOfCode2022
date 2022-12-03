var input = File.ReadAllLines("input.txt");

// ============================
// ========== PART 1 ==========
// ============================

var currentCalories = 0;
var maxCalories = 0;

foreach (var line in input)
{
    if (line.Equals(string.Empty))
    {
        if (currentCalories > maxCalories)
        {
            maxCalories = currentCalories;
        }
        
        currentCalories = 0;

        continue;
    }

    currentCalories += int.Parse(line);
}

Console.WriteLine(maxCalories);

// ============================
// ========== PART 2 ==========
// ============================

currentCalories = 0;
IList<int> calories = new List<int>();

foreach (var line in input)
{
    if (line.Equals(string.Empty))
    {
        calories.Add(currentCalories);

        currentCalories = 0;

        continue;
    }

    currentCalories += int.Parse(line);
}

var result = calories
    .OrderByDescending(calorie => calorie)
    .Take(Range.EndAt(3))
    .Sum();

Console.WriteLine(result);