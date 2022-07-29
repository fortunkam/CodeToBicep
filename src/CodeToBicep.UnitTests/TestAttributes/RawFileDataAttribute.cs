using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Xunit.Sdk;

namespace Memoryleek.CodeToBicep.UnitTests.TestAttributes;

public class RawFileDataAttribute : DataAttribute
{
    private readonly string _filePath;
    public RawFileDataAttribute(string filePath)
    {
        _filePath = filePath;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

        // Get the absolute path to the file
        var path = Path.IsPathRooted(_filePath)
            ? _filePath
            : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

        if (!File.Exists(path))
        {
            throw new ArgumentException($"Could not find file at path: {path}");
        }

        // Load the file
        var fileData = File.ReadAllText(_filePath);

        // Only use the specified property as the data
        var data = new List<object[]>();
        data.Add(new object[] { fileData });
        return data;
    }
}
