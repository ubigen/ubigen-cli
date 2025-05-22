using Ubigen.Core.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Ubigen.Core.Parsers;

/// <summary>
///  service.yaml dosyasını serialize / deserialize eden yardımcı sınıf.
/// </summary>
public static class ServiceYaml
{
    private static readonly IDeserializer Deserializer = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .IgnoreUnmatchedProperties()
        .Build();

    private static readonly ISerializer Serializer = new SerializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
        .Build();

    /// <summary>
    ///  Belirtilen yoldan service.yaml dosyasını yükler;
    ///  dosya yoksa veya boşsa yeni bir ServiceModel döner.
    /// </summary>
    public static ServiceModel Load(string filePath = "service.yaml")
    {
        if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            return new ServiceModel();

        var yaml = File.ReadAllText(filePath);
        return Deserializer.Deserialize<ServiceModel>(yaml) ?? new ServiceModel();
    }

    /// <summary>
    ///  Verilen ServiceModel'i YAML olarak belirtilen dosyaya yazar.
    /// </summary>
    public static void Save(ServiceModel model, string filePath = "service.yaml")
    {
        var yaml = Serializer.Serialize(model);
        File.WriteAllText(filePath, yaml);
    }
}
