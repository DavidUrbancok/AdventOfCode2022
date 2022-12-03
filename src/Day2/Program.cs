using Day2.Common;
using Day2.Extensions;

var input = File.ReadAllLines("input.txt");

// ============================
// ========== PART 1 ==========
// ============================

var totalPoints = (from line in input
    let opponentChoice = line[0].ToChoice()
    let myChoice = line[2].ToChoice()
    let earnedPoints = ChoiceHelper.DetermineWinner(opponentChoice, myChoice)
    select earnedPoints + (int)myChoice).Sum();

Console.WriteLine(totalPoints);

// ============================
// ========== PART 2 ==========
// ============================

totalPoints = (from line in input
    let opponentPlayed = line[0].ToChoice()
    let iNeedToPoints = line[2].ToResult()
    let choiceToPlay = ChoiceHelper.GetChoiceToPlay(opponentPlayed, iNeedToPoints)
    select iNeedToPoints + (int)choiceToPlay).Sum();

Console.WriteLine(totalPoints);