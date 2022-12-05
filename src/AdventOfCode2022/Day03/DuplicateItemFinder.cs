namespace AdventOfCode2022.Day03
{
    public class DuplicateItemFinder
    {
        public char FindDuplicateItem(string input)
        {
            int halflength = input.Length / 2;
            var leftChars = input.Substring(0, halflength).ToCharArray();
            var rightChars = input.Substring(halflength, halflength).ToCharArray();

            foreach (char c in leftChars)
            {
                if (rightChars.Contains(c))
                {
                    return c;
                }
            }
            throw new Exception("No duplicate found");
        }

        public char FindDuplicateItemAmong3Rucks(List<char[]> rucks)
        {
            return rucks[0].Intersect(rucks[1]).Intersect(rucks[2]).First();
        }
    }
}
