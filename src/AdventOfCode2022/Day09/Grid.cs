using System.Drawing;

namespace AdventOfCode2022.Day09;

public class Grid
{
    public Grid()
    {
        PointsVisited.Add(Start);
    }

    static Grid()
    {
        _vectors.Add('U', (Size)new Point(0, 1));
        _vectors.Add('D', (Size)new Point(0, -1));
        _vectors.Add('L', (Size)new Point(-1, 0));
        _vectors.Add('R', (Size)new Point(1, 0));
    }

    public Point Start { get; set; } = new Point(0, 0);
    public Point Head { get; set; } = new Point(0, 0);
    public Point Tail { get; set; } = new Point(0, 0);
    public HashSet<Point> PointsVisited { get; } = new HashSet<Point>();

    private static Dictionary<char, Size> _vectors = new();
    public void MoveHead(char direction, int distance)
    {
        for (int i = 0; i < distance; i++)
        {
            Head = Head + _vectors[direction];
            MoveTail();
        }
    }

    public void MoveTail()
    {
        // -2,1 -> -1,0 when H at 0,0
        var newTailX = Tail.X;
        var newTailY = Tail.Y;

        if (Head.X - Tail.X > 1)
        {
            newTailX++;
            if (Head.Y - Tail.Y > 0) newTailY++;
            if (Head.Y - Tail.Y < 0) newTailY--;
        }
        else if (Head.X - Tail.X < -1)
        {
            newTailX--;
            if (Head.Y - Tail.Y > 0) newTailY++;
            if (Head.Y - Tail.Y < 0) newTailY--;
        }
        else if (Head.Y - Tail.Y > 1)
        {
            newTailY++;
            if (Head.X - Tail.X > 0) newTailX++;
            if (Head.X - Tail.X < 0) newTailX--;

        }
        else if (Head.Y - Tail.Y < -1) 
        {
            newTailY--;
            if (Head.X - Tail.X > 0) newTailX++;
            if (Head.X - Tail.X < 0) newTailX--;
        }

        Tail = new Point(newTailX, newTailY);
        PointsVisited.Add(new Point(newTailX, newTailY));
    }
}
