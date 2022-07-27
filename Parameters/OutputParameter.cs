using CodeToBicep.BicepValue;
using System.Text;

namespace CodeToBicep.Parameters;

public class OutputParameter : IBicepFormatter
{
    readonly string _name;
    readonly ParameterType _parameterType;
    readonly BaseValue? _defaultValue;

    public OutputParameter(string name, ParameterType parameterType, BaseValue? defaultValue = null)
    {
        _name = name;
        _parameterType = parameterType;
        _defaultValue = defaultValue;
    }
    public string ToBicepString(int indentCount = 0)
    {
        var s = new StringBuilder();

        s.Append($"output {_name} {_parameterType.ToBicepType()}");
        if (_defaultValue != null)
        {
            s.Append($" = {_defaultValue.ToBicepString()}");
        }

        return s.ToString();
    }
}

