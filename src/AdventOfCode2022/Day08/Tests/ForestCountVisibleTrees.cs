namespace AdventOfCode2022.Day08.Tests
{
    public class ForestCountVisibleTrees
    {
        [Fact]
        public void Returns21GivenSampleData()
        {
            var forest = Forest.Parse(Input.SampleData);

            Assert.Equal(21, forest.CountVisibleTrees());
        }

        [Fact]
        public void Returns21GivenProblemData()
        {
            var forest = Forest.Parse(Input.Data);

            Assert.Equal(1818, forest.CountVisibleTrees());
        }
    }
}
