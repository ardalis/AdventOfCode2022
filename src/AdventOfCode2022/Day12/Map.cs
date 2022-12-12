namespace AdventOfCode2022.Day012;

public class Map
{
    public List<List<char>> Rows { get; } = new List<List<char>>();

    public static Map Parse(string input)
    {
        var map = new Map();
        var rows = input.Split(Environment.NewLine);
        foreach (var row in rows)
        {
            map.Rows.Add(row.ToCharArray().ToList());
        }

        return new Map();
    }

    public char this[int col, int row]
    {
        get { return Rows![row][col]; }
    }
}
