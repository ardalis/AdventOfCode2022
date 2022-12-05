using System.Text;

namespace AdventOfCode2022.Day03
{
    public static class CharExtensions
    {
        public static int ToScore(this char c)
        {
            int score =  Encoding.ASCII.GetBytes(new[] { c })[0]-96;
            if (score > 0) return score;
            score += 58;
            return score;
        }
    }
}
