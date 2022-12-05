namespace AdventOfCode2022.Day03
{
    public class RuckScoreService
    {
        public int Score(string input)
        {
            int score = 0;
            var dupeFinder = new DuplicateItemFinder();

            var ruckStrings = input.Split(Environment.NewLine);
            foreach (var ruckString in ruckStrings)
            {
                score += dupeFinder.FindDuplicateItem(ruckString).ToScore();
            }
            return score;
        }

        public int ScorePart2(string input)
        {
            int score = 0;
            int line = 0;
            var dupeFinder = new DuplicateItemFinder();

            var ruckStrings = input.Split(Environment.NewLine);
            var currentSet = new List<char[]>();
            foreach (var ruckString in ruckStrings)
            {
                if (line % 3 == 0)
                {
                    currentSet = new List<char[]>();
                }
                currentSet.Add(ruckString.ToCharArray());
                if (line % 3 == 2)
                {
                    score += dupeFinder.FindDuplicateItemAmong3Rucks(currentSet.ToList()).ToScore();
                }
                line++;
            }
            return score;
        }
    }
}
