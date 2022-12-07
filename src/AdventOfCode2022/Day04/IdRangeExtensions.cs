namespace AdventOfCode2022.Day04
{
    public static class IdRangeExtensions
    {
        public static bool Contains(this IdRange source, IdRange range)
        {
            // range end must be between start and end
            if (range.end < source.start) return false;
            if (range.end > source.end) return false;

            // range start must be between start and end
            if (range.start < source.start) return false;
            if (range.start > source.end) return false;

            return true;
        }

        // apparently this isn't bidirectional...
        public static bool Overlaps(this IdRange source, IdRange range)
        {
            // end of range overlaps start of source
            if (range.end <= source.end && range.end >= source.start) return true;

            // start of range overlaps end of source
            if (range.start >= source.start && range.start <= source.end) return true;

            return false;
        }
    }

    public record IdRange(int start, int end);
    public record IdRangePair(IdRange first, IdRange second);

    public class IdRangeFactory
    {
        public static IdRange FromString(string input)
        {
            var numbers = input.Split('-')
                .Select(s => int.Parse(s));

            return new IdRange(numbers.First(), numbers.Last());
        }
    }
    public class IdRangePairFactory
    {
        public static IdRangePair FromString(string input)
        {
            var ranges = input.Split(',')
                .Select(s => IdRangeFactory.FromString(s));

            return new IdRangePair(ranges.First(), ranges.Last());
        }
    }

}
