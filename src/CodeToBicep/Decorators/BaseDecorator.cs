
namespace Memoryleek.CodeToBicep.Decorators;

public abstract class BaseDecorator: IBicepFormatter
{
    public abstract string ToBicepString(int indentCount = 0);
}
