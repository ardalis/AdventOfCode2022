namespace AdventOfCode2022.Day02
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
    public class TournamentService2
    {
        public int ScoreEntireTournament(string input)
        {
            var games = input.Split(Environment.NewLine);

            int totalScore = games
                                .Select(input => RPCGame2.FromString(input))
                                .Sum(game => game.Score());

            return totalScore;
        }
    }
}
