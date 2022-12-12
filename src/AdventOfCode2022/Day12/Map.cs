namespace AdventOfCode2022.Day012;

public class Cell
{
    public Cell(int location, char value)
    {
        Location = location;
        Value = value;
    }
    public int Location { get; set;}
    public char Value { get; set;}
}

public class Map
{
    public List<Cell> Cells { get; set; } = new();
    public Dictionary<int, List<int>> AdjacencyList = new();
    public int Height {  get; set;}
    public int Width { get; set;}

    public static Map Parse(string input)
    {
        var map = new Map();
        var rows = input.Split(Environment.NewLine);
        map.Height = rows.Length;
        map.Width = rows[0].ToCharArray().Length;
        int index = 0;
        foreach (var row in rows)
        {
            foreach (char c in row.ToCharArray())
            {
                var cell = new Cell(index, c);
                map.Cells.Add(cell);
                index++;
            }
        }

        // vector manipulation
        int up = -map.Width;
        int right = 1;
        int down = map.Width;
        int left = -1;

        var directions = new List<int> { up, right, down, left };


        for (int i = 0; i < map.Cells.Count; i++)
        {
            var adjacentCells = new List<int>();
            foreach(int direction in directions)
            {
                int newIndex = i + direction;
                if (newIndex < 0) continue;
                if (newIndex > map.Cells.Count) continue;

                // TODO: Implement CanMove method to do up-by-one check

                adjacentCells.Add(newIndex);
            }
            map.AdjacencyList.Add(i, adjacentCells);
        }

        return map;
    }
}
