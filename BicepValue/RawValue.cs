namespace CodeToBicep.BicepValue
{
    public class RawValue : BaseValue
    {
        readonly string _value;
        public RawValue(string value)
        {
            _value = value;
        }
        public override string ToBicepString(int indentCount = 0)
        {
            return _value;
        }
    }
}
