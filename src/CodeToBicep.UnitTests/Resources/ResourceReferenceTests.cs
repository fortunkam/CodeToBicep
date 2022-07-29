
using Memoryleek.CodeToBicep.Resources;
using Memoryleek.CodeToBicep.UnitTests.TestAttributes;
using Memoryleek.CodeToBicep.Values;

namespace Memoryleek.CodeToBicep.UnitTests.Resources;

public class ResourceReferenceTests
{
    [Theory]
    [RawFileData(@"Resources/Expected/ExistingResourceWithScope.bicep")]
    public void ResourceReferenceWithScopeOutputsBicep(string expected)
    {
        var resource1 = new ResourceReference("myresource",
            "my.resource.type",
            "v123456",
            new StringValue("ResourceName"), 
            new StringValue("MyScope"));

        Assert.Equal(expected, resource1.ToBicepString());
    }

    [Theory]
    [RawFileData(@"Resources/Expected/ExistingResourceWithoutScope.bicep")]
    public void ResourceReferenceWithoutScopeOutputsBicep(string expected)
    {
        var resource1 = new ResourceReference("myresource",
            "my.resource.type",
            "v123456",
            new StringValue("ResourceName"),
            null);

        Assert.Equal(expected, resource1.ToBicepString());
    }
}