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
    public bool Visited { get; set; }
    public List<int> PathToGetHere { get; set; } = new List<int>();
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

    public static Cell FindExitFromStart(Map map)
    {
        Channel<Cell> channel = Channel.CreateUnbounded<Cell>();
        var reader = channel.Reader;
        var writer = channel.Writer;

        var start = map.Cells.FirstOrDefault(c => c.Value == 'S');

        start.Visited = true;
        writer.TryWrite(start);

        while (reader.Count > 0)
        {
            reader.TryRead(out Cell cell);
            cell.Visited = true;
            if (cell.Value == 'E') return cell;

            foreach (int adjacentCellIndex in map.AdjacencyList[cell.Location])
            {
                var adjacentCell = map.Cells[adjacentCellIndex];
                if (!adjacentCell.Visited)
                {
                    adjacentCell.PathToGetHere = new List<int>(cell.PathToGetHere);
                    adjacentCell!.PathToGetHere.Add(cell.Location);
                    writer.TryWrite(adjacentCell);
                }
            }

        }
        return new Cell(-1, '*');
    }

}
