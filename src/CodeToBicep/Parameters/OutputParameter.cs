using Memoryleek.CodeToBicep.Values;
using System.Text;

namespace Memoryleek.CodeToBicep.Parameters;

public class OutputParameter : IBicepFormatter
{
    readonly string _name;
    readonly ParameterType _parameterType;
    readonly BaseValue _assignedValue;

    public OutputParameter(string name, ParameterType parameterType, BaseValue assignedValue)
    {
        _name = name;
        _parameterType = parameterType;
        _assignedValue = assignedValue;
    }
    public string ToBicepString(int indentCount = 0)
    {
        return $"output {_name} {_parameterType.ToBicepType()} = {_assignedValue.ToBicepString()}";
    }
}

