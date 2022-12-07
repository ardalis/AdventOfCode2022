namespace AdventOfCode2022.Day04
{
    public class IdRangeCalculator
    { 
        public static int CountFullyContainedRanges(string input)
        {
            var rangePairs = input.Split(Environment.NewLine)
                .Select(s => IdRangePairFactory.FromString(s));

            return rangePairs
                .Count(pair => pair.first.Contains(pair.second)
                            || pair.second.Contains(pair.first));
        }

        public static int CountOverlappingRanges(string input)
        {
            var rangePairs = input.Split(Environment.NewLine)
                .Select(s => IdRangePairFactory.FromString(s));

            return rangePairs
                .Count(pair => pair.first.Overlaps(pair.second) ||
                            pair.second.Overlaps(pair.first));
        }

    }

}
