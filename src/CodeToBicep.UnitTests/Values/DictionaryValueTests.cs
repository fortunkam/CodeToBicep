
using Memoryleek.CodeToBicep.UnitTests.TestAttributes;
using Memoryleek.CodeToBicep.Values;

namespace Memoryleek.CodeToBicep.UnitTests.Values;

public class DictionaryValueTests
{
    [RawFileData(@"Values/Expected/DictionaryValue.bfragment")]
    [Theory]
    public void ToBicepStringOutputsValueSingleLevel(string expected)
    {
        var dictionaryValue = new DictionaryValue(new Dictionary<string, BaseValue>
        {
            { "Key1", new RawValue("Value1") },
            { "Key2", new RawValue("Value2") },
        });
        
        var actual = dictionaryValue.ToBicepString();
        Assert.Equal(expected, actual);
    }
}
