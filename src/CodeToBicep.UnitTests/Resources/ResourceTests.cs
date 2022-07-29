using Memoryleek.CodeToBicep.Resources;
using Memoryleek.CodeToBicep.UnitTests.TestAttributes;
using Memoryleek.CodeToBicep.Values;

namespace Memoryleek.CodeToBicep.UnitTests.Resources;

public class ResourceTests
{
    [Theory]
    [RawFileData(@"Resources/Expected/ResourceSimple.bicep")]
    public void ResourceSimpleOutputsBicep(string expected)
    {
        var resource1 = new Resource("myresource",
            "my.resource.type",
            "v123456",
            new StringValue("ResourceName"),
            null, null);

        Assert.Equal(expected, resource1.ToBicepString());
    }

    [Theory]
    [RawFileData(@"Resources/Expected/ResourceWithScope.bicep")]
    public void ResourceWithScopeOutputsBicep(string expected)
    {
        var resource1 = new Resource("myresource",
            "my.resource.type",
            "v123456",
            new StringValue("ResourceName"),
            new StringValue("MyScope"), null);

        Assert.Equal(expected, resource1.ToBicepString());
    }

    [Theory]
    [RawFileData(@"Resources/Expected/ResourceWithLocation.bicep")]
    public void ResourceWithLocationOutputsBicep(string expected)
    {
        var resource1 = new Resource("myresource",
            "my.resource.type",
            "v123456",
            new StringValue("ResourceName"),
            null, new Dictionary<string, BaseValue>()
            {
                {"location", new StringValue("northeurope") }
            });

        Assert.Equal(expected, resource1.ToBicepString());
    }

    [Theory]
    [RawFileData(@"Resources/Expected/ResourceWithTags.bicep")]
    public void ResourceWithTagsOutputsBicep(string expected)
    {
        var resource1 = new Resource("myresource",
            "my.resource.type",
            "v123456",
            new StringValue("ResourceName"),
            null, new Dictionary<string, BaseValue>()
            {
                { "tags", new DictionaryValue(new Dictionary<string, BaseValue>()
                {
                    { "tag1", new StringValue("Tag1Value") },
                    { "tag2", new StringValue("Tag2Value") }
                }) }
            });

        Assert.Equal(expected, resource1.ToBicepString());
    }

    [Theory]
    [RawFileData(@"Resources/Expected/ResourceWithNestedProperties.bicep")]
    public void ResourceWithNestedPropertiesOutputsBicep(string expected)
    {
        var resource1 = new Resource("myresource",
            "my.resource.type",
            "v123456",
            new StringValue("ResourceName"),
            null, new Dictionary<string, BaseValue>()
            {
                { "properties", new DictionaryValue(
                    new Dictionary<string, BaseValue>()
                    {
                        { "prop1", new StringValue("propVal1") },
                        { "prop2", new StringValue("propVal2") },
                        { "propDict", new DictionaryValue(
                            new Dictionary<string, BaseValue>()
                            {
                                { "subProp1", new StringValue("propVal1") },
                                { "subProp2", new StringValue("propVal2") },
                                { "subPropDict", new DictionaryValue(
                                    new Dictionary<string, BaseValue>()
                                    {
                                        { "subSubProp1", new StringValue("propVal1") },
                                        { "subSubProp2", new StringValue("propVal2") },
                                    })
                                }
                            }) 
                        }
                    }) 
                }
            });

        Assert.Equal(expected, resource1.ToBicepString());
    }
}
