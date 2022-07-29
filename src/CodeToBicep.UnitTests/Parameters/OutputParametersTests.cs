using Memoryleek.CodeToBicep.Decorators;
using Memoryleek.CodeToBicep.Parameters;
using Memoryleek.CodeToBicep.UnitTests.TestAttributes;
using Memoryleek.CodeToBicep.Values;

namespace Memoryleek.CodeToBicep.UnitTests.Parameters;

public class OutputParametersTests
{
    [Theory]
    [RawFileData(@"Parameters\Expected\OutputString.bicep")]
    public void InputParameterStringWithNoDefault(string expected)
    {
        var param1 = new OutputParameter("MyOutputValue",
            ParameterType.String,
            new RawValue("some.reference.value"));

        Assert.Equal(expected, param1.ToBicepString());
    }

}
