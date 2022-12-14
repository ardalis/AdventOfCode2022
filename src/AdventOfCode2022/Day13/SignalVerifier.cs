using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day13;

public class SignalVerifier
{
    public bool Verify(SignalPair signalPair)
    {
        string left = signalPair.Left;
        string right = signalPair.Right;
        var outerBracketRegex = new Regex(@"^\[(\[.*?\]|[,])\]$");

        // regex to strip outer brackets
        // ^\[(.*)\]$ works for basic cases; fails for [1],[2,3,4]
        // ^\[(\[.*?\]|[,])\]$ works for that but not others

        // regex to match a list that isn't wrapped in [], expecially a list of lists
        // https://regex101.com/r/y65oHu/1
        // \[.*?\]|[,]
        // input: [1],[2,3,4]
        // matches:
        // 0: [1]
        // 1: ,
        // 2: [2,3,4]
        // adding a ,5 to the end of input, the 5 is NOT matched.
        // adding \d to end fixes it: \[.*?\]|[,]|\d

        // are both sides lists?
        var leftMatch = outerBracketRegex.Match(left);
        var rightMatch = outerBracketRegex.Match(right);

        if (leftMatch.Success && rightMatch.Success)
        {
            // evaluate inner values
            left = leftMatch.Groups[1].Value;
            right = rightMatch.Groups[1].Value;

            return Verify(new SignalPair(left, right));
        }

        // if neither side is a list, then we either have an array of numbers or a single number
        // TODO this won't work with sublists
        int[] leftNumbers = left.Split(',').Select(s => int.Parse(s)).ToArray();
        int[] rightNumbers = right.Split(',').Select(s => int.Parse(s)).ToArray();

        int index = 0;
        while(index < leftNumbers.Length && index < rightNumbers.Length)
        {
            if (leftNumbers[index] > rightNumbers[index]) return false;
            if(leftNumbers.Length > rightNumbers.Length) return false;
            index++;
        }

        return true;
    }
}
