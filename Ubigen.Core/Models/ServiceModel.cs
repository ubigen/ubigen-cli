namespace Ubigen.Core.Models;

/// <summary>
///  Servis düzeyindeki üst‑seviye model.  Ayrıntılı bounded context bilgisi
///  contexts/<Name>.yaml dosyalarına ayrılarak modüler hâle getirilir.
/// </summary>
public record ServiceModel
{
    /// <example>NotificationService</example>
    public string ServiceName { get; init; } = string.Empty;

    /// <summary>İş tanımı, kapsam ve kabul kriterlerini açıklayın.</summary>
    public string Description { get; init; } = string.Empty;

    /// <example>1.0.0</example>
    public string Version { get; init; } = "1.0.0";

    /// <summary>
    ///  messaging / database / logging / events gibi adapter anahtarları sözlükte tutulur.
    ///  Bağlantı stringleri burada yer almaz; .env veya secret store’a yönlendirilir.
    /// </summary>
    public Dictionary<string, Adapter> Adapters { get; init; } = new();

    /// <summary>Bu serviste mevcut bounded context isimleri.</summary>
    public IList<string> BoundedContexts { get; init; } = new List<string>();

    /// <summary>MCP veya AI agent’ların orkestrasyonu için servis meta.</summary>
    public McpConfig? Mcp { get; init; }
}

/// <summary>Adapter meta bilgisi (bağlantı detayı içermez).</summary>
public record Adapter
{
    public string Name        { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}

public record McpConfig
{
    public int Port { get; init; } = 0;                     // HTTP port
    public string HealthEndpoint { get; init; } = "/health";
    public IList<string> AllowedAgents { get; init; } = new List<string>();
}
