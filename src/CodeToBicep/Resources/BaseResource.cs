

using Memoryleek.CodeToBicep.Values;
namespace Memoryleek.CodeToBicep.Resources;


public abstract class BaseResource : IBicepFormatter
{
    protected readonly string _bicepName;
    protected readonly string _resourceType;
    protected readonly string _apiVersion;
    protected readonly BaseValue _name;
    protected readonly BaseValue? _scope;

    public BaseResource(string bicepName,
                        string resourceType,
                        string apiVersion,
                        BaseValue name,
                        BaseValue? scope)
    {
        _bicepName = bicepName;
        _resourceType = resourceType;
        _apiVersion = apiVersion;
        _name = name;
        _scope = scope;
    }

    public abstract string ToBicepString(int indentCount = 0);
}

