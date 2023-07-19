using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BS.Nado.ApiClient.Responses;

public class GetBlockNumberResponse
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
    public List<TransactionItem> BlockTransactions { get; set; } = new();

    [JsonPropertyName("block_penalty")]
    public long BlockPenalty { get; set; }

    [JsonPropertyName("block_producers_hash")]
    public string BlockProducersHash { get; set; } = null!;

    [JsonPropertyName("child_hash")]
    public string? ChildHash { get; set; }

    [JsonPropertyName("block_reward")]
    public long BlockReward { get; set; }

    public class TransactionItem
    {
        public string Sender { get; set; } = null!;
        public string Recipient { get; set; } = null!;

        public long Amount { get; set; }
        public long Timestamp { get; set; }
        public JsonObject Data { get; set; } = null!;
        public string Nonce { get; set; } = null!;

        [JsonPropertyName("public_key")]
        public string PublicKey { get; set; } = null!;

        [JsonPropertyName("target_block")]
        public long TargetBlock { get; set; }

        public long Fee { get; set; }
        public string TxId { get; set; } = null!;
        public string Signature { get; set; } = null!;
    }
}
