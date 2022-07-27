
namespace CodeToBicep.BicepValue
{
    public class StringValue : BaseValue
    {
        readonly string _value;
        public StringValue(string value)
        {
            _value = value;
        }
        public override string ToBicepString(int indentCount = 0)
        {
            return $"'{_value}'";
        }
    }
}
