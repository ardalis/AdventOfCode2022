using System.Threading.Channels;

namespace AdventOfCode2022.Day012;

public struct Cell
{
    public Cell(short location, char value)
    {
        Location = location;
        Value = value;
    }
    public short Location { get; set; }
    public char Value { get; set; }
    public int Steps { get; set; }
    //public List<int> PathToGetHere { get; set; } = new List<int>();
}

public class Map
{
    public List<Cell> Cells { get; set; } = new();
    public Dictionary<int, List<int>> AdjacencyList = new();
    public int Height { get; set; }
    public int Width { get; set; }

    public static bool CanMoveTo(char fromChar, char toChar)
    {
        if (fromChar == 'S' && toChar == 'a') return true;
        if (fromChar == 'a' && toChar == 'S') return true;
        if (toChar == 'E' && fromChar != 'z') return false;

        if(fromChar >= toChar-1) return true;    
        return false;
    }

    public static Map Parse(string input)
    {
        var map = new Map();
        var rows = input.Split(Environment.NewLine);
        map.Height = rows.Length;
        map.Width = rows[0].ToCharArray().Length;
        short index = 0;
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
            foreach (int direction in directions)
            {
                int newIndex = i + direction;
                if (newIndex < 0) continue;
                if (newIndex >= map.Cells.Count) continue;

                if (CanMoveTo(map.Cells[i].Value, map.Cells[newIndex].Value))
                {
                    adjacentCells.Add(newIndex);
                }
            }
            map.AdjacencyList.Add(i, adjacentCells);
        }

        return map;
    }

    public static int FindStepsToExitFromStart(Map map)
    {
        var start = map.Cells.FirstOrDefault(c => c.Value == 'S');

        return FindStepsToExitFromStart(map, start.Location);
    }

    public static int FindStepsToExitFromStart(Map map, short startIndex)
    {
        Channel<int> channel = Channel.CreateUnbounded<int>();
        var reader = channel.Reader;
        var writer = channel.Writer;

        var visited = new HashSet<int>();

        writer.TryWrite(startIndex);
        int steps = 0;
        while (reader.Count > 0)
        {
            int size = reader.Count;
            while (size-- > 0)
            {
                reader.TryRead(out int index);
                if (visited.Contains(index)) continue;
                visited.Add(index);
                if (map.Cells[index].Value == 'E') return steps;
                foreach (int adjacentCellIndex in map.AdjacencyList[index])
                {
                    if (!visited.Contains(adjacentCellIndex))
                    {
                        writer.TryWrite(adjacentCellIndex);
                    }
                }
            }
            steps++;
        }
        return int.MaxValue;
    }

}
