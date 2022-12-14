using System.Drawing;

namespace AdventOfCode2022.Day09;

public class Grid
{
    public Grid(int ropeSize)
    {
        PointsVisited.Add(Start);
        RopeSize = ropeSize;
        for (int i = 0; i < RopeSize; i++)
        {
            Rope.Add(new Point(0, 0));
        }
    }

    public Grid() : this(2) { }

    static Grid()
    {
        _vectors.Add('U', (Size)new Point(0, 1));
        _vectors.Add('D', (Size)new Point(0, -1));
        _vectors.Add('L', (Size)new Point(-1, 0));
        _vectors.Add('R', (Size)new Point(1, 0));
    }

    public Point Start { get; set; } = new Point(0, 0);
    public Point Head => Rope[0];
    public Point Tail => Rope[RopeSize - 1];
    public List<Point> Rope = new List<Point>();
    public HashSet<Point> PointsVisited { get; } = new HashSet<Point>();
    public int RopeSize { get; }

    private static Dictionary<char, Size> _vectors = new();
    public void MoveHead(char direction, int distance)
    {
        for (int i = 0; i < distance; i++)
        {
            Rope[0] = Rope[0] + _vectors[direction];
            for (int knotIndex = 1; knotIndex < RopeSize; knotIndex++)
            {
                MoveKnot(knotIndex);
            }
//            MoveTail();
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

        Rope[RopeSize-1] = new Point(newTailX, newTailY);
        PointsVisited.Add(new Point(newTailX, newTailY));
    }

    public void MoveKnot(int ropeIndex)
    {
        // -2,1 -> -1,0 when H at 0,0
        var newKnotX = Rope[ropeIndex].X;
        var newKnotY = Rope[ropeIndex].Y;

        var previousKnot = Rope[ropeIndex - 1];
        var currentKnot = Rope[ropeIndex];

        if (previousKnot.X - currentKnot.X > 1)
        {
            newKnotX++;
            if (previousKnot.Y - currentKnot.Y > 0) newKnotY++;
            if (previousKnot.Y - currentKnot.Y < 0) newKnotY--;
        }
        else if (previousKnot.X - currentKnot.X < -1)
        {
            newKnotX--;
            if (previousKnot.Y - currentKnot.Y > 0) newKnotY++;
            if (previousKnot.Y - currentKnot.Y < 0) newKnotY--;
        }
        else if (previousKnot.Y - currentKnot.Y > 1)
        {
            newKnotY++;
            if (previousKnot.X - currentKnot.X > 0) newKnotX++;
            if (previousKnot.X - currentKnot.X < 0) newKnotX--;

        }
        else if (previousKnot.Y - currentKnot.Y < -1)
        {
            newKnotY--;
            if (previousKnot.X - currentKnot.X > 0) newKnotX++;
            if (previousKnot.X - currentKnot.X < 0) newKnotX--;
        }

        Rope[ropeIndex] = new Point(newKnotX, newKnotY);
        //Tail = new Point(newKnotX, newKnotY);

        if (ropeIndex == RopeSize - 1)
        {
            PointsVisited.Add(new Point(newKnotX, newKnotY));
        }
    }

}
