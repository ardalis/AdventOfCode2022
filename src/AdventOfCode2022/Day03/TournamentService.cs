namespace AdventOfCode2022.Day03
{
    public class TournamentService
    {
        public int ScoreEntireTournament(string input)
        {
            var games = input.Split(Environment.NewLine);

            int totalScore = games
                                .Select(input => RPCGame.FromString(input))
                                .Sum(game => game.Score());

            return totalScore;
        }
    }
}
