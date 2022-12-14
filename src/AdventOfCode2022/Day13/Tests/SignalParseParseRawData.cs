using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day13.Tests;

public class SignalParseParseRawData
{
    [Fact]
    public void Returns8PairsFromSampleData()
    {
        var parser = new SignalParser();

        var result = parser.ParseRawData(Input.SampleData);

        Assert.Equal(8, result.Count);
    }
}
