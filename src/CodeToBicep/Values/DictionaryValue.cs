using System.Text;

namespace Memoryleek.CodeToBicep.Values;

public class DictionaryValue : BaseValue
{
    private readonly Dictionary<string, BaseValue> _keyValuePairs;

    public DictionaryValue(Dictionary<string, BaseValue> keyValuePairs)
    {
        _keyValuePairs = keyValuePairs;
    }

    public override string ToBicepString(int indentCount = 0)
    {
        var tabs = new string('\t', indentCount);
        var s = new StringBuilder();
        s.AppendLine($"{{");
        foreach(var item in _keyValuePairs)
        {
            s.AppendLine($"{tabs}\t{item.Key}: {item.Value.ToBicepString(indentCount+1)}");
        }
        s.Append($"{tabs}}}");

        return s.ToString();
    }
}
