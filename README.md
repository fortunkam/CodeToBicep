# CodeToBicep

(Very) Experimental project to allow you to build Azure Bicep files using C#.

To create a resource would look something like this...

```
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
```

and generate bicep using the ToBicepString() method to output this...

```
resource myStorageAccount 'Microsoft.Storage/storageAccounts@2019-06-01' = {
        name: 'examplestorage'
        location: 'northeurope'
        tags: {
                tagKey1: 'TagValue1'
                tagKey2: 'TagValue2'
                tagKey3: 'TagValue3'
        }
        prop1: 'propVal1'
        prop2: 'propVal2'
        prop3: 'propVal3'
        propDict: {
                subProp1: 'propVal1'
                subProp2: 'propVal1'
                subPropDict: {
                        subSubProp1: 'propVal1'
                        subSubProp2: 'propVal2'
                }

        }

}
```

Currentlt supports Resources, Parameters and Outputs.
