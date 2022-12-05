var input = File.ReadAllLines("input.txt");

// ============================
// ========== PART 1 ==========
// ============================

var overlappingRanges = (from line in input
    select line.Split(',')
    into pairs
    let firstElf = pairs[0].Split('-')
    let secondElf = pairs[1].Split('-')
    let firstRange = new Range(int.Parse(firstElf[0]), int.Parse(firstElf[1]))
    let secondRange = new Range(int.Parse(secondElf[0]), int.Parse(secondElf[1]))
    where firstRange.Start.Value <= secondRange.Start.Value && firstRange.End.Value >= secondRange.End.Value ||
          secondRange.Start.Value <= firstRange.Start.Value && secondRange.End.Value >= firstRange.End.Value
    select firstRange).Count();

Console.WriteLine(overlappingRanges);

// ============================
// ========== PART 2 ==========
// ============================

overlappingRanges = default;

foreach (var line in input)
{
    var pairs = line.Split(',');
    var firstElf = pairs[0].Split('-');
    var secondElf = pairs[1].Split('-');

    var firstRange = new Range(int.Parse(firstElf[0]), int.Parse(firstElf[1]));
    var secondRange = new Range(int.Parse(secondElf[0]), int.Parse(secondElf[1]));

    if (firstRange.Start.Value == secondRange.Start.Value || firstRange.End.Value == secondRange.End.Value)
    {
        ++overlappingRanges;
    }
    else if (firstRange.Start.Value < secondRange.Start.Value && firstRange.End.Value >= secondRange.Start.Value
          || firstRange.Start.Value > secondRange.Start.Value && secondRange.End.Value >= firstRange.Start.Value)
    {
        ++overlappingRanges;
    }
}

Console.WriteLine(overlappingRanges);