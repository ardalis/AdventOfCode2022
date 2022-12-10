namespace AdventOfCode2022.Day08.Tests
{
    public class ForestParse
    {
        [Fact]
        public void ReturnsCorrectTreeCount()
        {
            var forest = Forest.Parse(Input.SampleData);

            Assert.Equal(25, forest.Trees.Count());
        }
    }
}
