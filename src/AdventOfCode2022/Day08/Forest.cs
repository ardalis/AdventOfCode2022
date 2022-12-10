namespace AdventOfCode2022.Day08
{
    public record Tree(int col, int row, int height);

    public class Forest
    {
        private Dictionary<string, int> _trees = new();
        public Dictionary<string, int> Trees { get { return _trees; } private set { _trees = value; } }

        public int Height { get; private set; }
        public int Width { get; private set; }

        public static Forest Parse(string input)
        {
            var forest = new Forest();
            var rows = input.Split(Environment.NewLine);
            forest.Height = rows.Count();
            forest.Width = rows[0].ToCharArray().Length;
            for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var colChars = rows[rowIndex].ToCharArray();
                for (var colIndex = 0; colIndex < colChars.Length; colIndex++)
                {
                    var key = GetKey(colIndex, rowIndex);
                    forest.Trees.Add(key, int.Parse(colChars[colIndex].ToString()));
                }
            }
            return forest;
        }

        public bool IsTreeVisible(int col, int row)
        {
            if (row == 0 || row == Width - 1) return true; // left and rightmost trees
            if (col == 0 || col == Height - 1) return true; // top and bottommost trees

            var thisTree = new Tree(col, row, Trees![GetKey(col, row)]);

            if (IsTreeVisibleFromLeftEdge(thisTree)) return true;
            if (IsTreeVisibleFromRightEdge(thisTree)) return true;
            if (IsTreeVisibleFromTopEdge(thisTree)) return true;
            if (IsTreeVisibleFromBottomEdge(thisTree)) return true;
            return false;
        }

        private bool IsTreeVisibleFromLeftEdge(Tree tree)
        {
            for (int i = 0; i < tree.col; i++)
            {
                if (Trees![GetKey(i, tree.row)] >= tree.height) return false;
            }
            return true;
        }
        private bool IsTreeVisibleFromRightEdge(Tree tree)
        {
            for (int i = tree.col+1; i < Width; i++)
            {
                if (Trees![GetKey(i, tree.row)] >= tree.height) return false;
            }
            return true;
        }
        private bool IsTreeVisibleFromTopEdge(Tree tree)
        {
            for (int i = 0; i < tree.row; i++)
            {
                if (Trees![GetKey(tree.col, i)] >= tree.height) return false;
            }
            return true;
        }
        private bool IsTreeVisibleFromBottomEdge(Tree tree)
        {
            for (int i = tree.row+1; i < Height; i++)
            {
                if (Trees![GetKey(tree.col, i)] >= tree.height) return false;
            }
            return true;
        }

        public static string GetKey(int colIndex, int rowIndex)
        {
            return $"{colIndex},{rowIndex}";
        }

        public static (int col, int row) GetColRow(string key)
        {
            var values = key.Split(",");
            return (int.Parse(values.First()),int.Parse(values.Last()));
        }

        public int CountVisibleTrees()
        {
            var trees = Trees.Keys.Select(k =>
            {
                (var col, var row) = GetColRow(k);
                return new Tree(col, row, Trees[k]);
            });
            return trees.Count(t => IsTreeVisible(t.col, t.row));
        }

        public int ScenicScore(int col, int row)
        {
            Tree tree = new (col, row, Trees[GetKey(col, row)]);
            return TreesSeenToLeft(tree) *
                TreesSeenToRight(tree) *
                TreesSeenAbove(tree) *
                TreesSeenBelow(tree);
        }

        public int MaxScenicScore()
        {
            int maxScore = 0;
            for (int col = 0; col < Width; col++)
            {
                for (int row = 0; row < Height; row++)
                {
                    int score = ScenicScore(col, row);
                    maxScore = Math.Max(maxScore, score);
                }

            }
            return maxScore;
        }

        public int TreesSeenToLeft(Tree tree)
        {
            if (tree.col == 0) return 0;
            int count = 0;
            for (int i = tree.col-1; i >= 0; i--)
            {
                count++;
                if (Trees![GetKey(i, tree.row)] >= tree.height) break;
            }
            return count;
        }
        public int TreesSeenToRight(Tree tree)
        {
            if (tree.col == Width) return 0;
            int count = 0;
            for (int i = tree.col+1; i < Width; i++)
            {
                count++;
                if (Trees![GetKey(i, tree.row)] >= tree.height) break;
            }
            return count;
        }
        public int TreesSeenAbove(Tree tree)
        {
            if (tree.row == 0) return 0;
            int count = 0;
            for (int i = tree.row-1; i >= 0; i--)
            {
                count++;
                if (Trees![GetKey(tree.col, i)] >= tree.height) break;
            }
            return count;
        }
        public int TreesSeenBelow(Tree tree)
        {
            if (tree.row == Height) return 0;
            int count = 0;
            for (int i = tree.row+1; i < Height; i++)
            {
                count++;
                if (Trees![GetKey(tree.col, i)] >= tree.height) break;
            }
            return count;
        }

    }
}
