namespace AdventOfCode2022.Day02
{
    public interface IRPCGame
    {
        char Opponent { get; }
        char You { get; }

        int Score();
        bool? YouWon();
    }
}
