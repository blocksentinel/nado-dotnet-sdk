using System.Text.Json.Nodes;

namespace BS.Nado.ApiClient.Responses;

public class HealthResponse
{
    public JsonArray Health { get; set; } = null!;
}
