using CodeToBicep.BicepValue;
using System.Text;


namespace CodeToBicep.Resources
{
    public class BicepResourceReference : BaseBicepResource
    {

        public BicepResourceReference(string bicepName, 
                            string resourceType, 
                            string apiVersion,
                            BaseValue name,
                            BaseValue? scope
                            ) : base(bicepName, resourceType, apiVersion, name, scope)
        {
        }

        public override string ToBicepString(int indentCount = 0)
        {
            var s = new StringBuilder();

            s.AppendLine($"resource {_bicepName} '{_resourceType}@{_apiVersion}' existing = {{");
            s.AppendLine($"\tname: {_name.ToBicepString()}");
            if(_scope != null)
            {
                s.AppendLine($"\tscope: {_scope.ToBicepString()}");
            }
            s.AppendLine("}");

            return s.ToString();
        }
    }
}
