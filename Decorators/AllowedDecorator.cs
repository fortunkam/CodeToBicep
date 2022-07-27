namespace CodeToBicep.Decorators
{
    public class AllowedDecorator<T> : BaseDecorator
        where T : IBicepFormatter
    {
        readonly T[] _allowedValues;
        public AllowedDecorator(params T[] allowedValues)
        {
            _allowedValues = allowedValues;
        }
        public override string ToBicepString(int indentCount = 0)
        {
            var allowedValuesBicep = string.Join("\r\n", _allowedValues.Select(v => $"\t{v.ToBicepString()}"));
            return $"@allowed([\r\n{allowedValuesBicep}\r\n])";
        }
    }
}
