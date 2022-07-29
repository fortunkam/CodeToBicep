
namespace Memoryleek.CodeToBicep.Decorators;

public class SecureDecorator : BaseDecorator
{
    public override string ToBicepString(int indentCount = 0)
    {
        return "@secure()";
    }
}
