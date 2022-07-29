using Memoryleek.CodeToBicep.Values;
using Memoryleek.CodeToBicep.Decorators;
using System.Text;

namespace Memoryleek.CodeToBicep.Parameters;

public class InputParameter : IBicepFormatter
{
    readonly string _name;
    readonly ParameterType _parameterType;
    readonly IEnumerable<BaseDecorator> _decorators;
    readonly BaseValue? _defaultValue;

    public InputParameter(string name, ParameterType parameterType, IEnumerable<BaseDecorator> decorators, BaseValue? defaultValue = null)
    {
        _name = name;
        _parameterType = parameterType;
        _decorators = decorators;
        _defaultValue = defaultValue;
    }
    public string ToBicepString(int indentCount = 0)
    {
        var s = new StringBuilder();

        if (_decorators != null)
        {
            foreach (var d in _decorators)
            {
                s.AppendLine(d.ToBicepString());
            }
        }
        s.Append($"param {_name} {_parameterType.ToBicepType()}");
        if (_defaultValue != null)
        {
            s.Append($" = {_defaultValue.ToBicepString()}");
        }

        return s.ToString();
    }
}

