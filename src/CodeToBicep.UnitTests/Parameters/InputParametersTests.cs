using Memoryleek.CodeToBicep.Decorators;
using Memoryleek.CodeToBicep.Parameters;
using Memoryleek.CodeToBicep.UnitTests.TestAttributes;
using Memoryleek.CodeToBicep.Values;

namespace Memoryleek.CodeToBicep.UnitTests.Parameters;

public class InputParametersTests
{
    [Theory]
    [RawFileData(@"Parameters/Expected/InputString_NoDefault.bicep")]
    public void InputParameterStringWithNoDefault(string expected)
    {
        var param1 = new InputParameter("MyParamName",
            ParameterType.String,
            null,
            null);

        Assert.Equal(expected, param1.ToBicepString());
    }

    [Theory]
    [RawFileData(@"Parameters/Expected/InputString_Default.bicep")]
    public void InputParameterStringWithDefault(string expected)
    {
        var param1 = new InputParameter("MyParamName",
            ParameterType.String,
            null,
            new StringValue("MyDefaultValue"));

        Assert.Equal(expected, param1.ToBicepString());
    }

    [Theory]
    [RawFileData(@"Parameters/Expected/InputString_Decorators.bicep")]
    public void InputParameterStringWithDecorators(string expected)
    {
        var param1 = new InputParameter("MyParamName",
            ParameterType.String,
            new BaseDecorator[]
            {
                new DescriptionDecorator("This is a decorator"),
                new SecureDecorator(),
                new AllowedDecorator<StringValue>(new[]
                {
                    new StringValue("One"),
                    new StringValue("Two")
                })
            },
            null);

        Assert.Equal(expected, param1.ToBicepString());
    }


}
