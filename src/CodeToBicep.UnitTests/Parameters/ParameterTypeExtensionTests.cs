
using Memoryleek.CodeToBicep.Parameters;

namespace Memoryleek.CodeToBicep.UnitTests.Parameters;

public class ParameterTypeExtensionTests
{
    [Theory]
    [InlineData(ParameterType.String, "string")]
    [InlineData(ParameterType.Int, "int")]
    [InlineData(ParameterType.Array, "array")]
    [InlineData(ParameterType.Bool, "bool")]
    [InlineData(ParameterType.Object, "object")]
    public void ParameterTypeMappingTest(ParameterType type, string expected)
    {
        Assert.Equal(expected, type.ToBicepType());
    }

    [Fact]
    public void ParameterTypeMappingFailsIfParameterTypeNotRecognised()
    {
        var pt = (ParameterType)6;
        Assert.Throws<ArgumentException>(() => pt.ToBicepType());
    }
}
