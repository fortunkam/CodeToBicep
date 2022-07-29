using Memoryleek.CodeToBicep.Values;
using System.Text;


namespace Memoryleek.CodeToBicep.Resources;

public class ResourceReference : BaseResource
{

    public ResourceReference(string bicepName, 
                        string resourceType, 
                        string apiVersion,
                        BaseValue name,
                        BaseValue? scope
                        ) : base(bicepName, resourceType, apiVersion, name, scope)
    {
    }

    public override string ToBicepString(int indentCount = 0)
    {
        var s = new StringBuilder();

        s.AppendLine($"resource {_bicepName} '{_resourceType}@{_apiVersion}' existing = {{");
        s.AppendLine($"\tname: {_name.ToBicepString()}");
        if(_scope != null)
        {
            s.AppendLine($"\tscope: {_scope.ToBicepString()}");
        }
        s.Append("}");

        return s.ToString();
    }
}
