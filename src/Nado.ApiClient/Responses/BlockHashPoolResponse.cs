using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class BlockHashPoolResponse
{
    [JsonPropertyName("block_opinions")]
    public Dictionary<string, string> BlockOpinions { get; set; } = new();

    [JsonPropertyName("majority_block_opinion")]
    public string? MajorityBlockOpinion { get; set; }
}
