using Memoryleek.CodeToBicep.Values;
using System.Text;

namespace Memoryleek.CodeToBicep.Resources;

public class Resource : BaseResource
{
    private readonly Dictionary<string, BaseValue>? _properties;

    public Resource(string bicepName, 
                        string resourceType, 
                        string apiVersion,
                        BaseValue name,
                        BaseValue? scope,
                        Dictionary<string, BaseValue>? properties
                        ) : base(bicepName, resourceType, apiVersion, name, scope)
    {
        _properties = properties;
    }

    public override string ToBicepString(int indentCount = 0)
    {
        var s = new StringBuilder();

        s.AppendLine($"resource {_bicepName} '{_resourceType}@{_apiVersion}' = {{");
        s.AppendLine($"\tname: {_name.ToBicepString()}");
        if (_scope != null)
        {
            s.AppendLine($"\tscope: {_scope.ToBicepString()}");
        }
        if (_properties != null)
        {
            foreach (var item in _properties)
            {
                s.AppendLine($"\t{item.Key}: {item.Value.ToBicepString(1)}");
            }
        }
        s.Append("}");

        return s.ToString();
    }
}
