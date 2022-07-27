namespace CodeToBicep.BicepValue
{
    public abstract class BaseValue : IBicepFormatter
    {
        public abstract string ToBicepString(int indentCount = 0);
    }
}
