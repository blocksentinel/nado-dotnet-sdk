using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class StatusResponse
{
    [JsonPropertyName("reported_uptime")]
    public long ReportedUptime { get; set; }

    public string Address { get; set; } = null!;

    [JsonPropertyName("transaction_pool_hash")]
    public string? TransactionPoolHash { get; set; }

    [JsonPropertyName("block_producers_hash")]
    public string? BlockProducersHash { get; set; }

    [JsonPropertyName("latest_block_hash")]
    public string? LatestBlockHash { get; set; }

    [JsonPropertyName("earliest_block_hash")]
    public string? EarliestBlockHash { get; set; }

    public int Protocol { get; set; }

    public string Version { get; set; } = null!;
}
