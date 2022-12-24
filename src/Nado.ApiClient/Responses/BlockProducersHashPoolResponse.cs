using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class BlockProducersHashPoolResponse
{
    [JsonPropertyName("block_producers_hash_pool")]
    public Dictionary<string, string> BlockProducersHashPool { get; set; } = new();

    [JsonPropertyName("majority_block_producers_hash_pool")]
    public string? MajorityBlockProducersHashPool { get; set; }
}
