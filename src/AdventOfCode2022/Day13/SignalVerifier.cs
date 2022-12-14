using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day13;

public class SignalVerifier
{
    public bool Verify(SignalPair signalPair)
    {
        string left = signalPair.Left;
        string right = signalPair.Right;
        var outerBracketRegex = new Regex(@"^\[(.*)\]$");

        // are both sides lists?
        var leftMatch = outerBracketRegex.Match(left);
        var rightMatch = outerBracketRegex.Match(right);

        if (leftMatch.Success && rightMatch.Success)
        {
            // evaluate inner values
            left = leftMatch.Groups[1].Value;
            right = rightMatch.Groups[1].Value;
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
