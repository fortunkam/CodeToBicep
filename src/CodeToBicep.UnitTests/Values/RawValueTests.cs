
using Memoryleek.CodeToBicep.Values;

namespace Memoryleek.CodeToBicep.UnitTests.Values;


public class RawValueTests
{
    [Fact]
    public void ToBicepStringOutputsValue()
    {
        var rawValue = new RawValue("Test Value");
        var actual = rawValue.ToBicepString();
        Assert.Equal("Test Value", actual);

    }
    
    [Fact]
    public void ToBicepStringIgnoresIndent()
    {
        var rawValue = new RawValue("Test Value");
        var actual = rawValue.ToBicepString(5);
        Assert.Equal("Test Value", actual);
    }
}
