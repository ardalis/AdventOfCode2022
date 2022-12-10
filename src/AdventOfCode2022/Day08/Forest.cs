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

        public List<Tree> GetNeighbors(int row, int col)
        {
            var list = new List<Tree>();
            for (int i = 0; i < this.Height; i++)
            {
                if (i == row)
                {
                    // add each colindex in the row except self
                    for(int colIndex = 0; colIndex < Width; colIndex++) 
                    {
                        string key = GetKey(colIndex, row);
                        //if
                    }
                }
                //list.Add(@"{row},{i}")
            }
            return list;
        }
    }
}
