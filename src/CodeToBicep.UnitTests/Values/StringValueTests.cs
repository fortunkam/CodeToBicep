
using Memoryleek.CodeToBicep.Values;

namespace Memoryleek.CodeToBicep.UnitTests.Values;


public class StringValueTests
{
    [Fact]
    public void ToBicepStringOutputsValueWrappedInQuotes()
    {
        var sValue = new StringValue("Test Value");
        var actual = sValue.ToBicepString();
        Assert.Equal("'Test Value'", actual);

    }
    
    [Fact]
    public void ToBicepStringIgnoresIndent()
    {
        var sValue = new StringValue("Test Value");
        var actual = sValue.ToBicepString(5);
        Assert.Equal("'Test Value'", actual);
    }
}
