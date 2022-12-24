using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class BlockProducersResponse
{
    [JsonPropertyName("block_producers")]
    public List<string> BlockProducers { get; set; } = new();
}
