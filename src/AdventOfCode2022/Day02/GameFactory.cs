namespace AdventOfCode2022.Day02
{
    public interface IGameFactory<IRPCGame>
    {
        IRPCGame CreateGame(string input);
    }
}
