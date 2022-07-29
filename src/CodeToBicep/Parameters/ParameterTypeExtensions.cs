namespace Memoryleek.CodeToBicep.Parameters;

public static class ParameterTypeExtensions
{
    public static string ToBicepType(this ParameterType parameterType) => parameterType switch
    {
        ParameterType.Array => "array",
        ParameterType.Bool => "bool",
        ParameterType.Int => "int",
        ParameterType.Object => "object",
        ParameterType.String => "string",
        _ => throw new ArgumentException($"Unknown parameter type : {parameterType}")
    };
}

