using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class GetLatestBlockResponse
{
    [JsonPropertyName("block_number")]
    public long BlockNumber { get; set; }

    [JsonPropertyName("block_hash")]
    public string BlockHash { get; set; } = null!;

    [JsonPropertyName("parent_hash")]
    public string? ParentHash { get; set; }

    [JsonPropertyName("block_ip")]
    public string BlockIp { get; set; } = null!;

    [JsonPropertyName("block_creator")]
    public string BlockCreator { get; set; } = null!;

    [JsonPropertyName("block_timestamp")]
    public long BlockTimestamp { get; set; }

    [JsonPropertyName("block_transactions")]
    public object[] BlockTransactions { get; set; } = Array.Empty<object>();

    [JsonPropertyName("block_penalty")]
    public long BlockPenalty { get; set; }

    [JsonPropertyName("block_producers_hash")]
    public string BlockProducersHash { get; set; } = null!;

    [JsonPropertyName("child_hash")]
    public string? ChildHash { get; set; }

    [JsonPropertyName("block_reward")]
    public long BlockReward { get; set; }
}
