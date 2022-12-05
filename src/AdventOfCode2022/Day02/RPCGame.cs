namespace AdventOfCode2022.Day02
{
    public class RPCGame
    {
        public static RPCGame FromString(string gameString)
        {
            var chars = gameString.Split(' ');
            return new RPCGame(chars[0].ToCharArray()[0], chars[1].ToCharArray()[0]);
        }

        public RPCGame(char opponent, char you)
        {
            Opponent = opponent;
            You = you;
        }

        public char Opponent { get; }
        public char You { get; }

        public bool? YouWon()
        {
            if(Opponent == 'A')
            {
                if (You == 'X') return null;
                if (You == 'Y') return true;
                return false;
            }
            if(Opponent == 'B')
            {
                if (You == 'X') return false;
                if (You == 'Y') return null;
                return true;
            }
            if(Opponent == 'C')
            {
                if (You == 'X') return true;
                if (You == 'Y') return false;
                return null;
            }
            throw new Exception("Invalid combination");
        }

        public int Score()
        {
            int score = GetMyShapeScore();

            score += GetScoreResultScore(YouWon());

            return score;
        }

        private int GetMyShapeScore()
        {
            if (You == 'X') return 1;
            if (You == 'Y') return 2;
            if (You == 'Z') return 3;

            throw new Exception("Invalid combination");

        }

        private int GetScoreResultScore(bool? scoreResult)
        {
            if (!scoreResult.HasValue) return 3;
            if (scoreResult.Value) return 6;
            return 0;
        }
    }
}
