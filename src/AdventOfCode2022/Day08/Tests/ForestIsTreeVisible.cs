namespace AdventOfCode2022.Day08.Tests
{
    public class ForestIsTreeVisible
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(0,1)]
        [InlineData(0,2)]
        [InlineData(0,3)]
        [InlineData(0,4)]
        [InlineData(1,0)]
        [InlineData(1,4)]
        [InlineData(2,0)]
        [InlineData(2,4)]
        [InlineData(3,0)]
        [InlineData(3,4)]
        [InlineData(4,0)]
        [InlineData(4,1)]
        [InlineData(4,2)]
        [InlineData(4,3)]
        [InlineData(4,4)]
        public void ReturnsTrueGivenEdgeTree(int col, int row)
        {
            var forest = Forest.Parse(Input.SampleData);

            Assert.True(forest.IsTreeVisible(col, row));
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(1,2)]
        [InlineData(2,1)]
        [InlineData(2,3)]
        [InlineData(3,2)]
        public void ReturnsTrueGivenHigherThanAnyTreesBetweenItAndEdgeUsingSampleData(int col, int row)
        {
            var forest = Forest.Parse(Input.SampleData);

            Assert.True(forest.IsTreeVisible(col, row));
        }
    }
}
