namespace AdventOfCode2022.Day02
{
    public class RPCGame2 : IRPCGame
    {
        public static RPCGame2 FromString(string gameString)
        {
            var chars = gameString.Split(' ');
            return new RPCGame2(chars[0].ToCharArray()[0], chars[1].ToCharArray()[0]);
        }

        public RPCGame2(char opponent, char expectedResult)
        {
            Opponent = opponent;
            _expectedResult = expectedResult;


        }

        public char Opponent { get; }
        private char _you = '?';
        public char You
        {
            get
            {
                if (_you == '?')
                {
                    _you = CalculateYourMove();
                }
                return _you;
            }
            set
            {
                _you = value;
            }
        }
        private char _expectedResult;

        public bool? YouWon()
        {
            if (You == '?')
            {
                You = CalculateYourMove();
            }

            if (Opponent == 'A')
            {
                if (You == 'X') return null;
                if (You == 'Y') return true;
                return false;
            }
            if (Opponent == 'B')
            {
                if (You == 'X') return false;
                if (You == 'Y') return null;
                return true;
            }
            if (Opponent == 'C')
            {
                if (You == 'X') return true;
                if (You == 'Y') return false;
                return null;
            }
            throw new Exception("Invalid combination");
        }

        /// <summary>
        /// X = lose; Y = draw; Z = win
        /// </summary>
        /// <returns></returns>
        private char CalculateYourMove()
        {
            if (Opponent == 'A')
            {
                if (_expectedResult == 'X') return 'Z';
                if (_expectedResult == 'Y') return 'X';
                return 'Y';
            }
            if (Opponent == 'B')
            {
                if (_expectedResult == 'X') return 'X';
                if (_expectedResult == 'Y') return 'Y';
                return 'Z';
            }
            if (Opponent == 'C')
            {
                if (_expectedResult == 'X') return 'Y';
                if (_expectedResult == 'Y') return 'Z';
                return 'X';
            }
            throw new Exception("Invalid move");
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
