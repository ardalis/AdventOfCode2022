namespace AdventOfCode2022.Day13.Tests;

public class SignalVerifierVerify
{
    [Fact]
    public void ReturnsTrueGivenFirstSample()
    {
        var verifier = new SignalVerifier();

        var pair = new SignalPair()
        {
            Left = "[1,1,3,1,1]",
            Right = "[1,1,5,1,1]"
        };

        Assert.True(verifier.Verify(pair));
    }

    [Fact]
    public void ReturnsTrueGivenSecondSample()
    {
        var verifier = new SignalVerifier();

        var pair = new SignalPair()
        {
            Left = "[[1],[2,3,4]]",
            Right = "[[1],4]"
        };

        Assert.True(verifier.Verify(pair));
    }
}
