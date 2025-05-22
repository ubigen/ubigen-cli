using Ubigen.Core.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Ubigen.Core.Parsers;

public static class DomainYaml
{
    private static readonly IDeserializer Deserializer = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .IgnoreUnmatchedProperties()
        .Build();

    private static readonly ISerializer Serializer = new SerializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();
    
    public static DomainModel Load(string filePath = "domain.yaml")
    {
        if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
        {
            return new DomainModel();
        }

        var yaml = File.ReadAllText(filePath);
        var model = Deserializer.Deserialize<DomainModel>(yaml);
        return model ?? new DomainModel();
    }
    
    public static void Save(DomainModel model, string filePath = "domain.yaml")
    {
        var yaml = Serializer.Serialize(model);
        File.WriteAllText(filePath, yaml);
    }
}
