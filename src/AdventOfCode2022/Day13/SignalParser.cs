namespace AdventOfCode2022.Day13;

public class SignalParser
{
    public List<SignalPair> ParseRawData(string input)
    {
        var pairs = input.Split(Environment.NewLine + Environment.NewLine);

        return pairs.Select(p =>
        {
            var parse = p.Split(Environment.NewLine);
            return new SignalPair()
            {
                Left = parse[0],
                Right = parse[1]
            };
        }).ToList();
    }
}
