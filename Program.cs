using CodeToBicep.BicepValue;
using CodeToBicep.Decorators;
using CodeToBicep.Parameters;
using CodeToBicep.Resources;

var param1 = new InputParameter("testParam",
    ParameterType.String,
    new BaseDecorator[] {
        new AllowedDecorator<StringValue>(new StringValue("One"), new StringValue("Two")),
        new SecureDecorator(),
        new DescriptionDecorator("This is a string value")
    },
    new StringValue("One"));

var output1 = new OutputParameter("someOutputParam",
    ParameterType.String,
    new RawValue("deployStorage ? myStorageAccount.properties.primaryEndpoints.blob : ''"));

var existingResource = new BicepResourceReference("myStorageAccount", 
    "Microsoft.Storage/storageAccounts", 
    "2019-06-01", 
    new StringValue("examplestorage"), null);

var newResource = new BicepResource("myStorageAccount",
    "Microsoft.Storage/storageAccounts",
    "2019-06-01",
    new StringValue("examplestorage"),
    null,
    new StringValue("northeurope"),
    new Dictionary<string, BaseValue>()
    {
        {"tagKey1", new StringValue("TagValue1") },
        {"tagKey2", new StringValue("TagValue2") },
        {"tagKey3", new StringValue("TagValue3") },
    }, 
    new Dictionary<string, BaseValue>()
    {
        { "prop1", new StringValue("propVal1") },
        { "prop2", new StringValue("propVal2") },
        { "prop3", new StringValue("propVal3") },
        { "propDict", new DictionaryBaseValue(new Dictionary<string, BaseValue>()
            {
                { "subProp1", new StringValue("propVal1") },
                { "subProp2", new StringValue("propVal1") },
                { "subPropDict", new DictionaryBaseValue(new Dictionary<string, BaseValue>()
                {
                    {"subSubProp1", new StringValue("propVal1") },
                    {"subSubProp2", new StringValue("propVal2") },
                })}
            })
        }
    });



Console.WriteLine(param1.ToBicepString());
Console.WriteLine("--------------------------------");
Console.WriteLine(output1.ToBicepString());
Console.WriteLine("--------------------------------");
Console.WriteLine(existingResource.ToBicepString());
Console.WriteLine("--------------------------------");
Console.WriteLine(newResource.ToBicepString());


