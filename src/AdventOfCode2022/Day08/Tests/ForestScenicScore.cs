namespace AdventOfCode2022.Day08.Tests
{
    public class ForestMaxScenicScore
    {
        [Fact]
        public void Returns8GivenSample()
        {
            var forest = Forest.Parse(Input.SampleData);

            Assert.Equal(8, forest.MaxScenicScore());

        }

        [Fact]
        public void Returns8GivenRealInput()
        {
            var forest = Forest.Parse(Input.Data);

            Assert.Equal(8, forest.MaxScenicScore());

        }
    }
    public class ForestScenicScore
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(0, 3)]
        [InlineData(0, 4)]
        [InlineData(1, 0)]
        [InlineData(1, 4)]
        [InlineData(2, 0)]
        [InlineData(2, 4)]
        [InlineData(3, 0)]
        [InlineData(3, 4)]
        [InlineData(4, 0)]
        [InlineData(4, 1)]
        [InlineData(4, 2)]
        [InlineData(4, 3)]
        [InlineData(4, 4)]
        public void Returns0GivenEdgeTrees(int col, int row)
        {
            var forest = Forest.Parse(Input.SampleData);

            Assert.Equal(0, forest.ScenicScore(col, row));
        }

        [Fact]
        public void Returns8GivenBestSpot()
        {
            var forest = Forest.Parse(Input.SampleData);

            Assert.Equal(8, forest.ScenicScore(2, 3));

        }

    }
}
