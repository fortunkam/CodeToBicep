namespace Memoryleek.CodeToBicep.Values;

public abstract class BaseValue : IBicepFormatter
{
    public abstract string ToBicepString(int indentCount = 0);
}
