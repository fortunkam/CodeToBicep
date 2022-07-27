using CodeToBicep.BicepValue;
using System.Text;

namespace CodeToBicep.Resources
{
    public class BicepResource : BaseBicepResource
    {
        private readonly BaseValue? _location;
        private readonly Dictionary<string, BaseValue> _tags;
        private readonly Dictionary<string, BaseValue> _properties;

        public BicepResource(string bicepName, 
                            string resourceType, 
                            string apiVersion,
                            BaseValue name,
                            BaseValue? scope,
                            BaseValue? location,
                            Dictionary<string, BaseValue> tags,
                            Dictionary<string, BaseValue> properties
                            ) : base(bicepName, resourceType, apiVersion, name, scope)
        {
            _location = location;
            _tags = tags;
            _properties = properties;
        }

        public override string ToBicepString(int indentCount = 0)
        {
            var s = new StringBuilder();

            s.AppendLine($"resource {_bicepName} '{_resourceType}@{_apiVersion}' = {{");
            s.AppendLine($"\tname: {_name.ToBicepString()}");
            if (_scope != null)
            {
                s.AppendLine($"\tscope: {_scope.ToBicepString()}");
            }
            if (_location != null)
            {
                s.AppendLine($"\tlocation: {_location.ToBicepString()}");
            }
            if(_tags != null && _tags.Count > 0)
            {
                s.AppendLine($"\ttags: {{");
                  
                foreach(var t in _tags)
                {
                    s.AppendLine($"\t\t{t.Key}: {t.Value.ToBicepString()}");
                }
                
                s.AppendLine("\t}");
            }
            if (_properties != null)
            {
                foreach (var item in _properties)
                {
                    s.AppendLine($"\t{item.Key}: {item.Value.ToBicepString(1)}");
                }
            }
            s.AppendLine("}");

            return s.ToString();
        }
    }
}
