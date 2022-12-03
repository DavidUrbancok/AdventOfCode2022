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