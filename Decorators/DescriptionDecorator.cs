
namespace CodeToBicep.Decorators
{
    public class DescriptionDecorator : BaseDecorator
    {
        readonly string _description;
        public DescriptionDecorator(string description)
        {
            _description = description;
        }
        public override string ToBicepString(int indentCount = 0)
        {
            return $"@description('{_description}')";
        }
    }
}
