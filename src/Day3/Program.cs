var input = File.ReadAllLines("input.txt");

// ============================
// ========== PART 1 ==========
// ============================

const string aToZ = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

var totalPriority = (from line in input
    let lineHalfLength = line.Length / 2
    let firstHalf = line[..lineHalfLength].AsEnumerable()
    let secondHalf = line[lineHalfLength..].AsEnumerable()
    select firstHalf.First(secondHalf.Contains)
    into commonLetter
    select aToZ.IndexOf(commonLetter) + 1).Sum();

Console.WriteLine(totalPriority);

// ============================
// ========== PART 2 ==========
// ============================

totalPriority = 0;

for (var i = 0; i < input.Length / 3; i++)
{
    var lines = new string[3];

    for (var j = 0; j < 3; j++)
    {
        lines[j] = input[i * 3 + j];
    }

    var commonLetter = lines[0].
        First(character => 
            lines[1].Contains(character) && lines[2].Contains(character));

    totalPriority += aToZ.IndexOf(commonLetter) + 1; 
}

Console.WriteLine(totalPriority);